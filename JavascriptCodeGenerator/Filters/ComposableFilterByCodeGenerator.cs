using JavascriptModelGenerator.DefaultConcepts;
using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.Filters
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(ComposableFilterByInfo))]
    public class ComposableFilterByCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (ComposableFilterByInfo)conceptInfo;

            codeBuilder.InsertCode(GeenerateFilterByCode(info), DataStructureCodeGenerator.FiltersTag, info.Source);
        }

        private string GeenerateFilterByCode(ComposableFilterByInfo info)
        {
            string filterName = info.Parameter.IndexOf('.') == -1 ? info.Source.Module.Name + "." + info.Parameter : info.Parameter;
            return string.Format(
@"{{
    ""filterName"": ""{0}"",
    ""filterType"": ""composableFilterBy""
}}, ", filterName);
        }
    }
}
