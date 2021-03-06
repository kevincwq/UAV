// Copyright 2007 - Morten Nielsen
//
// This file is part of SharpGps.
// SharpGps is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// SharpGps is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with SharpGps; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

using System;
using System.Drawing;
using System.Windows.Forms;
using SharpGis.SharpGps;
using System.Collections.Generic;

namespace Demo_WinForms
{
    public partial class MainForm : Form
    {
        public static FrmGpsSettings frmGpsSettings;
        public static FrmNTRIPSettings frmNtripSettings;

        public List<SerialPort> Coms;
        private SharpGis.SharpGps.NTRIP.NTRIPClient ntrip;
        private bool ntripStarted;
        public MainForm()
        {
            InitializeComponent();

            GPS = new GPSHandler(this); //Initialize GPS handler
            GPS.TimeOut = 5; //Set timeout to 5 seconds
            GPS.NewGPSFix += new GPSHandler.NewGPSFixHandler(this.GPSEventHandler); //Hook up GPS data events to a handler
            frmGpsSettings = new FrmGpsSettings();
            frmNtripSettings = new FrmNTRIPSettings();
            ntrip = null;
            ntripStarted = false;
            Coms = new List<SerialPort>();
        }

        public static GPSHandler GPS;

        /// <summary>
        /// Responds to sentence events from GPS receiver
        /// </summary>
        private void GPSEventHandler(object sender, GPSHandler.GPSEventArgs e)
        {
            tbRawLog.Text += e.Sentence + "\r\n";
            if (tbRawLog.Text.Length > 20 * 1024 * 1024) //20Kb maximum - prevents crash
            {
                tbRawLog.Text = tbRawLog.Text.Substring(10 * 1024 * 1024);
            }
            tbRawLog.ScrollToCaret(); //Scroll to bottom

            switch (e.TypeOfEvent)
            {
                case GPSEventType.GPRMC:  //Recommended minimum specific GPS/Transit data
                    if (GPS.HasGPSFix) //Is a GPS fix available?
                    {
                        //lbRMCPosition.Text = GPS.GPRMC.Position.ToString("#.000000");
                        lbRMCPosition.Text = GPS.GPRMC.Position.ToString("DMS");
                        double[] utmpos = TransformToUTM(GPS.GPRMC.Position);
                        lbRMCPositionUTM.Text = utmpos[0].ToString("#.0N ") + utmpos[0].ToString("#.0E") + " (Zone: " + utmpos[2] + ")";
                        lbRMCCourse.Text = GPS.GPRMC.Course.ToString();
                        lbRMCSpeed.Text = GPS.GPRMC.Speed.ToString() + " mph";
                        lbRMCTimeOfFix.Text = GPS.GPRMC.TimeOfFix.ToString("F");
                        lbRMCMagneticVariation.Text = GPS.GPRMC.MagneticVariation.ToString();
                    }
                    else
                    {
                        statusBar1.Text = "No fix";
                        lbRMCCourse.Text = "N/A";
                        lbRMCSpeed.Text = "N/A";
                        lbRMCTimeOfFix.Text = GPS.GPRMC.TimeOfFix.ToString();
                    }
                    break;
                case GPSEventType.GPGGA: //Global Positioning System Fix Data
                    if (GPS.GPGGA.Position != null)
                        lbGGAPosition.Text = GPS.GPGGA.Position.ToString("DM");
                    else
                        lbGGAPosition.Text = "";
                    lbGGATimeOfFix.Text = GPS.GPGGA.TimeOfFix.Hour.ToString() + ":" + GPS.GPGGA.TimeOfFix.Minute.ToString() + ":" + GPS.GPGGA.TimeOfFix.Second.ToString();
                    lbGGAFixQuality.Text = GPS.GPGGA.FixQuality.ToString();
                    lbGGANoOfSats.Text = GPS.GPGGA.NoOfSats.ToString();
                    lbGGAAltitude.Text = GPS.GPGGA.Altitude.ToString() + " " + GPS.GPGGA.AltitudeUnits;
                    lbGGAHDOP.Text = GPS.GPGGA.Dilution.ToString();
                    lbGGAGeoidHeight.Text = GPS.GPGGA.HeightOfGeoid.ToString();
                    lbGGADGPSupdate.Text = GPS.GPGGA.DGPSUpdate.ToString();
                    lbGGADGPSID.Text = GPS.GPGGA.DGPSStationID;
                    break;
                case GPSEventType.GPGLL: //Geographic position, Latitude and Longitude
                    lbGLLPosition.Text = GPS.GPGLL.Position.ToString();
                    lbGLLTimeOfSolution.Text = (GPS.GPGLL.TimeOfSolution.HasValue ? GPS.GPGLL.TimeOfSolution.Value.Hours.ToString() + ":" + GPS.GPGLL.TimeOfSolution.Value.Minutes.ToString() + ":" + GPS.GPGLL.TimeOfSolution.Value.Seconds.ToString() : "");
                    lbGLLDataValid.Text = GPS.GPGLL.DataValid.ToString();
                    break;
                case GPSEventType.GPGSA: //GPS DOP and active satellites
                    if (GPS.GPGSA.Mode == 'A')
                        lbGSAMode.Text = "Auto";
                    else if (GPS.GPGSA.Mode == 'M')
                        lbGSAMode.Text = "Manual";
                    else lbGSAMode.Text = "";
                    lbGSAFixMode.Text = GPS.GPGSA.FixMode.ToString();
                    lbGSAPRNs.Text = "";
                    if (GPS.GPGSA.PRNInSolution.Count > 0)
                        foreach (string prn in GPS.GPGSA.PRNInSolution)
                            lbGSAPRNs.Text += prn + " ";
                    else
                        lbGSAPRNs.Text += "none";
                    lbGSAPDOP.Text = GPS.GPGSA.PDOP.ToString() + " (" + DOPtoWord(GPS.GPGSA.PDOP) + ")";
                    lbGSAHDOP.Text = GPS.GPGSA.HDOP.ToString() + " (" + DOPtoWord(GPS.GPGSA.HDOP) + ")";
                    lbGSAVDOP.Text = GPS.GPGSA.VDOP.ToString() + " (" + DOPtoWord(GPS.GPGSA.VDOP) + ")";
                    break;
                case GPSEventType.GPGSV: //Satellites in view
                    if (NMEAtabs.TabPages[NMEAtabs.SelectedIndex].Text == "GPGSV") //Only update this tab when it is active
                        DrawGSV();
                    break;
                case GPSEventType.PGRME: //Garmin proprietary sentences.
                    lbRMEHorError.Text = GPS.PGRME.EstHorisontalError.ToString();
                    lbRMEVerError.Text = GPS.PGRME.EstVerticalError.ToString();
                    lbRMESphericalError.Text = GPS.PGRME.EstSphericalError.ToString();
                    break;
                case GPSEventType.TimeOut: //Serialport timeout.
                    statusBar1.Text = "Serialport timeout";
                    /*notification1.Caption = "GPS Serialport timeout";
                    notification1.InitialDuration = 5;
                    notification1.Text = "Check your settings and connection";
                    notification1.Critical = false;
                    notification1.Visible = true;
                     */
                    break;
            }
        }
        private double[] TransformToUTM(SharpGis.SharpGps.Coordinate p)
        {
            //For fun, let's use the SharpMap transformation library and display the position in UTM
            int zone = (int)Math.Floor((p.Longitude + 183) / 6.0);
            SharpMap.CoordinateSystems.ProjectedCoordinateSystem proj = SharpMap.CoordinateSystems.ProjectedCoordinateSystem.WGS84_UTM(zone, (p.Latitude >= 0));
            SharpMap.CoordinateSystems.Transformations.ICoordinateTransformation trans =
                new SharpMap.CoordinateSystems.Transformations.CoordinateTransformationFactory().CreateFromCoordinateSystems(proj.GeographicCoordinateSystem, proj);
            double[] result = trans.MathTransform.Transform(new double[] { p.Longitude, p.Latitude });
            return new double[] { result[0], result[1], zone };
        }
        private string DOPtoWord(double dop)
        {
            if (dop < 1.5) return "Ideal";
            else if (dop < 3) return "Excellent";
            else if (dop < 6) return "Good";
            else if (dop < 8) return "Moderate";
            else if (dop < 20) return "Fair";
            else return "Poor";
        }
        private void DrawGSV()
        {
            System.Drawing.Color[] Colors = { Color.Blue , Color.Red , Color.Green, Color.Yellow, Color.Cyan, Color.Orange,
											  Color.Gold , Color.Violet, Color.YellowGreen, Color.Brown, Color.GreenYellow,
											  Color.Blue , Color.Red , Color.Green, Color.Yellow, Color.Aqua, Color.Orange};
            //Generate signal level readout
            int SatCount = GPS.GPGSV.SatsInView;
            Bitmap imgSignals = new Bitmap(picGSVSignals.Width, picGSVSignals.Height);
            Graphics g = Graphics.FromImage(imgSignals);
            g.Clear(Color.White);
            Pen penBlack = new Pen(Color.Black, 1);
            Pen penBlackDashed = new Pen(Color.Black, 1);
            penBlackDashed.DashPattern = new float[] { 2f, 2f };
            Pen penGray = new Pen(Color.LightGray, 1);
            int iMargin = 4; //Distance to edge of image
            int iPadding = 4; //Distance between signal bars
            g.DrawRectangle(penBlack, 0, 0, imgSignals.Width - 1, imgSignals.Height - 1);

            StringFormat sFormat = new StringFormat();
            int barWidth = 1;
            if (SatCount > 0)
                barWidth = (imgSignals.Width - 2 * iMargin - iPadding * (SatCount - 1)) / SatCount;

            //Draw horisontal lines
            for (int i = imgSignals.Height - 15; i > iMargin; i -= (imgSignals.Height - 15 - iMargin) / 5)
                g.DrawLine(penGray, 1, i, imgSignals.Width - 2, i);
            sFormat.Alignment = StringAlignment.Center;
            //Draw satellites
            //GPS.GPGSV.Satellites.Sort(); //new Comparison<SharpGis.SharpGps.NMEA.GPGSV.Satellite>(sat1, sat2) { int.Parse(sat1)
            for (int i = 0; i < GPS.GPGSV.Satellites.Count; i++)
            {
                SharpGis.SharpGps.NMEA.GPGSV.Satellite sat = GPS.GPGSV.Satellites[i];
                int startx = i * (barWidth + iPadding) + iMargin;
                int starty = imgSignals.Height - 15;
                int height = (imgSignals.Height - 15 - iMargin) / 50 * sat.SNR;
                if (GPS.GPGSA.PRNInSolution.Contains(sat.PRN))
                {
                    g.FillRectangle(new System.Drawing.SolidBrush(Colors[i]), startx, starty - height + 1, barWidth, height);
                    g.DrawRectangle(penBlack, startx, starty - height, barWidth, height);
                }
                else
                {
                    g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(50, Colors[i])), startx, starty - height + 1, barWidth, height);
                    g.DrawRectangle(penBlackDashed, startx, starty - height, barWidth, height);
                }

                sFormat.LineAlignment = StringAlignment.Near;
                g.DrawString(sat.PRN, new Font("Verdana", 9, FontStyle.Regular), new System.Drawing.SolidBrush(Color.Black), startx + barWidth / 2, imgSignals.Height - 15, sFormat);
                sFormat.LineAlignment = StringAlignment.Far;
                g.DrawString(sat.SNR.ToString(), new Font("Verdana", 9, FontStyle.Regular), new System.Drawing.SolidBrush(Color.Black), startx + barWidth / 2, starty - height, sFormat);
            }
            picGSVSignals.Image = imgSignals;

            //Generate sky view
            Bitmap imgSkyview = new Bitmap(picGSVSkyview.Width, picGSVSkyview.Height);
            g = Graphics.FromImage(imgSkyview);
            g.Clear(Color.Transparent);
            g.FillEllipse(Brushes.White, 0, 0, imgSkyview.Width - 1, imgSkyview.Height - 1);
            g.DrawEllipse(penGray, 0, 0, imgSkyview.Width - 1, imgSkyview.Height - 1);
            g.DrawEllipse(penGray, imgSkyview.Width / 4, imgSkyview.Height / 4, imgSkyview.Width / 2, imgSkyview.Height / 2);
            g.DrawLine(penGray, imgSkyview.Width / 2, 0, imgSkyview.Width / 2, imgSkyview.Height);
            g.DrawLine(penGray, 0, imgSkyview.Height / 2, imgSkyview.Width, imgSkyview.Height / 2);
            sFormat.LineAlignment = StringAlignment.Near;
            sFormat.Alignment = StringAlignment.Near;
            float radius = 6f;
            for (int i = 0; i < GPS.GPGSV.Satellites.Count; i++)
            {
                SharpGis.SharpGps.NMEA.GPGSV.Satellite sat = GPS.GPGSV.Satellites[i];
                double ang = 90.0 - sat.Azimuth;
                ang = ang / 180.0 * Math.PI;
                int x = imgSkyview.Width / 2 + (int)Math.Round((Math.Cos(ang) * ((90.0 - sat.Elevation) / 90.0) * (imgSkyview.Width / 2.0 - iMargin)));
                int y = imgSkyview.Height / 2 - (int)Math.Round((Math.Sin(ang) * ((90.0 - sat.Elevation) / 90.0) * (imgSkyview.Height / 2.0 - iMargin)));
                g.FillEllipse(new System.Drawing.SolidBrush(Colors[i]), x - radius * 0.5f, y - radius * 0.5f, radius, radius);

                if (GPS.GPGSA.PRNInSolution.Contains(sat.PRN))
                {
                    g.DrawEllipse(penBlack, x - radius * 0.5f, y - radius * 0.5f, radius, radius);
                    g.DrawString(sat.PRN, new Font("Verdana", 9, FontStyle.Bold), new System.Drawing.SolidBrush(Color.Black), x, y, sFormat);
                }
                else
                    g.DrawString(sat.PRN, new Font("Verdana", 8, FontStyle.Italic), new System.Drawing.SolidBrush(Color.Gray), x, y, sFormat);
            }
            picGSVSkyview.Image = imgSkyview;
        }

        private void menuItem_File_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NMEAtabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NMEAtabs.TabPages[NMEAtabs.SelectedIndex].Text == "GPGSV")
                DrawGSV();
        }

        private void btnNTRIPGetSourceTable_Click(object sender, EventArgs e)
        {
            cbMountPoints.Items.Clear();
            if (ntrip == null)
                ntrip = new SharpGis.SharpGps.NTRIP.NTRIPClient(new System.Net.IPEndPoint(System.Net.IPAddress.Parse(tbNTRIPServerIP.Text.Trim()), int.Parse(tbNTRIPPort.Text)), tbNTRIPUser.Text, tbNTRIPPasswd.Text);
            // http://igs.ifag.de/root_ftp/misc/ntrip/streamlist_euref-ip.htm

            SharpGis.SharpGps.NTRIP.SourceTable table = ntrip.GetSourceTable();
            if (table != null)
            {
                //dgNTRIPCasters.DataSource = table.Casters;
                //dgNTRIPNetworks.DataSource = table.Networks;
                //dgNTRIPStreams.DataSource = table.DataStreams;
                //dgNTRIPStreams.SetDataBinding(table.DataStreams, "");

                if (table.DataStreams.Count > 0)
                {
                    //ntrip.StartNTRIP(table.DataStreams[0].MountPoint);
                    foreach (SharpGis.SharpGps.NTRIP.SourceTable.NTRIPDataStream nst in table.DataStreams)
                    {
                        cbMountPoints.Items.Add(nst.MountPoint);
                    }
                    cbMountPoints.SelectedIndex = 0;
                }
                else
                    MessageBox.Show("Sourcetable doesn't contain any datastreams");
            }
            else
                MessageBox.Show("Failed to request or parse the DataSource Table");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GPS.Dispose();  //Closes serial port and cleans up. This is important !
        }

        private void menuItemGPS_Start_Click(object sender, EventArgs e)
        {
            if (!GPS.IsPortOpen)
            {
                try
                {
                    GPS.Start(frmGpsSettings.SerialPort, frmGpsSettings.BaudRate); //Open serial port
                    menuItemGPS_Start.Text = "Stop";
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("An error occured when trying to open port: " + ex.Message);
                }
            }
            else
            {
                GPS.Stop(); //Close serial port
                menuItemGPS_Start.Text = "Start";
            }
        }


        private void menuItemGPS_Settings_Click(object sender, EventArgs e)
        {
            if (GPS.IsPortOpen) frmGpsSettings.DisableConfig();
            else frmGpsSettings.EnableConfig();

            frmGpsSettings.Show();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            if (ntripStarted) frmNtripSettings.DisableConfig();
            else frmNtripSettings.EnableConfig();
            frmNtripSettings.Show();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (ntripStarted)
            {
                try
                {
                    if (ntrip != null)
                        ntrip.StopNTRIP();
                    foreach (SerialPort port in Coms)
                    {
                        port.Stop();
                    }
                    Coms.Clear();
                    ntripStarted = false;
                    btConnect.Text = "Connect";
                }
                catch (Exception ex)
                {
                    tbRTCM.AppendText(ex.Message + "\n");
                }
            }
            else
            {
                try
                {
                    if (ntrip == null)
                        ntrip = new SharpGis.SharpGps.NTRIP.NTRIPClient(new System.Net.IPEndPoint(System.Net.IPAddress.Parse(tbNTRIPServerIP.Text.Trim()), int.Parse(tbNTRIPPort.Text)), tbNTRIPUser.Text, tbNTRIPPasswd.Text);
                    ntrip.NTripDataReceived += ntrip_NTripDataReceived;
                    foreach (string com in frmNtripSettings.COMs)
                    {
                        string[] portrate = com.Split(',');
                        SerialPort port = new SerialPort(portrate[0], int.Parse(portrate[1]));
                        if (port.Port == frmNtripSettings.ReCom)
                            port.NewGPSData += port_NewGPSData;
                        port.Start();
                        Coms.Add(port);
                    }
                    ntrip.StartNTRIP(cbMountPoints.Text);
                    ntripStarted = true;
                    btConnect.Text = "Connected";
                }
                catch (Exception ex)
                {
                    tbRTCM.AppendText(ex.Message + "\n");
                }
            }
        }

        void port_NewGPSData(object sender, SerialPort.GPSEventArgs e)
        {
            if (e.TypeOfEvent == GPSEventType.GPGGA)
            {
                ntrip.MostRecentGGA = e.Sentence;
            }
        }

        void ntrip_NTripDataReceived(object sender, byte[] data)
        {
            foreach (SerialPort com in Coms)
            {
                if (com.IsPortOpen)
                    com.Write(data);
            }
        }
    }
}