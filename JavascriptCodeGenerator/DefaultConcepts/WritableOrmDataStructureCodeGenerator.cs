using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.DefaultConcepts
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(DataStructureInfo))]
    [ExportMetadata(MefProvider.DependsOn, typeof(DataStructureCodeGenerator))]
    public class WritableOrmDataStructureCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (DataStructureInfo)conceptInfo;

            codeBuilder.InsertCode(String.Format(@"""writable"":true,
"), DataStructureCodeGenerator.AttributesTag, info);
        }
    }
}
