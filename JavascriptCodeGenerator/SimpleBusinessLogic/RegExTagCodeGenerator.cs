using JavascriptModelGenerator.Property;
using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using Rhetos.Utilities;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.SimpleBusinessLogic
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(RegExMatchInfo))]
    public class RegExTagCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (RegExMatchInfo)conceptInfo;

            var regexString = string.Format(@"""regex"":{{ ""Pattern"": {0}, 
            ""ErrorMessage"": {1} }},
",
                CsUtility.QuotedString(info.RegularExpression).Replace("@", ""),
                CsUtility.QuotedString(info.ErrorMessage).Replace("@", ""));

            codeBuilder.InsertCode(regexString, SimplePropertyCodeGenerator.AdditionalPropertiesTag, info.Property);
        }
    }
}
