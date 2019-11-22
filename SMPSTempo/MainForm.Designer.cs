namespace SMPSTempo
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label6;
			this.songSelector = new System.Windows.Forms.ComboBox();
			this.startTempoControl = new System.Windows.Forms.NumericUpDown();
			this.endTempoControl = new System.Windows.Forms.NumericUpDown();
			this.changeAmountControl = new System.Windows.Forms.NumericUpDown();
			this.changeDelayControl = new System.Windows.Forms.NumericUpDown();
			this.startStopButton = new System.Windows.Forms.Button();
			this.tempoLabel = new System.Windows.Forms.Label();
			this.playTimeLabel = new System.Windows.Forms.Label();
			this.fadeAtEndCheckBox = new System.Windows.Forms.CheckBox();
			this.loopMaxControl = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.startTempoControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.endTempoControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.changeAmountControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.changeDelayControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.loopMaxControl)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(35, 13);
			label1.TabIndex = 0;
			label1.Text = "Song:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(12, 41);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(32, 13);
			label2.TabIndex = 2;
			label2.Text = "Start:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(121, 41);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 13);
			label3.TabIndex = 4;
			label3.Text = "End:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(12, 67);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(86, 13);
			label4.TabIndex = 6;
			label4.Text = "Change Amount:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(175, 67);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(77, 13);
			label5.TabIndex = 8;
			label5.Text = "Change Delay:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(196, 93);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(38, 13);
			label6.TabIndex = 13;
			label6.Text = "loop(s)";
			// 
			// songSelector
			// 
			this.songSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.songSelector.FormattingEnabled = true;
			this.songSelector.Location = new System.Drawing.Point(53, 12);
			this.songSelector.Name = "songSelector";
			this.songSelector.Size = new System.Drawing.Size(183, 21);
			this.songSelector.TabIndex = 1;
			// 
			// startTempoControl
			// 
			this.startTempoControl.Location = new System.Drawing.Point(50, 39);
			this.startTempoControl.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
			this.startTempoControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.startTempoControl.Name = "startTempoControl";
			this.startTempoControl.Size = new System.Drawing.Size(65, 20);
			this.startTempoControl.TabIndex = 3;
			this.startTempoControl.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// endTempoControl
			// 
			this.endTempoControl.Location = new System.Drawing.Point(156, 39);
			this.endTempoControl.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
			this.endTempoControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.endTempoControl.Name = "endTempoControl";
			this.endTempoControl.Size = new System.Drawing.Size(65, 20);
			this.endTempoControl.TabIndex = 5;
			this.endTempoControl.Value = new decimal(new int[] {
            68,
            0,
            0,
            0});
			// 
			// changeAmountControl
			// 
			this.changeAmountControl.Location = new System.Drawing.Point(104, 65);
			this.changeAmountControl.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
			this.changeAmountControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.changeAmountControl.Name = "changeAmountControl";
			this.changeAmountControl.Size = new System.Drawing.Size(65, 20);
			this.changeAmountControl.TabIndex = 7;
			this.changeAmountControl.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// changeDelayControl
			// 
			this.changeDelayControl.DecimalPlaces = 2;
			this.changeDelayControl.Location = new System.Drawing.Point(258, 65);
			this.changeDelayControl.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
			this.changeDelayControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.changeDelayControl.Name = "changeDelayControl";
			this.changeDelayControl.Size = new System.Drawing.Size(74, 20);
			this.changeDelayControl.TabIndex = 9;
			this.changeDelayControl.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			// 
			// startStopButton
			// 
			this.startStopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startStopButton.Location = new System.Drawing.Point(12, 117);
			this.startStopButton.Name = "startStopButton";
			this.startStopButton.Size = new System.Drawing.Size(320, 61);
			this.startStopButton.TabIndex = 14;
			this.startStopButton.Text = "Start";
			this.startStopButton.UseVisualStyleBackColor = true;
			this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
			// 
			// tempoLabel
			// 
			this.tempoLabel.AutoSize = true;
			this.tempoLabel.Location = new System.Drawing.Point(12, 185);
			this.tempoLabel.Name = "tempoLabel";
			this.tempoLabel.Size = new System.Drawing.Size(123, 13);
			this.tempoLabel.TabIndex = 15;
			this.tempoLabel.Text = "Current Tempo: Stopped";
			// 
			// playTimeLabel
			// 
			this.playTimeLabel.AutoSize = true;
			this.playTimeLabel.Location = new System.Drawing.Point(12, 207);
			this.playTimeLabel.Name = "playTimeLabel";
			this.playTimeLabel.Size = new System.Drawing.Size(70, 13);
			this.playTimeLabel.TabIndex = 16;
			this.playTimeLabel.Text = "Play Time: 0s";
			// 
			// fadeAtEndCheckBox
			// 
			this.fadeAtEndCheckBox.AutoSize = true;
			this.fadeAtEndCheckBox.Location = new System.Drawing.Point(3, 92);
			this.fadeAtEndCheckBox.Name = "fadeAtEndCheckBox";
			this.fadeAtEndCheckBox.Size = new System.Drawing.Size(130, 17);
			this.fadeAtEndCheckBox.TabIndex = 11;
			this.fadeAtEndCheckBox.Text = "Fade Out At End After";
			this.fadeAtEndCheckBox.UseVisualStyleBackColor = true;
			// 
			// loopMaxControl
			// 
			this.loopMaxControl.Location = new System.Drawing.Point(139, 91);
			this.loopMaxControl.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.loopMaxControl.Name = "loopMaxControl";
			this.loopMaxControl.Size = new System.Drawing.Size(51, 20);
			this.loopMaxControl.TabIndex = 12;
			this.loopMaxControl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(344, 238);
			this.Controls.Add(label6);
			this.Controls.Add(this.loopMaxControl);
			this.Controls.Add(this.fadeAtEndCheckBox);
			this.Controls.Add(this.playTimeLabel);
			this.Controls.Add(this.tempoLabel);
			this.Controls.Add(this.startStopButton);
			this.Controls.Add(this.changeDelayControl);
			this.Controls.Add(label5);
			this.Controls.Add(this.changeAmountControl);
			this.Controls.Add(label4);
			this.Controls.Add(this.endTempoControl);
			this.Controls.Add(label3);
			this.Controls.Add(this.startTempoControl);
			this.Controls.Add(label2);
			this.Controls.Add(this.songSelector);
			this.Controls.Add(label1);
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.Text = "SMPS Tempo";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.startTempoControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.endTempoControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.changeAmountControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.changeDelayControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.loopMaxControl)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox songSelector;
		private System.Windows.Forms.NumericUpDown startTempoControl;
		private System.Windows.Forms.NumericUpDown endTempoControl;
		private System.Windows.Forms.NumericUpDown changeAmountControl;
		private System.Windows.Forms.NumericUpDown changeDelayControl;
		private System.Windows.Forms.Button startStopButton;
		private System.Windows.Forms.Label tempoLabel;
		private System.Windows.Forms.Label playTimeLabel;
		private System.Windows.Forms.CheckBox fadeAtEndCheckBox;
		private System.Windows.Forms.NumericUpDown loopMaxControl;

	}
}

