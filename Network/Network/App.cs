using System;
using MvvmCross.Platform.Plugins;
using MvvmCross.Platform.IoC;

namespace Network
{
	public class App : MvvmCross.Core.ViewModels.MvxApplication
	{
		public App ()
		{
		}

		public override void Initialize ()
		{
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();
			RegisterAppStart<MainViewModel> ();
		}

		public override void LoadPlugins (IMvxPluginManager pluginManager)
		{
			base.LoadPlugins (pluginManager);
		}
	}
}




