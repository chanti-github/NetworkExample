using System;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using Android.Content;

namespace Network.Droid
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext) : base(applicationContext)
		{

		}

		protected override IMvxApplication CreateApp()
		{
			return new App ();
		}

		public override void LoadPlugins (MvvmCross.Platform.Plugins.IMvxPluginManager pluginManager)
		{
			base.LoadPlugins (pluginManager);
		}
	}
}

