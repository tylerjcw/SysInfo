using System;
using System.IO;

namespace SysInfo
{
	/// <summary>
	/// Contains methods to retrieve information about bsystem power sources.
	/// </summary>
	public static class Power
	{
		/// <summary>
		/// Gets the power source.
		/// </summary>
		/// <value>The power source.</value>
		public static string Source
		{
			get
			{
				try
				{
					using (var sr = new StreamReader("/sys/devices/platform/smapi/ac_connected"))
					{
						if ((sr.ReadLine() == "1"))
						{
							return "ac";
						}
						else
						{
							return "battery";
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Error: " + e.Message);
					return null;
				}
			}
		}

		/// <summary>
		/// Methods to retrieve information about Battery.
		/// </summary>
		public static class Battery
		{
			private const string BATTERY_DIR = "/sys/devices/platform/smapi/BAT0/";

			/// <summary>
			/// Gets the percent remaining.
			/// </summary>
			/// <value>The percent remaining.</value>
			public static int? PercentRemaining
			{
				get
				{
					try
					{
						using (var sr = new StreamReader(BATTERY_DIR + "remaining_percent"))
						{
							return Convert.ToInt32(sr.ReadLine());
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return null;
					}
				}
			}

			/// <summary>
			/// Gets a value indicating whether this <see cref="SysInfo.Power.Battery"/> is charging.
			/// </summary>
			/// <value><c>true</c> if charging; otherwise, <c>false</c>.</value>
			public static int? State
			{
				get
				{
					try
					{
						using (var sr = new StreamReader(BATTERY_DIR + "state"))
						{
							switch (sr.ReadLine ())
							{
							case "charging":
								return 1;
							case "discharging":
								return 2;
							case "idle":
								return 3;
							default:
								return 0;
							}
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return null;
					}
				}
			}

			/// <summary>
			/// Gets a value indicating whether this <see cref="SysInfo.Power.Battery"/> is installed.
			/// </summary>
			/// <value><c>true</c> if installed; otherwise, <c>false</c>.</value>
			public static bool? Installed
			{
				get
				{
					try
					{
						using (var sr = new StreamReader(BATTERY_DIR + "installed"))
						{
							return (sr.ReadLine() == "1");
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return null;
					}
				}
			}

			/// <summary>
			/// Gets the battery chemistry.
			/// </summary>
			/// <value>The battery chemistry.</value>
			public static string Chemistry
			{
				get
				{
					try
					{
						using (var sr = new StreamReader(BATTERY_DIR + "chemistry"))
						{
							return sr.ReadLine();
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return null;
					}
				}
			}

			/// <summary>
			/// Gets the battery manufacturer.
			/// </summary>
			/// <value>The battery manufacturer.</value>
			public static string Manufacturer
			{
				get
				{
					try
					{
						using (var sr = new StreamReader(BATTERY_DIR + "manufacturer"))
						{
							return sr.ReadLine();
						}
 					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return null;
					}
				}
			}

			/// <summary>
			/// Gets the battery model.
			/// </summary>
			/// <value>The battery model.</value>
			public static string Model
			{
				get
				{
					try
					{
						using (var sr = new StreamReader(BATTERY_DIR + "model"))
						{
							return sr.ReadLine();
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return null;
					}
				}
			}

			/// <summary>
			/// Gets the battery serial.
			/// </summary>
			/// <value>The battery serial.</value>
			public static string Serial
			{
				get
				{
					try
					{
						using (var sr = new StreamReader(BATTERY_DIR + "serial"))
						{
							return sr.ReadLine();
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return null;
					}
				}
			}

			/// <summary>
			/// Gets the battery temperature.
			/// </summary>
			/// <value>The battery temperature.</value>
			public static double? Temperature
			{
				get
				{
					try
					{
						using (var sr = new StreamReader(BATTERY_DIR + "temperature"))
						{
							return Convert.ToDouble(sr.ReadLine());
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return null;
					}
				}
			}

			/// <summary>
			/// Gets the battery voltage.
			/// </summary>
			/// <value>The battery voltage.</value>
			public static double? Voltage
			{
				get
				{
					try
					{
						using (var sr = new StreamReader(BATTERY_DIR + "voltage"))
						{
							return Convert.ToDouble(sr.ReadLine());
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return null;
					}
				}
			}
		}
	}
}