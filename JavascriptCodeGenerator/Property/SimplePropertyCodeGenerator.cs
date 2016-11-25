using JavascriptModelGenerator.DefaultConcepts;
using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace JavascriptModelGenerator.Property
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(PropertyInfo))]
    class SimplePropertyCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public static readonly CsTag<PropertyInfo> AdditionalPropertiesTag = "AdditionalProperties";

        private static IDictionary<Type, string> supportedPropertyTypes = new Dictionary<Type, string>
        {
            { typeof(BinaryPropertyInfo), "byte[]" },
            { typeof(BoolPropertyInfo), "bool" },
            { typeof(DatePropertyInfo), "DateTime" },
            { typeof(DateTimePropertyInfo), "DateTime" },
            { typeof(DecimalPropertyInfo), "decimal" },
            { typeof(GuidPropertyInfo), "Guid" },
            { typeof(IntegerPropertyInfo), "int" },
            { typeof(LongStringPropertyInfo), "string" },
            { typeof(MoneyPropertyInfo), "decimal" },
            { typeof(ShortStringPropertyInfo), "string" },
            { typeof(ReferencePropertyInfo), "Guid" }
        };

        private static string GetPropertyType(PropertyInfo conceptInfo)
        {
            return supportedPropertyTypes
                .Where(prop => prop.Key.IsAssignableFrom(conceptInfo.GetType()))
                .Select(prop => prop.Value)
                .FirstOrDefault();
        }

        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (PropertyInfo)conceptInfo;
            var property = "";
            property = GetPropertyType(info);
            bool isreferenced = info is ReferencePropertyInfo;
            string name = isreferenced ? info.Name + "ID" : info.Name;

            if (!string.IsNullOrEmpty(property))
            {
                codeBuilder.InsertCode(ImplementationConstructorCodeSnippet(name), DataStructureCodeGenerator.PropertiesConstructorTag, info.DataStructure);
                codeBuilder.InsertCode(ImplementationDescriptionCodeSnippet(info, name, property), DataStructureCodeGenerator.FieldsDescriptionsTag, info.DataStructure);
            }
        }

        private string ImplementationConstructorCodeSnippet(string name)
        {
            return string.Format("this.{0} = data.{0} || null;" + Environment.NewLine, name);
        }

        private string ImplementationDescriptionCodeSnippet(PropertyInfo info, string name, string propertyType)
        {
            return string.Format(
@"{{
    ""title"": ""{0}"",
    ""type"": ""{1}"",
    {2}
}}, 
", CamelCaseTitle(name), propertyType, AdditionalPropertiesTag.Evaluate(info));
        }

        public static string CamelCaseTitle(string prop)
        {
            StringBuilder sb = new StringBuilder();

            if (prop.All(c => char.IsUpper(c)))
                return prop;

            bool lastWasLetter = false;
            foreach (char c in prop)
            {
                if (lastWasLetter && char.IsUpper(c))
                {
                    sb.Append(' ');
                    sb.Append(char.ToLower(c));
                }
                else if (c == '_')
                {
                    if (lastWasLetter)
                        sb.Append(' ');
                }
                else
                    sb.Append(c);

                lastWasLetter = char.IsLetter(c);
            }

            return sb.ToString();
        }
    }
}
