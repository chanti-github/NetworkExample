using System;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;

namespace Network
{
	public class LocationService : ILocationService
	{
		#region Member Variables
		private readonly IMvxMessenger _messenger;
		private  IMvxLocationWatcher _location;
		MvxLocationOptions options;
		#endregion

		#region ctors
		public LocationService(IMvxMessenger messenger, IMvxLocationWatcher  location)
		{
			_messenger = messenger;
			_location = location;
			LocationAvailable = false;
			options = new MvxLocationOptions(){
				Accuracy = MvxLocationAccuracy.Fine,
				TrackingMode = MvxLocationTrackingMode.Background
			};
			if (!_location.Started) {
				InitializeLocation (options);
			}
		}
		#endregion
		private DateTime _locationAcquired = DateTime.MinValue;
		void InitializeLocation(MvxLocationOptions locationOptions)
		{
			_location.Start(locationOptions, onLocation, onError);
		}

		public void onLocation(MvxGeoLocation location) {
			if ((DateTime.Now - _locationAcquired).TotalSeconds > 60) {
				this.Latitude = location.Coordinates.Latitude;
				this.Longitude = location.Coordinates.Longitude;

				LocationAvailable = true;
				_locationAcquired = DateTime.Now;
				_messenger.Publish<LocationUpdated> (new LocationUpdated (this));
			}
		}

		public void onError(MvxLocationError error) {
			if (options.Accuracy == MvxLocationAccuracy.Fine && (DateTime.Now - _locationAcquired).TotalSeconds > 30)
			{
				if(_location.Started){
					return;
				}				
				_location.Stop();
				options.Accuracy = MvxLocationAccuracy.Coarse;
				InitializeLocation(options);
			}
			if ((DateTime.Now - _locationAcquired).TotalSeconds > 30)
			{
				LocationAvailable = false;
			}
		}

		#region Properties
		public bool LocationAvailable { get; private set; }

		public double Latitude { get; private set; }

		public double Longitude { get; private set; }
		#endregion

		#region Methods
		public void GetCurrentLatLong()
		{
			if(_location.Started){
				return;
			}
			_location.Stop();
			options = new MvxLocationOptions(){
				Accuracy = MvxLocationAccuracy.Fine,
				TrackingMode = MvxLocationTrackingMode.Background
			};
			InitializeLocation(options);
		}
		#endregion
	}
}

