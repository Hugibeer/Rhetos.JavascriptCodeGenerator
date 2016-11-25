using JavascriptModelGenerator.Property;
using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.SimpleBusinessLogic
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(UserRequiredPropertyInfo))]
    public class UserRequiredTagCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (UserRequiredPropertyInfo)conceptInfo;
            codeBuilder.InsertCode(@"""userRequired"": true,
", SimplePropertyCodeGenerator.AdditionalPropertiesTag, info.Property);
        }
    }
}
