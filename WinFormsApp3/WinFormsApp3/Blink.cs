using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    internal class Blink
    {
        private Image brickimg;
        internal PictureBox pictureBox;
        
        internal int Lefti=0;
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
        internal Blink(string name,int size)
        {
            Image playerimg = Image.FromFile("C:/Users/bilen/OneDrive/Рабочий стол/packman/textur.png");
            this.brickimg = playerimg;
            Image part = new Bitmap(40, 40);
            Graphics g = Graphics.FromImage(part);
            g.DrawImage(playerimg, 0, 0, new Rectangle(new Point(125, 25), new Size(40, 60)), GraphicsUnit.Pixel);

            pictureBox = new PictureBox
            {
                Name = name,
                Size = new Size(size, size),
                Location = new Point(x, y),
                Image = part

            };
        }

        internal void BrickAnimation()
        {
            if (Lefti > 3) { Lefti = 0; }
            this.brickimg = brickimg;
            Image part = new Bitmap(40, 42);
            Graphics g = Graphics.FromImage(part);
            g.DrawImage(brickimg, 0, 0, new Rectangle(new Point(125, 25+25*Lefti ), new Size(50, 60)), GraphicsUnit.Pixel);
            pictureBox.Image = part;
            Lefti++;
        }

        internal void MoveGreedyAlgorithm(Pacman pac, ref Blink blink,Map map)
        {
           
            double value1 = (Math.Sqrt(Math.Pow(pac.X - blink.X + 8, 2) + Math.Pow(pac.Y - blink.Y, 2)));
            double value2 = (Math.Sqrt(Math.Pow(pac.X - blink.X - 8, 2) + Math.Pow(pac.Y - blink.Y, 2)));
            double value3 = (Math.Sqrt(Math.Pow(pac.X - blink.X, 2) + Math.Pow(pac.Y + 8 - blink.Y, 2)));
            double value4 = (Math.Sqrt(Math.Pow(pac.X - blink.X, 2) + Math.Pow(pac.Y -8 - blink.Y, 2)));
            double[] mas = { value1,value2,value3,value4};
            double maxValue = mas.Max();
            int maxIndex = mas.ToList().IndexOf(maxValue);
            mas = mas.OrderBy(x => x).ToArray();

            if (maxIndex == 0) { blink.X = blink.X + 8;if (collisionRight(map)) {
                    blink.X = blink.X - 8;
                    if (mas[1] == value4) { blink.Y += 8; }
                    if (mas[1] == value3) { blink.Y -= 8; }
                } 
            }
            if (maxIndex == 1) { blink.X = blink.X - 8;if (collisionLeft(map)) {
                    blink.X = blink.X + 8;
                    if (mas[1] == value4) { blink.Y += 8; }
                   if (mas[1] == value3) { blink.Y -= 8; }
                } 
            }
            if (maxIndex == 2) { blink.Y = blink.Y + 8; if (collisionDown(map)) {
                    blink.Y = blink.Y - 8;
                    if (mas[1] == value1) { blink.X -= 8;  }
                    if (mas[1] == value2) { blink.X += 8; }
                }  
            }
            if (maxIndex == 3) { blink.Y = blink.Y - 8; if (collisionUP(map))
                {
                    blink.Y = blink.Y + 8;
                    if (mas[1] == value1) { blink.X -= 8; }
                    if (mas[1] == value2) { blink.X += 8; }
                }
            }


        }

        private bool collisionRight( Map map)
        {
            foreach (Wall wall in map.walls)
            {
                foreach (Brick brick in wall.bricks)
                {
                    if (X + 16> brick.X && X<brick.X && Y > brick.Y - 40 && Y < brick.Y + 40) { return true; }
                }

            }
            return false;
        }
        private bool collisionLeft( Map map)
        {
            foreach (Wall wall in map.walls)
            {
                foreach (Brick brick in wall.bricks)
                {
                    if (X - 40 < brick.X && X > brick.X - 40 && Y > brick.Y - 40 && Y < brick.Y + 40) { return true; }
                }
            }
            return false;
        }
        private bool collisionUP(Map map)
        {
            foreach (Wall wall in map.walls)
            {
                foreach (Brick brick in wall.bricks)
                {
                    if (Y - 40 < brick.Y && Y > brick.Y - 40 && X > brick.X - 40 && X < brick.X + 40) { return true; }
                }
            }
            return false;
        }
        private bool collisionDown(Map map)
        {
            foreach (Wall wall in map.walls)
            {
                foreach (Brick brick in wall.bricks)
                {
                    if (Y + 40 > brick.Y && Y < brick.Y + 40 && X > brick.X - 40 && X < brick.X + 40) { return true; }
                }
            }
            return false;
        }


    }
}
