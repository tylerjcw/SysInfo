using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace SysInfo
{
	/// <summary>
	/// Methods related to Network.
	/// </summary>
	public static class Network
	{
		/// <summary>
		/// Gets the external IP Address.
		/// </summary>
		/// <value>The external IP Address.</value>
		public static string ExternalIP
		{
			get
			{
				try
				{
					WebRequest request = WebRequest.Create("http://ipv4.icanhazip.com");
					using (var response = request.GetResponse())
					using (var sr = new StreamReader(response.GetResponseStream()))
					{
						return sr.ReadLine();
					}
				}
				catch (Exception e)
				{
					Console.WriteLine ("Error: " + e.Message);
					return "";
				}
			}
		}

		/// <summary>
		/// Wireless network.
		/// </summary>
		public static class Wireless
		{
			/// <summary>
			/// Gets a value indicating if wireless network is up.
			/// </summary>
			/// <value><c>true</c> if network is up; otherwise, <c>false</c>.</value>
			public static bool IsUp
			{
				get
				{
					try
					{
						foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
						{
							if (item.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && item.OperationalStatus == OperationalStatus.Up)
							{
								return true;
							}
						}

						return false;
					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return false;
					}
				}
			}

			/// <summary>
			/// Gets the interface name.
			/// </summary>
			/// <value>The interface name.</value>
			public static string Name
			{
				get
				{
					try
					{
						foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
						{
							if (item.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && item.OperationalStatus == OperationalStatus.Up)
							{
								return item.Name;
							}
						}

						return "";
					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return "";
					}
				}
			}

			/// <summary>
			/// Gets the Wireless SSID
			/// </summary>
			/// <value>The Wireless SSID</value>
			public static string SSID
			{
				get
				{
					try
					{
						using (var pr = new Process())
						{
							pr.StartInfo = new ProcessStartInfo 
							{
								FileName = "iwgetid",
								Arguments = "-r",
								RedirectStandardOutput = true,
								UseShellExecute = false,
							};

							pr.Start();

							return pr.StandardOutput.ReadLine();
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return "";
					}
				}
			}

			/// <summary>
			/// Gets the IP address.
			/// </summary>
			/// <value>The IP address.</value>
			public static string IPAddress
			{
				get
				{
					try
					{
						string output = "";

						foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
						{
							if (item.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && item.OperationalStatus == OperationalStatus.Up)
							{
								foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
								{
									if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
									{
										output =  ip.Address.ToString();
									}
								}
							}
						}

						return output;
					}
					catch (Exception e)
					{
						Console.WriteLine ("Error: {0}", e.Message);
						return "";
					}
				}
			}
		}

		/// <summary>
		/// Wired Network.
		/// </summary>
		public static class Wired
		{
			/// <summary>
			/// Gets the interface name.
			/// </summary>
			/// <value>The interface name.</value>
			public static string Name
			{
				get
				{
					try
					{
						foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
						{
							if (item.NetworkInterfaceType == NetworkInterfaceType.Ethernet && item.OperationalStatus == OperationalStatus.Up)
							{
								return item.Name;
							}
						}

						return "";
					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return "";
					}
				}
			}

			/// <summary>
			/// Gets a value indicating if wired network is up.
			/// </summary>
			/// <value><c>true</c> if network is up; otherwise, <c>false</c>.</value>
			public static bool IsUp
			{
				get
				{
					try
					{
						foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
						{
							if (item.NetworkInterfaceType == NetworkInterfaceType.Ethernet && item.OperationalStatus == OperationalStatus.Up)
							{
								return true;
							}
						}

						return false;
					}
					catch (Exception e)
					{
						Console.WriteLine("Error: " + e.Message);
						return false;
					}
				}
			}

			/// <summary>
			/// Gets the IP address.
			/// </summary>
			/// <value>The IP address.</value>
			public static string IPAddress
			{
				get
				{
					try
					{
						string output = "";

						foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
						{
							if (item.NetworkInterfaceType == NetworkInterfaceType.Ethernet && item.OperationalStatus == OperationalStatus.Up)
							{
								foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
								{
									if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
									{
										output =  ip.Address.ToString();
									}
								}
							}
						}

						return output;
					}
					catch (Exception e)
					{
						Console.WriteLine ("Error: {0}", e.Message);
						return "";
					}
				}
			}
		}
	}
}