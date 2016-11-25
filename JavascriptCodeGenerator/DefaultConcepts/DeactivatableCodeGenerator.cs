using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.DefaultConcepts
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(DeactivatableInfo))]
    public class DeactivatableCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = conceptInfo as DeactivatableInfo;
            codeBuilder.InsertCode(@"""deactivatable"":true,
", DataStructureCodeGenerator.AttributesTag, info.Entity);
        }
    }
}
