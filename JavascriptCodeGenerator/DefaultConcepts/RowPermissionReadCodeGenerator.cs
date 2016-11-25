﻿using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator.DefaultConcepts
{
    [Export(typeof(IJavascriptModelGeneratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(RowPermissionsReadInfo))]
    public class RowPermissionReadCodeGenerator : IJavascriptModelGeneratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (RowPermissionsReadInfo)conceptInfo;

            codeBuilder.InsertCode(String.Format(@"""hasRowPermissions"":true,
"), DataStructureCodeGenerator.AttributesTag, info.Source);
        }
    }
}
