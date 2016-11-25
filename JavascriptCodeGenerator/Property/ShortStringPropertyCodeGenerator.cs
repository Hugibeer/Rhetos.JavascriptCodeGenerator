using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.Property
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(ShortStringPropertyInfo))]
    public class ShortStringPropertyCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (ShortStringPropertyInfo)conceptInfo;
            codeBuilder.InsertCode(@"""maxLength"":256," + Environment.NewLine, SimplePropertyCodeGenerator.AdditionalPropertiesTag, info);
        }
    }
}
