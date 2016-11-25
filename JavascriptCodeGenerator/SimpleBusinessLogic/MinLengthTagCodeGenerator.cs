using JavascriptModelGenerator.Property;
using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.SimpleBusinessLogic
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(MinLengthInfo))]
    public class MinLengthTagCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (MinLengthInfo)conceptInfo;
            codeBuilder.InsertCode(string.Format(@"""minLength"": {0},
", info.Length), SimplePropertyCodeGenerator.AdditionalPropertiesTag, info.Property);
        }
    }
}
