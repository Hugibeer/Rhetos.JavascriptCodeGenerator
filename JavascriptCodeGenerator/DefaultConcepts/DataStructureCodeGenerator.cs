using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.DefaultConcepts
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(DataStructureInfo))]
    public class DataStructureCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public static readonly CsTag<DataStructureInfo> PropertiesConstructorTag = "PropertiesConstructor";
        public static readonly CsTag<DataStructureInfo> FieldsDescriptionsTag = "FieldsDescriptions";
        public static readonly CsTag<DataStructureInfo> AttributesTag = "Attributes";
        public static readonly CsTag<DataStructureInfo> FiltersTag = "Filters";

        public static bool IsEntityType(DataStructureInfo conceptInfo)
        {
            return conceptInfo is IOrmDataStructure
                || conceptInfo is BrowseDataStructureInfo
                || conceptInfo is QueryableExtensionInfo
                || conceptInfo is ComputedInfo;
        }

        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            DataStructureInfo info = (DataStructureInfo)conceptInfo;

            //System.Diagnostics.Debugger.Launch();
            codeBuilder.InsertCode(ImplementationCodeSnippet(info), ModuleCodeGenerator.DataStructureTag, info.Module);
            codeBuilder.InsertCode(string.Format(@"{0}: _{1}{0},
", info.Name, info.Module.Name), ModuleCodeGenerator.DataStructureReturnTag, info.Module);
        }

        private static string ImplementationCodeSnippet(DataStructureInfo info)
        {
            var hasID = IsEntityType(info);
            var IDInitializer = hasID ? "this.ID = data.ID || null;" : "";
            var IDField = hasID ?
@"{
    ""field"": ""ID"",
    ""type"": ""Guid""
   }," : "";

            return string.Format(@"
    function _{0}{1}(data){{
        data = data || {{}};
    
        {4}   
        {2}
    }};

    _{0}{1}.prototype.fields = [
        {5}
        {3}
    ];
    _{0}{1}.prototype.RESTResource = moduleRoot + ""/{1}"";

    _{0}{1}.prototype.attributes = {{
{6}
    }};
",
                info.Module.Name,
                info.Name,
                PropertiesConstructorTag.Evaluate(info),
                FieldsDescriptionsTag.Evaluate(info),
                IDInitializer,
                IDField,
                AttributesTag.Evaluate(info));
        }
    }
}
