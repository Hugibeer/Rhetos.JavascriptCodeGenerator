using Rhetos.Compiler;
using System.Collections.Generic;

namespace JavascriptModelGenerator
{
    public class JavaScriptSource : IAssemblySource
    {
        public string GeneratedCode { get; set; }

        public IEnumerable<string> RegisteredReferences { get; set; }
    }
}
