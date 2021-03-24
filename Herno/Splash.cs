using HernoEditor.Properties;
using SharpDX.Windows;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace HernoEditor
{
    class Splash : IDisposable
    {
        private RenderForm form;

        private const int Width = 500;
        private const int Height = 300;
        private Stopwatch watch;

        public Splash()
        {
            form = new RenderForm("Herno Editor™");
            form.ClientSize = new Size(Width, Height);
            form.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            form.AllowUserResizing = false;
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.TopMost = true;
            watch = new Stopwatch();
        }

        public void Run()
        {
            watch.Start();


            var pb = new System.Windows.Forms.PictureBox();
            pb.Image = Image.FromStream(new MemoryStream(Resources.Herno_PNG));
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pb.Dock = System.Windows.Forms.DockStyle.None;
            pb.Size = new Size(200, 200);
            pb.Location = new Point(form.Size.Width / 2 - 100, form.Height / 2 - 100);
            pb.BackColor = Color.Transparent;

            var l = new System.Windows.Forms.Label();
            l.Text = "Herno 3D™";
            l.Dock = System.Windows.Forms.DockStyle.Bottom;
            l.BackColor = Color.Transparent;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.ForeColor = Color.Purple;
            l.Font = new Font(FontFamily.GenericSansSerif, 19, FontStyle.Bold);

            form.Controls.Add(pb);
            form.Controls.Add(l);
            form.BackColor = Color.Black;
            form.TransparencyKey = Color.Black;
            form.AllowTransparency = true;


            RenderLoop.Run(form, RenderCallback);
        }

        private void RenderCallback()
        {
            if (watch.ElapsedMilliseconds >= 5000)
            {
                form.Close();
                Dispose();
            }
        }

        public void Dispose()
        {
            watch.Stop();
            form.Dispose();
        }
    }
}
