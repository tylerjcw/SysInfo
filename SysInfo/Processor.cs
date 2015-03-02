using System;
using System.Diagnostics;

namespace SysInfo
{
	/// <summary>
	/// Processor.
	/// </summary>
	public static class Processor
	{
		/// <summary>
		/// Gets the processor usage %.
		/// </summary>
		/// <value>The usage %.</value>
		public static double Usage
		{
			get
			{
				try
				{
					using (var pc = new PerformanceCounter ())
					{
						pc.CategoryName = "Processor";
						pc.CounterName = "% Processor Time";
						pc.InstanceName = "_Total";

						pc.NextValue ();
						System.Threading.Thread.Sleep (250);
						return Math.Round(pc.NextValue (), 2);
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

