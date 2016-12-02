using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.DefaultConcepts
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(DataStructureExtendsInfo))]
    public class ExtendsCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (DataStructureExtendsInfo)conceptInfo;
            codeBuilder.InsertCode(String.Format(@"""extends"":""{0}.{1}"",
", info.Base.Module.Name, info.Base.Name), DataStructureCodeGenerator.AttributesTag, info.Extension);
        }
    }
}
