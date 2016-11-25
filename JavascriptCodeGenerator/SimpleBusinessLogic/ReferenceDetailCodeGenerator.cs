using JavascriptModelGenerator.Property;
using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.SimpleBusinessLogic
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(ReferenceDetailInfo))]
    public class ReferenceDetailCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (ReferenceDetailInfo)conceptInfo;

            codeBuilder.InsertCode(@"""detail"": true,
", SimplePropertyCodeGenerator.AdditionalPropertiesTag, info.Reference);
        }
    }
}
