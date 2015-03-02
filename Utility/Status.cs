using System;
using SysInfo;

namespace Utility
{
	public class SysInfo
	{
		/// <summary>
		/// Gets the power logo.
		/// </summary>
		/// <returns>String representing the power logo (formatted for bar).</returns>
		static string GetPowerLogo()
		{
			int battery = (int)Power.Battery.PercentRemaining;

			switch (Power.Battery.State)
			{
				case 1:
					if (battery <= 25)
						return Config.Charger25;
					if ((battery > 25) && (battery <= 50))
						return Config.Charger50;
					if ((battery > 50) && (battery <= 75))
						return Config.Charger75;
					if ((battery > 75) && (battery <= 100))
						return Config.Charger100;
					break;
				case 2:
					if (battery <= 25)
						return Config.Battery25;
					if ((battery > 25) && (battery <= 50))
						return Config.Battery50;
					if ((battery > 50) && (battery <= 75))
						return Config.Battery75;
					if ((battery > 75) && (battery <= 100))
						return Config.Battery100;
					break;
				case 3:
					return Config.OnlyAC;
				case 0:
				default:
					return Config.Error;
			}

			return Config.Error;
		}

		static string GetPercentRemaining()
		{
			if ((bool)Power.Battery.Installed)
				return String.Format("{0}%", Power.Battery.PercentRemaining);
			else
				return "---%";
		}

		/// <summary>
		/// Gets the volume logo.
		/// </summary>
		/// <returns>String representing the volume logo (formatted for bar).</returns>
		static string GetVolumeLogo()
		{
			int volume = Volume.CurrentVolume;

			if (Volume.Muted)
				return Config.VolumeMute;
			if (volume <= 25)
				return Config.Volume25;
			if ((volume > 25) && (volume <= 50))
				return Config.Volume50;
			if ((volume > 50) && (volume <= 75))
				return Config.Volume75;
			if ((volume > 75) && (volume <= 100))
				return Config.Volume100;
							return Config.Error;
		}

		/// <summary>
		/// Gets the network logo.
		/// </summary>
		/// <returns>String representing the network logo (formatted for bar).</returns>
		static string GetNetLogo()
		{
			if (Network.Wireless.IsUp && !Network.Wired.IsUp)
				return Config.Wireless;
			if (Network.Wireless.IsUp && Network.Wired.IsUp)
				return Config.BothNet;
			if (!Network.Wireless.IsUp && Network.Wired.IsUp)
				return Config.Wired;

				return Config.Error;
		}

		/// <summary>
		/// Gets the network text.
		/// </summary>
		/// <returns>The network text, either SSID or Internal IP</returns>
		static string GetNetText()
		{
			if (Network.Wireless.IsUp && !Network.Wireless.SSID.Equals(String.Empty))
				return Network.Wireless.SSID.Equals("Wendy_WLAN_EXT") ? "Wendy's" : Network.Wireless.SSID;
			if (Network.Wired.IsUp && !Network.Wireless.IsUp)
				return Network.Wired.IPAddress;

				return "n/a";
		}

		/// <summary>
		/// Gets the pacman logo.
		/// </summary>
		/// <returns>String representing the pacman logo (formatted for bar).</returns>
		static string GetPacmanLogo()
		{
			if ((Updates.Official.Count > 0) || (Updates.AUR.Count > 0))
				return Config.Updates;

				return Config.NoUpdates;
		}

		public static void Main()
		{
			int i = 0;

			while (true)
			{
				if (i++ == Config.RunTimes)
					break;

				//Format the different pieces of information for final display
				string network = String.Format ("{0} {1}", GetNetLogo (), GetNetText ());
				//string cpu     = String.Format ("{0} {1}%%", cpuLogo, Processor.Usage);
				string release = String.Format ("{0}{1} {2}{3}", Config.sysClick, Config.Arch, Kernel.Release, Config.endClick);
				string power = String.Format ("{0} {1:000}%%", GetPowerLogo (), GetPercentRemaining ());
				string updates = String.Format ("{0}{1} {2:00}/{3:00}{4}", Config.updClick, GetPacmanLogo (), Updates.Official.Count, Updates.AUR.Count, Config.endClick);
				string volume  = String.Format ("{0}{1} {2:000}%%{3}", Config.volClick, GetVolumeLogo(), Volume.CurrentVolume, Config.endClick);
				string time    = String.Format ("{0}{1} {2}{3}", Config.calClick, Config.Clock, DateTime.Now.ToShortTimeString (), Config.endClick);

				//piece together the different segments and print the final result to StdOut
				string output = String.Format ("%{{r}}{0} | {1} | {2} | {3} | {4} | {5} ", network, release, power, updates, volume, time);
				Console.WriteLine ("{0}", output);

				System.Threading.Thread.Sleep (1000);
			}
		}
	}
}

