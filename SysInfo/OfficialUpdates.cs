using System;
using System.IO;
using System.Diagnostics;

namespace SysInfo
{
	/// <summary>
	/// Updates.
	/// </summary>
	public static partial class Updates
	{
		/// <summary>
		/// Official Repos
		/// </summary>
		public static class Official
		{
			/// <summary>
			/// Refresh the package database.
			/// </summary>
			/// <value><c>true</c> if successful; otherwise, <c>false</c>.</value>
			public static bool Refresh()
			{
				try
				{
					using (var pr = new Process())
					{
						pr.StartInfo = new ProcessStartInfo
						{
							FileName = "sudo",
							Arguments = "pacman -Sy",
							RedirectStandardOutput = true,
							UseShellExecute = false,
						};

						return pr.Start();
					}
				}
				catch (Exception e)
				{
					Console.WriteLine ("Error: " + e.Message);
					return false;
				}
			}

			/// <summary>
			/// Update any packages available
			/// </summary>
			/// <value><c>true</c> if successful; otherwise, <c>false</c>.</value>
			public static bool Update()
			{
				try
				{
					using (var pr = new Process())
					{
						pr.StartInfo = new ProcessStartInfo
						{
							FileName = "sudo",
							Arguments = "pacman -Syu --noconfirm",
							RedirectStandardOutput = false,
							UseShellExecute = true,
						};

						bool success = pr.Start();
						pr.WaitForExit();
						return success;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine ("Error: " + e.Message);
					return false;
				}
			}

			/// <summary>
			/// Gets the update count.
			/// </summary>
			/// <value>The update count.</value>
			public static int Count
			{
				get
				{
					try
					{
						const string updateFile = "/home/komrade/log/updates.log";

						using (var sr = new StreamReader(updateFile))
						{
							return Convert.ToInt32(sr.ReadLine());
						}
					}
					catch (Exception e)
					{
						Console.WriteLine ("Error: " + e.Message);
						return 0;
					}
				}
			}
		}
	}
}