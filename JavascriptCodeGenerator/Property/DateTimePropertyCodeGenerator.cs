using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.Property
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(DateTimePropertyInfo))]
    public class DateTimePropertyCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (DateTimePropertyInfo)conceptInfo;
            codeBuilder.InsertCode(PropertyHelper.Format(@"{0:dd.MM.yyyy. HH:mm:ss}"), SimplePropertyCodeGenerator.AdditionalPropertiesTag, info);
        }
    }
}
