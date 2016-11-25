using JavascriptModelGenerator.Property;
using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.SimpleBusinessLogic
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(MaxValueInfo))]
    public class MaxValueTagCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (MaxValueInfo)conceptInfo;

            var value = (info.Property is IntegerPropertyInfo
                || info.Property is MoneyPropertyInfo || info.Property is DecimalPropertyInfo) ? info.Value :
                (info.Property is DatePropertyInfo || info.Property is DateTimePropertyInfo) ? string.Format(@"""{0}""", info.Value) : null;
            codeBuilder.InsertCode(string.Format(@"""minValue"": {0},
", value), SimplePropertyCodeGenerator.AdditionalPropertiesTag, info.Property);
        }
    }
}
