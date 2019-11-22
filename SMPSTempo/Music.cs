using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices;

namespace SMPSTempo
{
	public static class Music
	{
		private static class NativeMethods
		{
			[DllImport("SMPSPlay", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern bool SMPS_InitializeDriver();
			[DllImport("SMPSPlay", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern bool SMPS_DeInitializeDriver();
			[DllImport("SMPSPlay", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern bool SMPS_LoadAndPlaySong(short song);
			[DllImport("SMPSPlay", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern bool SMPS_StopSong();
			[DllImport("SMPSPlay", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern void SMPS_FadeOutSong();
			[DllImport("SMPSPlay", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern bool SMPS_SetSongTempo(double multiplier);
			[DllImport("SMPSPlay", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static unsafe extern IntPtr* SMPS_GetSongNames(out uint count);
			[DllImport("SMPSPlay", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern void SMPS_RegisterSongStoppedCallback([MarshalAs(UnmanagedType.FunctionPtr)] Action callback);
			[DllImport("SMPSPlay", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern void SMPS_SetWaveLogPath([MarshalAs(UnmanagedType.LPStr)] string logfile);
			[DllImport("SMPSPlay", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern void SMPS_RegisterSongLoopCallback([MarshalAs(UnmanagedType.FunctionPtr)] Action callback);
		}

		static bool initsuccess;
		static List<string> songNames;

		internal static unsafe bool Init()
		{
			if (initsuccess) return true;
			songNames = new List<string>();
			string dir = Environment.CurrentDirectory;
			Environment.CurrentDirectory = Path.Combine(Environment.CurrentDirectory, "lib" + (IntPtr.Size == 8 ? "64" : "32"));
			try { NativeMethods.SMPS_SetSongTempo(1); }
			catch
			{
				Environment.CurrentDirectory = dir;
				return false;
			}
			Environment.CurrentDirectory = dir;
			NativeMethods.SMPS_SetWaveLogPath(DateTime.Now.ToString() + ".wav");
			NativeMethods.SMPS_InitializeDriver();
			uint custcnt;
			IntPtr* p = NativeMethods.SMPS_GetSongNames(out custcnt);
			for (uint i = 0; i < custcnt; i++)
				songNames.Add(Marshal.PtrToStringAnsi(*(p++)));
			return initsuccess = true;
		}

		internal static void DeInit()
		{
			NativeMethods.SMPS_DeInitializeDriver();
		}

		public static ReadOnlyCollection<string> GetSongNames()
		{
			return new ReadOnlyCollection<string>(songNames);
		}

		public static void PlaySong(short song)
		{
			if (initsuccess)
				NativeMethods.SMPS_LoadAndPlaySong(song);
		}

		public static void StopSong()
		{
			if (initsuccess)
				NativeMethods.SMPS_StopSong();
		}

		public static void FadeOutSong()
		{
			if (initsuccess)
				NativeMethods.SMPS_FadeOutSong();
		}

		public static void SetTempo(int pct)
		{
			if (initsuccess)
				NativeMethods.SMPS_SetSongTempo(pct);
		}

		public static void RegisterSongStoppedCallback(Action callback)
		{
			if (initsuccess)
				NativeMethods.SMPS_RegisterSongStoppedCallback(callback);
		}

		public static void RegisterSongLoopCallback(Action callback)
		{
			if (initsuccess)
				NativeMethods.SMPS_RegisterSongLoopCallback(callback);
		}
	}

	class SongList
	{
		public int residstart { get; set; }
		[IniCollection(IniCollectionMode.IndexOnly)]
		public Dictionary<string, SongInfo> songs { get; set; }
	}

	class SongInfo
	{
		public string Type { get; set; }
		public string Offset { get; set; }
		public string File { get; set; }
	}
}
