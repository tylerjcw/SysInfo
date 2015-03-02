using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SysInfo
{
	/// <summary>
	/// Methods to retrieve Volume information.
	/// </summary>
	public static class Volume
	{
		const string VOLUME_FILE = "/proc/acpi/ibm/volume";

		/// <summary>
		/// Returns the current volume.
		/// </summary>
		/// <returns>Current volume..</returns>
		public static int CurrentVolume
		{
			get
			{
				try
					{
					using (var sr = new StreamReader(VOLUME_FILE))
					{
						decimal volume = Math.Round((Convert.ToDecimal(Regex.Match(sr.ReadToEnd(), "[0-9]+").Value) / 14) * 100, 0);
						return Convert.ToInt32(volume);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Error: " + e.Message);
					return 0;
				}
			}
		}

		/// <summary>
		/// Determines if volume is muted.
		/// </summary>
		/// <returns><c>true</c> if volume is muted; otherwise, <c>false</c>.</returns>
		public static bool Muted
		{
			get
			{
				try
				{
					using (var sr = new StreamReader(VOLUME_FILE))
					{
						return (Regex.Match(sr.ReadToEnd(), "(on|off)").Value == "on");
					}
				}
				catch (Exception e)
				{
					Console.WriteLine ("Error: " + e.Message);
					return false;
				}
			}
		}
	}
}

