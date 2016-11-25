using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.DefaultConcepts
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(ModuleInfo))]
    public class ModuleCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public static readonly CsTag<ModuleInfo> DataStructureTag = "DataStructure";
        public static readonly CsTag<ModuleInfo> DataStructureReturnTag = "DataStructureReturn";

        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            ModuleInfo info = (ModuleInfo)conceptInfo;

            codeBuilder.InsertCode(ImplementationCodeSnippet(info));
        }

        private static string ImplementationCodeSnippet(ModuleInfo info)
        {
            return string.Format(@"
var {0} = (function (_{0}) {{
    var moduleRoot = ""{0}"";
    {1}
    return {{
        {2}
    }};
}}({0} || {{}}));
",
                info.Name,
                DataStructureTag.Evaluate(info),
                DataStructureReturnTag.Evaluate(info)
            );
        }
    }
}
