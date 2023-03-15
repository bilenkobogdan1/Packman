using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    internal class Pacman
    {
        private string path;
        private int Righti = 0;
        private int Lefti = 0;
        internal PictureBox pictureBox;
        private Image playerimg;
        internal string name;
        internal string size;
        private int x;
       internal int X
        {
            get
            {
                pictureBox.Location = new Point(x, y);
                if (x <0) {  return 0 ; }
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
            set { if (value > 0)
                {
                    y = value;
                    pictureBox.Location = new Point(x, y);
                }
                else { y = 0; }
            }
        }
        internal Pacman(string name, int size)
        {
            Image playerimg= Image.FromFile("C:/Users/bilen/OneDrive/Рабочий стол/packman/textur.png");
            this.playerimg= playerimg;
            Image part = new Bitmap(40, 40);
            Graphics g= Graphics.FromImage(part);
            g.DrawImage(playerimg, 0, 0, new Rectangle(new Point(0, 25), new Size(40, 60)), GraphicsUnit.Pixel);
            
            pictureBox = new PictureBox
            {
                Name = name,
                Size = new Size(size, size),
                Location = new Point(x, y),
                Image = part

            };
        }
     
        internal void PacmanAnimation(int i)
        {
            if (Lefti > 3) { Lefti = 0; }
            this.playerimg = playerimg;
            Image part = new Bitmap(40, 42);
            Graphics g = Graphics.FromImage(part);
            g.DrawImage(playerimg, 0, 0, new Rectangle(new Point(0 + 25 * Lefti, 25*i), new Size(50, 60)), GraphicsUnit.Pixel);
            pictureBox.Image = part;
            Lefti++;
        }

        internal bool collisionRight(Pacman pac, Map map)
        {
            foreach (Wall wall in map.walls)
            {
                foreach (Brick brick in wall.bricks)
                {
                    if (pac.X+40 > brick.X && pac.X < brick.X+16 && pac.Y > brick.Y-40 && pac.Y < brick.Y + 40) { return true; }
                }

            }
            return false;
        }
        internal bool collisionLeft(Pacman pac, Map map)
        {
            foreach (Wall wall in map.walls)
            {
                foreach (Brick brick in wall.bricks)
                {
                    if (pac.X - 40 <brick.X && pac.X > brick.X - 16 && pac.Y > brick.Y - 40 && pac.Y < brick.Y + 40) { return true; }
                }
            }
                    return false;
        }
        internal bool collisionUP(Pacman pac,Map map) {
            foreach (Wall wall in map.walls)
            {
                foreach (Brick brick in wall.bricks)
                {
                    if (pac.Y - 40 < brick.Y && pac.Y > brick.Y - 16 && pac.X > brick.X - 32 && pac.X < brick.X + 32) { return true; }
                }
            }
            return false; }
        internal bool collisionDown(Pacman pac, Map map)
        {
            foreach (Wall wall in map.walls)
            {
                foreach (Brick brick in wall.bricks)
                {
                    if (pac.Y + 40 > brick.Y && pac.Y < brick.Y + 16 && pac.X > brick.X - 32 && pac.X < brick.X + 32) { return true; }
                }
            }
               return false;
        }
       
    }


 }

