using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWorms.TheGame
{
    class Physic
    {
        protected int gravityForce;
        protected int width;
        protected int height;

        public Physic(int pgravityForce,int pwidth, int pheight)
        {
            gravityForce = pgravityForce;
            width = pwidth;
            height = pheight;
        }

        public void SetGravityForce(int pgravityForce)
        {
            gravityForce = pgravityForce;
        }

        public void SetWidth(int pwidth)
        {
            width = pwidth;
        }

        public void SetHeight(int pheight)
        {
            height = pheight;
        }

        public bool Colision(Rectangle r1, Point v1, Rectangle r2)
        {
            if (LeftColision(r1, v1, r2) || RightColision(r1, v1, r2)
                || BottomColision(r1, v1, r2) || TopColision(r1, v1, r2)
                || CornerColision(r1, v1, r2))
                return true;
            return false;
        }

        protected bool LeftColision(Rectangle r1, Point v1, Rectangle r2)
        {
            if ((r1.Top > r2.Top && r1.Top < r2.Bottom)
                || (r1.Bottom > r2.Top && r1.Bottom < r2.Bottom))
            {
                if (v1.X >= 0 && r1.Right + v1.X >= r2.Left && r1.Right <= r2.Left)//Left colisions
                    return true;
            }
            return false;
        }

        protected bool RightColision(Rectangle r1, Point v1, Rectangle r2)
        {
            if ((r1.Top > r2.Top && r1.Top < r2.Bottom)
                || (r1.Bottom > r2.Top && r1.Bottom < r2.Bottom))
            {
                if (v1.X <= 0 && r1.Left + v1.X <= r2.Right && r1.Left >= r2.Right)//Right colisions
                    return true;
            }
            return false;
        }

        protected bool TopColision(Rectangle r1, Point v1, Rectangle r2)
        {
            if ((r1.Right < r2.Right && r1.Right > r2.Left)
                || (r1.Left < r2.Right && r1.Left > r2.Left))
            {
                if (v1.Y <= 0 && r1.Top + v1.Y <= r2.Bottom && r1.Top >= r2.Bottom)//Top colisions
                    return true;
            }
            return false;
        }

        protected bool BottomColision(Rectangle r1, Point v1, Rectangle r2)
        {
            if ((r1.Right < r2.Right && r1.Right > r2.Left)
                || (r1.Left < r2.Right && r1.Left > r2.Left))
            {
                if (v1.Y >= 0 && r1.Bottom + v1.Y >= r2.Top && r1.Bottom <= r2.Top)//Bot colisions
                    return true;
            }
            return false;
        }

        protected bool CornerColision(Rectangle r1, Point v1, Rectangle r2)
        {
            Rectangle rTemps = new Rectangle(r1.X + v1.X, r1.Y + v1.Y, r1.Width, r1.Height);

            if (rTemps.Intersects(r2))
            {
                return true;
            }
            return false;
        }
    }
}
