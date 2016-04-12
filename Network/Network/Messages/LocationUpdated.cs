using System;
using MvvmCross.Plugins.Messenger;

namespace Network
{
	public class LocationUpdated : MvxMessage
	{
		public string Message { get; set; }
		public LocationUpdated(object sender) : base(sender)
		{

		}
	}
}

