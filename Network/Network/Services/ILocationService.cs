using System;

namespace Network
{
	public interface ILocationService
	{
		bool LocationAvailable { get; }
		double Latitude { get; }
		double Longitude { get; }

		void GetCurrentLatLong();
	}
}

