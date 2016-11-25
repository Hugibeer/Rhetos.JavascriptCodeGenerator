using Rhetos.Compiler;
using Rhetos.Extensibility;
using Rhetos.Logging;
using Rhetos.Utilities;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Yahoo.Yui.Compressor;
using ICodeGenerator = Rhetos.Compiler.ICodeGenerator;

namespace JavascriptModelGenerator
{
    [Export(typeof(IGenerator))]
    public class JavaScriptModelGenerator : IGenerator
    {
        private readonly IPluginsContainer<IJavascriptModelGeneratorPlugin> _plugins;
        private readonly ICodeGenerator _codeGenerator;
        private readonly IAssemblyGenerator _assemblyGenerator;
        private readonly ILogger _performanceLogger;
        public const string OutputFile = "Rhetos.JSModel.js";

        public JavaScriptModelGenerator(
            IPluginsContainer<IJavascriptModelGeneratorPlugin> plugins,
            ICodeGenerator codeGenerator,
            IAssemblyGenerator assemblyGenerator,
            ILogProvider logProvider)
        {
            _plugins = plugins;
            _codeGenerator = codeGenerator;
            _assemblyGenerator = assemblyGenerator;
            _performanceLogger = logProvider.GetLogger("Performance");
        }

        const string detectLineTag = @"\n\s*/\*.*?\*/\s*\r?\n";
        const string detectTag = @"/\*.*?\*/";

        public void Generate()
        {
            var sw = Stopwatch.StartNew();
            JavaScriptSource jsSource = GenerateSource();

            var compressor = new JavaScriptCompressor();
            jsSource.GeneratedCode = Regex.Replace(jsSource.GeneratedCode, detectLineTag, "\n");
            jsSource.GeneratedCode = Regex.Replace(jsSource.GeneratedCode, detectTag, "");
            var minifiedString = compressor.Compress(jsSource.GeneratedCode);


            var outFileStream = File.Create(Path.Combine(Paths.GeneratedFolder, OutputFile));
            var modelBytes = new UTF8Encoding(true).GetBytes(minifiedString);
            outFileStream.Write(modelBytes, 0, modelBytes.Length);
            outFileStream.Close();
        }

        private JavaScriptSource GenerateSource()
        {
            IAssemblySource generatedSource = _codeGenerator.ExecutePlugins(_plugins, "/*", "*/", null);
            JavaScriptSource assemblySource = new JavaScriptSource
            {
                GeneratedCode = generatedSource.GeneratedCode,
                RegisteredReferences = generatedSource.RegisteredReferences
            };
            return assemblySource;
        }

        public IEnumerable<string> Dependencies
        {
            get { return new string[] { }; }
        }
    }
}
