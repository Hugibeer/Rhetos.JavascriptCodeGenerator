using JavascriptModelGenerator.DefaultConcepts;
using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.Property
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(EntityHistoryInfo))]
    public class HistoryDataStructureCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (EntityHistoryInfo)conceptInfo;
            codeBuilder.InsertCode(String.Format(@"""hasHistory"":true,
"), DataStructureCodeGenerator.AttributesTag, info.Entity);
        }
    }
}
