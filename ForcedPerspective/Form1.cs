using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForcedPerspective {
    public partial class Form1 : Form {

        System.Drawing.Bitmap bitmap;


        public Form1() {
            InitializeComponent();
            bitmap = new Bitmap(251, 184);
            int r,g,b;
            DirectoryNode d = new DirectoryNode(@"C:\", 0, 100);
            Console.WriteLine(d.getGigaBytes());


            for (int x = 0; x < 251; x++) {
                for (int y = 0; y < 184; y++) {
                    
                    r = 255 * (x / 251);
                    g = 255 * ((x + y) / (251 + 184));
                    b = 255 * (y / 184);
                    bitmap.SetPixel(x, y, Color.FromArgb(x,0,y));
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            pictureBox1.Image = bitmap;
        }
    }
}
