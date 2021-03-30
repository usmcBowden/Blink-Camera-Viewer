using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 *Unoffical Blink Camera Desktop App
 * Developed By Samuel Bowden using Blink REST API documented by MattTW at https://github.com/MattTW/BlinkMonitorProtocol
 * 
 * Viewing livestreams is still a work in progress
 *
 * */

namespace Blink_Camera_Viewer
{
    public partial class Form1 : Form
    {
        private String response;
        private Boolean loaded = false;
        private Boolean[] defaultFlags = new Boolean[12];
        private List<Clip> clips;
        private List<Camera> cameras;
        Utilities Blink = new Utilities();
        User user;
        WMPLib.WindowsMediaPlayer Player;
        public Form1()
        {
            InitializeComponent();
            Bitmap bm = Properties.Resources.Blink_Logo_unoffical;
            LogoBox.Image = bm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                response = Blink.LoginAsync(emailTxt.Text, passTxt.Text).Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            String[] arr = Blink.AccountInformation(response);
            user = new User(arr[0], arr[1], arr[2], Convert.ToBoolean(arr[3]), arr[4], arr[5], arr[6]);
            if (!response.Contains("Invalid credentials"))
            {
                if (!user.isVerified())
                {
                    logBox.Visible = false;
                    verBox.Visible = true;
                    LogoBox.Visible = false;
                }
                else
                {
                    HomeScreen();
                }
            }
            else
                MessageBox.Show(response.ToString());    
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            response = Blink.VerifyAsync(user, verText.Text).Result;         
            if (response.Contains("true"))
            {
                HomeScreen();
            }
            else
            {
                MessageBox.Show("Invalid PIN");
            }
        }
     
        
        private void HomeScreen()
        {
            logBox.Visible = false;
            response = Blink.HomeAsync(user).Result;         
            TabMenu.Visible = true;
            armSystemToolStripMenuItem.Visible = true;
            logOutToolStripMenuItem.Visible = true;
            verBox.Visible = false;
            LogoBox.Visible = false;
            LoadCameras();
            if (!loaded)
               Task.Factory.StartNew(() => LoadClips());//clips can take a while to load so it runs as a separate task.
            //Task.Factory.StartNew(() => PushNotifications());//runs a while loop that sleeps for 30 seconds after each iteration.
        }

        /*
         * Method initializes a list of cameras connected to your blink account
         * Uses Utility class to generate a 2D array of camera data extracted from JSON returned by API
         * Uses Camera class to create camera objects that are displayed in a Picturebox that is added to a FlowLayOutPanel
         * Assigns each Camera a context menu that allows for updating the thumbnail and arming/disarming
         */
        private void LoadCameras()
        {
            cameras = new List<Camera>();
            String[,] arr = Blink.Cameras(response);
            for (int i = 0; i < arr.GetLength(0); i++)
                cameras.Add(new Camera(arr[i, 4], arr[i, 0], arr[i, 1], arr[i, 3], arr[i, 2], arr[i, 5]));

            foreach (Camera c in cameras)
            {
                PictureBox pb = new PictureBox();
                byte[] img = c.GetThumbnailAsync(user.getToken(), user.getTier()).Result;
                pb.Image = Image.FromStream(new MemoryStream(img));
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Height = 240;
                pb.Width = 480;
                ContextMenu cm = new ContextMenu();
                if (c.isArmed() == "Armed")
                    cm.MenuItems.Add(new MenuItem().Text = "Disarm Camera");
                else
                    cm.MenuItems.Add(new MenuItem().Text = "Arm Camera");
                cm.MenuItems.Add(new MenuItem().Text = "Update Thumbnail");
                pb.ContextMenu = cm;
                //pb.ContextMenuStrip = CameraOptions;
                cm.MenuItems[0].Click += async (s, args) =>
                {
                    await c.ArmOrDisarmAsync(user.getTier(), user.getToken());
                    CameraContainer.Controls.Clear();
                    cm.MenuItems.Clear();
                    HomeScreen();
                };
                cm.MenuItems[1].Click += async (s, args) =>
                {
                    await c.UpdateThumnailAsync(user.getToken(), user.getTier());
                    CameraContainer.Controls.Clear();
                    cm.MenuItems.Clear();
                    HomeScreen();
                };
                pb.Paint += new PaintEventHandler((s, args) =>
                {
                    args.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    Font font = new Font("Arial", 14);
                    args.Graphics.DrawString(c.CameraName() + "(" + c.isArmed() + ")     Battery Level: " + c.BatteryLevel(), font, System.Drawing.Brushes.Black, 30, 0);
                });
                pb.MouseEnter += (s, args) =>
                {
                    PictureBox pic = s as PictureBox;
                    pic.Height = 260;
                    pic.Width = 500;
                };
                pb.MouseLeave += (s, args) =>
                {
                    PictureBox pic = s as PictureBox;
                    pb.Height = 240;
                    pb.Width = 480;
                };
                /* pb.MouseClick += (s, args) =>
                 {
                     String RTSP = c.GetLiveStreamAsync(user.getAccountID(), user.getToken(), user.getTier()).Result;
                     //var mp = new MediaPlayer();
                     //mp.Open(new Uri(RTSP));
                     PlayFile(RTSP);
                 };*/
                CameraContainer.Controls.Add(pb);
            }
        }
        /*
         * Method initializes a list of camera events connected to your blink account
         * Uses Utility class to generate a 2D array of camera event data extracted from JSON returned by API
         * Uses Clip class to add the data to a DataGridView
         * Loads only once after login
         */
        private void LoadClips()
        { 
            String clip = Blink.GetClipsAsync(user).Result;
            clips = new List<Clip>();
            String[,] arr = Blink.Clips(clip);
            DataGridViewRow row;
            DataGridViewImageCell img;
            DataGridViewTextBoxCell name, date;
            //int tryAgain = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                clips.Add(new Clip(arr[i, 1], arr[i, 0], arr[i, 3], arr[i, 2], user.getToken(), user.getTier()));
            }
               
                /*while (tryAgain < 3)
                {
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        try
                        {
                            clips.Add(new Clip(arr[i, 1], arr[i, 0], arr[i, 3], arr[i, 2], user.getToken(), user.getTier()));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            tryAgain++;
                            if (tryAgain > 2)
                            {
                                MessageBox.Show("Clips could not be loaded. Please right-click and refresh to try again. Do not perform anymore actions until clips load. This may take a few minutes depdning on how many clips need to load.");
                            }
                        }
                    }
                }*/
            foreach (Clip c in clips)
            {
                row = new DataGridViewRow();
                img = new DataGridViewImageCell();
                byte[] test = c.GetThumbnail();
                try
                {
                    img.Value = Image.FromStream(new MemoryStream(c.GetThumbnail()));
                }
                catch (Exception ex)
                {
                    File.WriteAllBytes(Environment.SpecialFolder.MyDocuments.ToString(), c.GetThumbnail());
                }
                name = new DataGridViewTextBoxCell();
                name.Value = c.GetName();
                date = new DataGridViewTextBoxCell();
                date.Value = c.GetDate();
                row.Cells.Add(img);
                row.Cells.Add(name);
                row.Cells.Add(date);
                row.Tag = c.GetClip();
                try
                {
                    Invoke(new Action(() =>
                    {
                        ClipView.Rows.Add(row);
                    }));//prevent cross thread error
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            /*Invoke(new Action(() =>
            {
                ClipView.Sort(ClipView.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
            }));*/
            loaded = true;
            
        }

        /*
         * Method scans for motion new motion events every 30 seconds, and then updates the list of clips with new videos
         */
        private async void PushNotifications()
        {
            String data;
            Boolean[] flags;
            while (loaded)
            {
                data = await Blink.GetNotificationEventsAsync(user);
                flags = Blink.NotificationFlags(data);
                for (int i = 0; i < flags.Length; i++)
                {
                    if (!flags[i])
                    {
                        switch (i)
                        {
                            case 0:
                                MessageBox.Show("Low Camera Battery. See Mobile App");
                                await Blink.SetNotificationsAsync("{\n  \"notifications\": {\n    \"low_battery\": true\n  }\n}", user);
                                break;
                            case 1:
                                MessageBox.Show("Camera offline. See Mobile App");
                                await Blink.SetNotificationsAsync("{\n  \"notifications\": {\n    \"camera_offline\": true\n  }\n}", user);
                                break;
                            case 2:
                                MessageBox.Show("High Camera Usage. See Mobile App");
                                await Blink.SetNotificationsAsync("{\n  \"notifications\": {\n    \"camera_usage\": true\n  }\n}", user);
                                break;
                            case 3:
                                MessageBox.Show("Scheduling. See Mobile App");
                                await Blink.SetNotificationsAsync("{\n  \"notifications\": {\n    \"scheduling\": true\n  }\n}", user);
                                break;
                            case 4:
                                MessageBox.Show("Motion Detected. See Mobile App");
                                await Blink.SetNotificationsAsync("{\n  \"notifications\": {\n    \"motion\": true\n  }\n}", user);
                                break;
                            case 5:
                                MessageBox.Show("Sync Module Offline. See Mobile App");
                                await Blink.SetNotificationsAsync("{\n  \"notifications\": {\n    \"sync_module_offline\": true\n  }\n}", user);
                                break;
                            case 6:
                                MessageBox.Show("High Camera Temperature. See Mobile App");
                                await Blink.SetNotificationsAsync("{\n  \"notifications\": {\n    \"temperature\": true\n  }\n}", user);
                                break;
                            case 7:
                                MessageBox.Show("Doorbell. See Mobile App");
                                await Blink.SetNotificationsAsync("{\n  \"notifications\": {\n    \"doorbell\": true\n  }\n}", user);
                                break;
                            case 8:
                                MessageBox.Show("Connection to camera Lost. See Mobile App");
                                await Blink.SetNotificationsAsync("{\n  \"notifications\": {\n    \"wifi\": true\n  }\n}", user);
                                break;
                            case 9:
                                MessageBox.Show("lfr. See Mobile App");
                                await Blink.SetNotificationsAsync("{\n  \"notifications\": {\n    \"lfr\": true\n  }\n}", user);
                                break;
                            case 10:
                                MessageBox.Show("Bandwidth. See Mobile App");
                                await Blink.SetNotificationsAsync("{\n  \"notifications\": {\n    \"bandwidth\": true\n  }\n}", user);
                                break;
                            case 11:
                                MessageBox.Show("Battery Dead. See Mobile App");
                                await Blink.SetNotificationsAsync("{\n  \"notifications\": {\n    \"battery_dead\": true\n  }\n}", user);
                                break;
                        }
                    }
                }
                Thread.Sleep(30000);
            }

        }
        private void PlayFile(String url)
        {
            Player = new WMPLib.WindowsMediaPlayer();
            Player.PlayStateChange +=
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Player.MediaError +=
                new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            Player.URL = url;
            Player.controls.play();
        }
        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            {
                this.Close();
            }
        }

        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Cannot play media file.");
            this.Close();
        }

        private void forgetLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Password must be changed on the offical Blink App");
        }

        private void armSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Yet Implemented");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                response = Blink.LogoutAsync(user).Result;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (response.Contains("logout"))
            {
                clips.Clear();
                cameras.Clear();
                user = null;
                LogoBox.Visible = true;
                TabMenu.Visible = false;
                armSystemToolStripMenuItem.Visible = false;
                logOutToolStripMenuItem.Visible = false;
                logBox.Visible = true;
                loaded = false;
            }
            else
            {
                MessageBox.Show("Logout failed");
            }
        }

        private async void ClipView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String uri = "";
            int rowIndex = e.RowIndex;
            try
            {
                  uri = ClipView.Rows[rowIndex].Tag.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            String fileName = Path.GetFileName(uri);
            byte[] mp4 = await Blink.GetClipAsync(uri, user.getToken());
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String pathString = System.IO.Path.Combine(path, "Blink Desktop");
            String filePathString = System.IO.Path.Combine(pathString, fileName);
            Directory.CreateDirectory(pathString);      
            File.WriteAllBytes(filePathString, mp4);
                  
            Properties.Settings.Default.currentClipSelection = filePathString;
            var ClipPlayer = new Clip_Player();
            ClipPlayer.Show();
        }
        private void Form1_Resize(object sender, EventArgs e)
        { 
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
                ShowInTaskbar = false;
                Hide();
            }
        }     
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void viewDownloadedClipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewDownloads = new Downloads();
            viewDownloads.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clips.Clear();
            LoadClips();
        }
    }
}
