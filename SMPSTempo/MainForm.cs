using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Forms;

namespace SMPSTempo
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		Action SongStoppedCallbackDelegate, SongLoopCallbackDelegate;

		private void Form1_Load(object sender, EventArgs e)
		{
			if (!Music.Init())
			{
				MessageBox.Show("Failed to initialize music.");
				Close();
			}
			else
			{
				ReadOnlyCollection<string> names = Music.GetSongNames();
				songSelector.BeginUpdate();
				foreach (string name in names)
				{
					StringBuilder sb = new StringBuilder(name.Length);
					sb.Append(name[0]);
					bool skip = false;
					for (int i = 1; i < name.Length - 1; i++)
					{
						if (!skip && (char.IsDigit(name, i) || char.IsUpper(name, i)) && char.IsLower(name, i + 1))
							sb.Append(' ');
						sb.Append(name[i]);
						if (char.IsLower(name, i) && (char.IsDigit(name, i + 1) || char.IsUpper(name, i + 1)))
						{
							sb.Append(' ');
							skip = true;
						}
						else
							skip = false;
					}
					sb.Append(name[name.Length - 1]);
					songSelector.Items.Add(sb.ToString());
				}
				songSelector.EndUpdate();
				songSelector.SelectedIndex = names.IndexOf("SpecialStage");
				SongStoppedCallbackDelegate = SongStoppedCallback;
				Music.RegisterSongStoppedCallback(SongStoppedCallbackDelegate);
				SongLoopCallbackDelegate = SongLoopCallback;
				Music.RegisterSongLoopCallback(SongLoopCallbackDelegate);
				tempotimer.SynchronizingObject = this;
				tempotimer.Elapsed += tempotimer_Elapsed;
				timecounttimer.SynchronizingObject = this;
				timecounttimer.Elapsed += timecounttimer_Elapsed;
			}
		}

		bool started = false;
		int currenttempo;
		int endtempo;
		int tempochange;
		int loopcount;
		int loopmax;
		bool fadeout;
		readonly System.Diagnostics.Stopwatch playtime = new System.Diagnostics.Stopwatch();
		readonly System.Timers.Timer tempotimer = new System.Timers.Timer() { AutoReset = true };
		readonly System.Timers.Timer timecounttimer = new System.Timers.Timer(500) { AutoReset = true };

		private void startStopButton_Click(object sender, EventArgs e)
		{
			songSelector.Enabled = startTempoControl.Enabled = endTempoControl.Enabled =
				changeAmountControl.Enabled = changeDelayControl.Enabled =
				fadeAtEndCheckBox.Enabled = loopMaxControl.Enabled = started;
			if (started)
			{
				started = false;
				startStopButton.Text = "Start";
				tempotimer.Stop();
				timecounttimer.Stop();
				tempoLabel.Text = "Current Tempo: Stopped";
				if (sender != null)
					Music.StopSong();
			}
			else
			{
				started = true;
				startStopButton.Text = "Stop";
				Music.PlaySong((short)songSelector.SelectedIndex);
				currenttempo = (int)startTempoControl.Value;
				Music.SetTempo(currenttempo);
				endtempo = (int)endTempoControl.Value;
				fadeout = fadeAtEndCheckBox.Checked;
				loopcount = 0;
				loopmax = (int)loopMaxControl.Value;
				tempochange = (int)changeAmountControl.Value;
				if (currenttempo > endtempo)
					tempochange = -tempochange;
				tempotimer.Interval = (double)(changeDelayControl.Value * 1000);
				playtime.Reset();
				playtime.Start();
				if (currenttempo != endtempo)
					tempotimer.Start();
				tempoLabel.Text = string.Format("Current Tempo: {0} ({1:P})", currenttempo, 100d / currenttempo);
				timecounttimer.Start();
				playTimeLabel.Text = "Play Time: 0s";
			}
		}

		void tempotimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			currenttempo += tempochange;
			switch (Math.Sign(tempochange))
			{
				case -1:
					if (currenttempo <= endtempo)
					{
						currenttempo = endtempo;
						tempotimer.Stop();
					}
					break;
				case 1:
					if (currenttempo >= endtempo)
					{
						currenttempo = endtempo;
						tempotimer.Stop();
					}
					break;
			}
			Music.SetTempo(currenttempo);
			tempoLabel.Text = string.Format("Current Tempo: {0} ({1:P})", currenttempo, 100d / currenttempo);
		}

		void timecounttimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			StringBuilder sb = new StringBuilder("Play Time: ");
			TimeSpan time = playtime.Elapsed;
			if ((int)time.TotalHours > 0)
			{
				sb.Append((int)time.TotalHours);
				sb.Append("h");
			}
			if (time.Minutes > 0)
			{
				sb.Append(time.Minutes);
				sb.Append("m");
			}
			if (time.TotalSeconds < 1 || time.Seconds > 0)
			{
				sb.Append(time.Seconds);
				sb.Append("s");
			}
			playTimeLabel.Text = sb.ToString();
		}

		void SongStoppedCallback()
		{
			if (started)
				Invoke(new Action<object, EventArgs>(startStopButton_Click), null, EventArgs.Empty);
		}

		void SongLoopCallback()
		{
			if (fadeout && currenttempo == endtempo && loopcount++ >= loopmax)
				Music.FadeOutSong();
		}
	}
}
