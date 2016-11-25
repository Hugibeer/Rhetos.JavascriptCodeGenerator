using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.Property
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(DatePropertyInfo))]
    public class DatePropertyCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (DatePropertyInfo)conceptInfo;
            codeBuilder.InsertCode(PropertyHelper.Format(@"{0:dd.MM.yyyy.}"), SimplePropertyCodeGenerator.AdditionalPropertiesTag, info);
        }
    }
}
