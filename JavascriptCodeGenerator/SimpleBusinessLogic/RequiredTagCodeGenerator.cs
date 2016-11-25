using JavascriptModelGenerator.Property;
using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.SimpleBusinessLogic
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(RequiredPropertyInfo))]
    public class RequiredTagCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (RequiredPropertyInfo)conceptInfo;

            codeBuilder.InsertCode(@"""required"": true,
", SimplePropertyCodeGenerator.AdditionalPropertiesTag, info.Property);
        }
    }
}
