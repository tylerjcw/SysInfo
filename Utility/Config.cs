namespace Utility
{
	public static class Config
	{
		public const int RunTimes      = -1; // set to a negative value for infinite times

		public const string CPU        = "%{T2}%{F#FF6095C5}%{F-}%{T1}"; // CPU Icon
		public const string Arch       = "%{T2}%{F#FF6095C5}%{F-}%{T1}"; // ArchLinux Icon
		public const string Clock      = "%{T2}%{F#FF6095C5}%{F-}%{T1}"; // Clock Icon

		public const string Updates    = "%{T2}%{F#FFEFBD8B}%{F-}%{T1}"; // Pacman icon to display when there are updates
		public const string NoUpdates  = "%{T2}%{F#FF6095C5}%{F-}%{T1}"; // Pacman icon to display when there are no updates

		public const string Error      = "%{T2}%{F#FFD370A3}%{F-}%{T1}"; // Error Icon

		public const string OnlyAC     = "%{T2}%{F#FFEFBD8B}%{F-}%{T1}"; // Direct AC icon

		public const string Battery25  = "%{T2}%{F#FFD370A3}%{F-}%{T1}"; // Battery <= 25%
		public const string Battery50  = "%{T2}%{F#FFEFBD8B}%{F-}%{T1}"; // 25% < Battery <= 50%
		public const string Battery75  = "%{T2}%{F#FF6D9E3F}%{F-}%{T1}"; // 50% < Battery <= 75%
		public const string Battery100 = "%{T2}%{F#FF6095C5}%{F-}%{T1}"; // 75% < Battery <= 100%

		public const string Charger25  = "%{T2}%{F#FFD370A3}%{F-}%{T1}";
		public const string Charger50  = "%{T2}%{F#FFEFBD8B}%{F-}%{T1}";
		public const string Charger75  = "%{T2}%{F#FF6D9E3F}%{F-}%{T1}";
		public const string Charger100 = "%{T2}%{F#FF6095C5}%{F-}%{T1}";

		public const string VolumeMute = "%{T2}%{F#FFD370A3}%{F-}%{T1}";
		public const string Volume25   = "%{T2}%{F#FFD370A3}%{F-}%{T1}";
		public const string Volume50   = "%{T2}%{F#FFEFBD8B}%{F-}%{T1}";
		public const string Volume75   = "%{T2}%{F#FF6D9E3F}%{F-}%{T1}";
		public const string Volume100  = "%{T2}%{F#FF6095C5}%{F-}%{T1}";

		public const string Wireless   = "%{T2}%{F#FF6D9E3F}%{F-}%{T1}";
		public const string Wired      = "%{T2}%{F#FF6095C5}%{F-}%{T1}";
		public const string BothNet    = "%{T2}%{F#FF6095C5}%{F-}%{T1}";

		public const string endClick   = "%{A}";
		public const string calClick   = "%{A:/home/komrade/etc/dwm/dzenCal.sh:}";
		public const string updClick   = "%{A:/home/komrade/etc/dwm/dzenPacman.sh:}";
		public const string sysClick   = "%{A:/home/komrade/etc/dwm/dzenSysinfo.sh:}";
		public const string volClick   = "%{A:pavucontrol:}";
	}
}

