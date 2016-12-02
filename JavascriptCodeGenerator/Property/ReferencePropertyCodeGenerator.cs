using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.Property
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(ReferencePropertyInfo))]
    public class ReferencePropertyCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (ReferencePropertyInfo)conceptInfo;
            codeBuilder.InsertCode(ImplementationDescriptionCodeSnippet(info), SimplePropertyCodeGenerator.AdditionalPropertiesTag, info);
        }

        private string ImplementationDescriptionCodeSnippet(ReferencePropertyInfo info)
        {
            return string.Format(
@"    ""lookupEntity"":""{0}.{1}"",
", info.Referenced.Module, info.Referenced.Name);

        }
    }
}
