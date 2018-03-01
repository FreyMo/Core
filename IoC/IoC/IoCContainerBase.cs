namespace Core.IoC
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using Common.ArgumentMust;
	using Common.Extensions;
	using Definitions.Container;
	using Definitions.Module;

	public abstract class IoCContainerBase : IIoCContainerBase
	{
		public void Load(IIoCModule module)
		{
			ArgumentMust.NotBeNull(() => module);

			module.Load();
		}

		public void Load(IEnumerable<IIoCModule> modules)
		{
			ArgumentMust.NotBeNull(() => modules);
			ArgumentMust.NotContainNull(() => modules);

			modules.ForEach(module => module.Load());
		}

		public void Load(IEnumerable<Assembly> assemblies)
		{
			var moduleTypes = assemblies.Where(assembly => !assembly.IsDynamic)
			                            .SelectMany(x => x.GetExportedTypes().Where(y => y.IsSubclassOf(typeof(IoCModuleBase))))
			                            .ToList();

			var modules = moduleTypes.Select(type => Activator.CreateInstance(type, this).Cast<IIoCModule>())
			                         .ToList();

			Load(modules);
		}
	}
}