using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blink_Camera_Viewer
{
    public partial class Clip_Player : Form
    {
        String clipURI;
        public Clip_Player()
        {
            InitializeComponent();
            clipURI =  Properties.Settings.Default.currentClipSelection;
        }

        private void Clip_Player_Load(object sender, EventArgs e)
        {
            try
            {
                clipPlayer.URL = clipURI;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
