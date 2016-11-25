using JavascriptModelGenerator.Property;
using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.SimpleBusinessLogic
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(AutoCodePropertyInfo))]
    public class AutoCodePropertyCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (AutoCodePropertyInfo)conceptInfo;
            codeBuilder.InsertCode(@"""autoCode"":true,
", SimplePropertyCodeGenerator.AdditionalPropertiesTag, info.Property);
        }
    }
}
