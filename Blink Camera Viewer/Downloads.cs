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
    public partial class Downloads : Form
    {
        ImageList imageList1;
        public Downloads()
        {
            InitializeComponent();
        }

        private void Downloads_Load(object sender, EventArgs e)
        {
            ExtractAssociatedIconEx();
        }
        public void ExtractAssociatedIconEx()
        {
            // Initialize the ListView, ImageList and Form.          
            imageList1 = new ImageList();           
            fileView.SmallImageList = imageList1;
            fileView.View = View.Tile;

            // Get the directory.
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String pathString = System.IO.Path.Combine(path, "Blink Desktop");
            DirectoryInfo dir = new DirectoryInfo(pathString);

            ListViewItem item;
            fileView.BeginUpdate();

            // For each file in the c:\ directory, create a ListViewItem
            // and set the icon to the icon extracted from the file.
            foreach (FileInfo file in dir.GetFiles())
            {
                // Set a default icon for the file.
                Icon iconForFile = SystemIcons.WinLogo;

                item = new ListViewItem(file.Name, 1);

                // Check to see if the image collection contains an image
                // for this extension, using the extension as a key.
                if (!imageList1.Images.ContainsKey(file.Extension))
                {
                    // If not, add the image to the image list.
                    iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
                    imageList1.Images.Add(file.Extension, iconForFile);
                }
                item.ImageKey = file.Extension;
                fileView.Items.Add(item);
            }
            fileView.EndUpdate();
        }
    }
}
