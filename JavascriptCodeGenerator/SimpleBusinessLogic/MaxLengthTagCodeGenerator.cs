using JavascriptModelGenerator.Property;
using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.SimpleBusinessLogic
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(MaxLengthInfo))]
    public class MaxLengthTagCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (MaxLengthInfo)conceptInfo;
            codeBuilder.InsertCode(string.Format(@"""minLength"": {0},
", info.Length), SimplePropertyCodeGenerator.AdditionalPropertiesTag, info.Property);
        }
    }
}
