using DocumentFormat.OpenXml.Office2013.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Application = System.Windows.Application;
using System.Timers;
namespace Diplom_41P_SergeevDI.Classes
{
    public class ScreenShotsClass
    {
        public int Width = 1920;
        public int Height = 1080;
        public System.Timers.Timer timer = new System.Timers.Timer(100000);

        private void TimerEventProcessor(object sender, EventArgs e)
        {
            timer.Start();
            Bitmap Screenshot = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(Screenshot);

            String date = DateTime.Now.ToString("yyyy.MM.dd");
            string path = @"../Screen/" + date;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                string path_c = Directory.GetCurrentDirectory();
            }
            FileStream fs = File.Open(date, FileMode.OpenOrCreate);
            Screenshot.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
            fs.Close();
        }
    }
}
