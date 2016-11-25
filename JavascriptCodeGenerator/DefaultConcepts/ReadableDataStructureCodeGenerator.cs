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
    public class ReadableDataStructureCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public static bool IsSupported(DataStructureInfo conceptInfo)
        {
            return conceptInfo is IOrmDataStructure
                || conceptInfo is BrowseDataStructureInfo
                || conceptInfo is QueryableExtensionInfo
                || conceptInfo is ComputedInfo;
        }
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (DataStructureInfo)conceptInfo;

            if (IsSupported(info))
                codeBuilder.InsertCode(String.Format(@"""readable"":true,
"), DataStructureCodeGenerator.AttributesTag, info);
        }
    }
}
