using Autofac;
using System.ComponentModel.Composition;

namespace JavascriptModelGenerator
{
    [Export(typeof(Module))]
    public class JavaScriptModelGeneratorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Rhetos.Extensibility.Plugins.FindAndRegisterPlugins<IJavascriptModelGeneratorPlugin>(builder);

            base.Load(builder);
        }
    }
}
