using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    internal class Brick
    {
        private Image brickimg;
        internal PictureBox pictureBox;
        private int x;
        internal int X
        {
            get
            {
                pictureBox.Location = new Point(x, y);
                if (x < 0) { return 0; }
                else
                {
                    return x;
                }
            }

            set
            {
                if (value > 0)
                {
                    x = value;
                    pictureBox.Location = new Point(x, y);
                }
                else { x = 0; }
            }
        }
        private int y;
        internal int Y
        {
            get
            {
                pictureBox.Location = new Point(x, y);
                if (y < 0) { return 0; }
                else { return y; }
            }
            set
            {
                if (value > 0)
                {
                    y = value;
                    pictureBox.Location = new Point(x, y);
                }
                else { y = 0; }
            }
        }

        internal Brick(string name, int size)
        {
          Image playerimg = Image.FromFile("C:/Users/bilen/OneDrive/Рабочий стол/packman/textur.png");
            this.brickimg = playerimg;
            Image part = new Bitmap(40, 42);
            Graphics g = Graphics.FromImage(part);
            g.DrawImage(playerimg, 0, 0, new Rectangle(new Point(0, 0), new Size(50, 40)), GraphicsUnit.Pixel);

            pictureBox = new PictureBox
            {
                Name = name,
                Size = new Size(size, size),
                Location = new Point(x, y),  
                Image = part

            };
        }
    }
}
