using System;
using MvvmCross.Core.ViewModels;

namespace Network
{
	public class MainViewModel : MvxViewModel
	{
		private readonly ILocationService _location;
		public MainViewModel (ILocationService location)
		{
			_location = location;			
		}

		public IMvxCommand NavigateSecondViewModel
		{
			get {
				return new MvxCommand (() => {
					ShowViewModel<SecondViewModel>();
				});
			}
		}
	}
}

