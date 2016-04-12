using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace Network
{
	public class SecondViewModel : MvxViewModel
	{
		private readonly ILocationService _location;
		private readonly IMvxMessenger _messenger;
		public SecondViewModel (ILocationService location,IMvxMessenger messenger)
		{
			_location = location;
			_messenger = messenger;

			Latitude = _location.Latitude;
			Longitude = _location.Longitude;
			_messenger.Subscribe<LocationUpdated> ((message)=>{
				Latitude = _location.Latitude;
				Longitude = _location.Longitude;
			});
		}

		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}

