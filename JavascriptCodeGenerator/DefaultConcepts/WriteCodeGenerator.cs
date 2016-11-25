using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.DefaultConcepts
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(WriteInfo))]

    public class WriteCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (WriteInfo)conceptInfo;

            if (info is IWritableOrmDataStructure)
                codeBuilder.InsertCode(
                    @"""writable"":true,
",
                    DataStructureCodeGenerator.AttributesTag, info.DataStructure);
        }
    }
}
