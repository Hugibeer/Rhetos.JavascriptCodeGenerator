using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.Property
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(MoneyPropertyInfo))]
    public class MoneyPropertyCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (MoneyPropertyInfo)conceptInfo;
            codeBuilder.InsertCode((@"""money"": true,
"), SimplePropertyCodeGenerator.AdditionalPropertiesTag, info);
        }
    }
}
