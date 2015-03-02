using System;
using System.Diagnostics;

namespace SysInfo
{
	/// <summary>
	/// Memory.
	/// </summary>
	public static class Memory
	{
		/// <summary>
		/// Gets the used memory (MB).
		/// </summary>
		/// <value>The used memory (MB).</value>
		public static double Used
		{
			get
			{
				try
				{
					using (var pc = new PerformanceCounter())
					{
						pc.CategoryName = "Memory";
						pc.CounterName = "Used Bytes";

						pc.NextValue();
						System.Threading.Thread.Sleep(1000);
						return Math.Round(pc.NextValue(), 2);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine ("Error: {0}", e.Message);
					return 0;
				}
			}
		}
	}
}

