using System;
using System.IO;
using System.Diagnostics;

namespace SysInfo
{
	/// <summary>
	/// Kernel.
	/// </summary>
	public static class Kernel
	{
		/// <summary>
		/// Gets the kernel release.
		/// </summary>
		/// <value>The kernel release version.</value>
		public static string Release
		{
			get
			{
				try
				{
					using (var pr = new Process())
					{
						pr.StartInfo = new ProcessStartInfo
						{
							FileName = "uname",
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
					Console.WriteLine ("Error: {0}", e.Message);
					return "";
				}
			}
		}
	}
}

