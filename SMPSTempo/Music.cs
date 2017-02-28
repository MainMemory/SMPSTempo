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
			[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern bool InitializeDriver();
			[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern bool PlaySong(short song);
			[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern bool StopSong();
			[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern void FadeOutSong();
			[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern bool SetSongTempo(int pct);
			[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static unsafe extern IntPtr* GetCustomSongs(out uint count);
			[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern void RegisterSongStoppedCallback([MarshalAs(UnmanagedType.FunctionPtr)] Action callback);
			[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern void SetWaveLogPath([MarshalAs(UnmanagedType.LPStr)] string logfile);
			[DllImport("SMPSOUT", ExactSpelling = true, CharSet = CharSet.Auto)]
			public static extern void RegisterSongLoopCallback([MarshalAs(UnmanagedType.FunctionPtr)] Action callback);
		}

		static bool initsuccess;
		static List<string> songNames;

		internal static unsafe bool Init()
		{
			if (initsuccess) return true;
			if (!File.Exists("songs.ini")) return false;
			Dictionary<string, Dictionary<string, string>> ini = IniFile.Load("songs.ini");
			if (File.Exists("songs_SKC.ini"))
				ini = IniFile.Combine(ini, IniFile.Load("songs_SKC.ini"));
			songNames = new List<string>(IniSerializer.Deserialize<SongList>(ini).songs.Keys);
			string dir = Environment.CurrentDirectory;
			Environment.CurrentDirectory = Path.Combine(Environment.CurrentDirectory, "lib" + (IntPtr.Size == 8 ? "64" : "32"));
			try { NativeMethods.SetSongTempo(100); }
			catch
			{
				Environment.CurrentDirectory = dir;
				return false;
			}
			Environment.CurrentDirectory = dir;
			NativeMethods.SetWaveLogPath(DateTime.Now.ToString() + ".wav");
			NativeMethods.InitializeDriver();
			uint custcnt;
			IntPtr* p = NativeMethods.GetCustomSongs(out custcnt);
			for (uint i = 0; i < custcnt; i++)
				songNames.Add(Marshal.PtrToStringAnsi(*(p++)));
			return initsuccess = true;
		}

		public static ReadOnlyCollection<string> GetSongNames()
		{
			return new ReadOnlyCollection<string>(songNames);
		}

		public static void PlaySong(short song)
		{
			if (initsuccess)
				NativeMethods.PlaySong(song);
		}

		public static void StopSong()
		{
			if (initsuccess)
				NativeMethods.StopSong();
		}

		public static void FadeOutSong()
		{
			if (initsuccess)
				NativeMethods.FadeOutSong();
		}

		public static void SetTempo(int pct)
		{
			if (initsuccess)
				NativeMethods.SetSongTempo(pct);
		}

		public static void RegisterSongStoppedCallback(Action callback)
		{
			if (initsuccess)
				NativeMethods.RegisterSongStoppedCallback(callback);
		}

		public static void RegisterSongLoopCallback(Action callback)
		{
			if (initsuccess)
				NativeMethods.RegisterSongLoopCallback(callback);
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
