using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.DefaultConcepts
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(EntityLoggingInfo))]
    public class LoggingDataStructureCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (EntityLoggingInfo)conceptInfo;
            codeBuilder.InsertCode(String.Format(@"""hasLogging"":true,
"), DataStructureCodeGenerator.AttributesTag, info.Entity);
        }
    }
}
