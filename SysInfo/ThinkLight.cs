using System;
using System.IO;
using Mono.Unix.Native;

namespace SysInfo
{
	/// <summary>
	/// ThinkLight
	/// </summary>
	public static class ThinkLight
	{
		const string LIGHT_FILE = "/proc/acpi/ibm/light";

		/// <summary>
		/// Enable the ThinkLight.
		/// </summary>
		public static void Enable()
		{
			try
			{
				if (Syscall.seteuid(0) != 0)
				{
					return;
				}
				else
				{
					using (var sw = new StreamWriter(LIGHT_FILE))
					{
						sw.WriteLine("on");
					}
					Syscall.setuid(Syscall.getuid());
				}
			}
			catch (Exception e)
			{
				Console.WriteLine ("Error: " + e.Message);
			}
		}

		/// <summary>
		/// Disable the ThinkLight.
		/// </summary>
		public static void Disable()
		{
			try
			{
				if (Syscall.seteuid(0) != 0)
				{
					return;
				}
				else
				{
					using (var sw = new StreamWriter(LIGHT_FILE))
					{
						sw.WriteLine("off");
					}
					Syscall.setuid(Syscall.getuid());
				}
			}
			catch (Exception e)
			{
				Console.WriteLine ("Error: " + e.Message);
			}
		}

		/// <summary>
		/// Toggle the ThinkLight.
		/// </summary>
		public static void Toggle()
		{
			if (Enabled)
			{
				Disable();
				return;
			}
			else if (!Enabled)
			{
				Enable();
				return;
			}
		}

		/// <summary>
		/// Determines whether the ThinkLight is enabled.
		/// </summary>
		/// <returns><c>true</c> if the ThinkLight is enabled; otherwise, <c>false</c>.</returns>
		public static bool Enabled
		{
			get
			{
				try
				{
					using (var sr = new StreamReader(LIGHT_FILE))
					{
						return (sr.ReadLine() == "status:\t\ton");
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