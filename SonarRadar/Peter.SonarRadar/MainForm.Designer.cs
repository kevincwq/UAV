namespace Peter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rtfTerminal = new System.Windows.Forms.RichTextBox();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.lblSend = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.lblComPort = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.gbPortSettings = new System.Windows.Forms.GroupBox();
            this.pbRadar = new System.Windows.Forms.PictureBox();
            this.gbMode.SuspendLayout();
            this.gbPortSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRadar)).BeginInit();
            this.SuspendLayout();
            // 
            // rtfTerminal
            // 
            this.rtfTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtfTerminal.Location = new System.Drawing.Point(12, 6);
            this.rtfTerminal.Name = "rtfTerminal";
            this.rtfTerminal.Size = new System.Drawing.Size(541, 271);
            this.rtfTerminal.TabIndex = 0;
            this.rtfTerminal.Text = "";
            // 
            // txtSendData
            // 
            this.txtSendData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSendData.Location = new System.Drawing.Point(76, 282);
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(387, 21);
            this.txtSendData.TabIndex = 2;
            this.txtSendData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendData_KeyDown);
            this.txtSendData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSendData_KeyPress);
            // 
            // lblSend
            // 
            this.lblSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(12, 285);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(65, 12);
            this.lblSend.TabIndex = 1;
            this.lblSend.Text = "Send &Data:";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSend.Location = new System.Drawing.Point(478, 282);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 21);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cmbPortName
            // 
            this.cmbPortName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.cmbPortName.Location = new System.Drawing.Point(13, 32);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(67, 20);
            this.cmbPortName.TabIndex = 1;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000"});
            this.cmbBaudRate.Location = new System.Drawing.Point(86, 32);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(69, 20);
            this.cmbBaudRate.TabIndex = 3;
            this.cmbBaudRate.Validating += new System.ComponentModel.CancelEventHandler(this.cmbBaudRate_Validating);
            // 
            // rbHex
            // 
            this.rbHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbHex.AutoSize = true;
            this.rbHex.Location = new System.Drawing.Point(12, 36);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(41, 16);
            this.rbHex.TabIndex = 1;
            this.rbHex.Text = "Hex";
            this.rbHex.CheckedChanged += new System.EventHandler(this.rbHex_CheckedChanged);
            // 
            // rbText
            // 
            this.rbText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbText.AutoSize = true;
            this.rbText.Location = new System.Drawing.Point(12, 18);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(47, 16);
            this.rbText.TabIndex = 0;
            this.rbText.Text = "Text";
            this.rbText.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // gbMode
            // 
            this.gbMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbMode.Controls.Add(this.rbText);
            this.gbMode.Controls.Add(this.rbHex);
            this.gbMode.Location = new System.Drawing.Point(388, 306);
            this.gbMode.Name = "gbMode";
            this.gbMode.Size = new System.Drawing.Size(75, 59);
            this.gbMode.TabIndex = 5;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "Data &Mode";
            // 
            // lblComPort
            // 
            this.lblComPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(12, 18);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(59, 12);
            this.lblComPort.TabIndex = 0;
            this.lblComPort.Text = "COM Port:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(85, 18);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(65, 12);
            this.lblBaudRate.TabIndex = 2;
            this.lblBaudRate.Text = "Baud Rate:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Parity:";
            // 
            // cmbParity
            // 
            this.cmbParity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(161, 32);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(60, 20);
            this.cmbParity.TabIndex = 5;
            // 
            // lblDataBits
            // 
            this.lblDataBits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Location = new System.Drawing.Point(229, 18);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(65, 12);
            this.lblDataBits.TabIndex = 6;
            this.lblDataBits.Text = "Data Bits:";
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cmbDataBits.Location = new System.Drawing.Point(227, 32);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(60, 20);
            this.cmbDataBits.TabIndex = 7;
            this.cmbDataBits.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDataBits_Validating);
            // 
            // lblStopBits
            // 
            this.lblStopBits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Location = new System.Drawing.Point(295, 18);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(65, 12);
            this.lblStopBits.TabIndex = 8;
            this.lblStopBits.Text = "Stop Bits:";
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbStopBits.Location = new System.Drawing.Point(293, 32);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(65, 20);
            this.cmbStopBits.TabIndex = 9;
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenPort.Location = new System.Drawing.Point(478, 306);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(75, 59);
            this.btnOpenPort.TabIndex = 6;
            this.btnOpenPort.Text = "&Open Port";
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // gbPortSettings
            // 
            this.gbPortSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPortSettings.Controls.Add(this.lblComPort);
            this.gbPortSettings.Controls.Add(this.cmbPortName);
            this.gbPortSettings.Controls.Add(this.lblStopBits);
            this.gbPortSettings.Controls.Add(this.cmbBaudRate);
            this.gbPortSettings.Controls.Add(this.cmbStopBits);
            this.gbPortSettings.Controls.Add(this.lblBaudRate);
            this.gbPortSettings.Controls.Add(this.lblDataBits);
            this.gbPortSettings.Controls.Add(this.cmbParity);
            this.gbPortSettings.Controls.Add(this.cmbDataBits);
            this.gbPortSettings.Controls.Add(this.label1);
            this.gbPortSettings.Location = new System.Drawing.Point(12, 306);
            this.gbPortSettings.Name = "gbPortSettings";
            this.gbPortSettings.Size = new System.Drawing.Size(370, 59);
            this.gbPortSettings.TabIndex = 4;
            this.gbPortSettings.TabStop = false;
            this.gbPortSettings.Text = "Serial Port &Settings";
            // 
            // pbRadar
            // 
            this.pbRadar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbRadar.Location = new System.Drawing.Point(560, 6);
            this.pbRadar.Name = "pbRadar";
            this.pbRadar.Size = new System.Drawing.Size(351, 359);
            this.pbRadar.TabIndex = 7;
            this.pbRadar.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 372);
            this.Controls.Add(this.pbRadar);
            this.Controls.Add(this.gbPortSettings);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.gbMode);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.txtSendData);
            this.Controls.Add(this.rtfTerminal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(559, 269);
            this.Name = "MainForm";
            this.Text = "Sonar Radar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTerminal_FormClosing);
            this.Shown += new System.EventHandler(this.frmTerminal_Shown);
            this.gbMode.ResumeLayout(false);
            this.gbMode.PerformLayout();
            this.gbPortSettings.ResumeLayout(false);
            this.gbPortSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRadar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox rtfTerminal;
    private System.Windows.Forms.TextBox txtSendData;
    private System.Windows.Forms.Label lblSend;
    private System.Windows.Forms.Button btnSend;
    private System.Windows.Forms.ComboBox cmbPortName;
    private System.Windows.Forms.ComboBox cmbBaudRate;
    private System.Windows.Forms.RadioButton rbHex;
    private System.Windows.Forms.RadioButton rbText;
    private System.Windows.Forms.GroupBox gbMode;
    private System.Windows.Forms.Label lblComPort;
    private System.Windows.Forms.Label lblBaudRate;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbParity;
    private System.Windows.Forms.Label lblDataBits;
    private System.Windows.Forms.ComboBox cmbDataBits;
    private System.Windows.Forms.Label lblStopBits;
    private System.Windows.Forms.ComboBox cmbStopBits;
    private System.Windows.Forms.Button btnOpenPort;
    private System.Windows.Forms.GroupBox gbPortSettings;
    private System.Windows.Forms.PictureBox pbRadar;
  }
}
