using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWorms
{
    class Physic
    {
        private List<Worms> entities;
        private Map map;
        private Point velocity;
        private Point position;
        private int flag;



        public Physic(List<Worms> pentities, Map pmap)
        {
            this.entities = pentities;
            this.map = pmap;
        }
        /*

        public static bool TouchTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - 1 &&
                    r1.Bottom <= r2.Top + (r2.Height / 2) &&
                    r1.Right >= r2.Left + (r2.Width / 5) &&
                    r1.Left <= r2.Right - (r2.Width / 5));
        }

        public static bool TouchBottomOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Top <= r2.Bottom + (r2.Height / 5) &&
                    r1.Top >= r2.Bottom - 1 &&
                    r1.Right >= r2.Left + (r2.Width / 5) &&
                    r1.Left <= r2.Right - (r2.Width / 5));
        }

        public static bool TouchLeftOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Right <= r2.Right &&
                    r1.Right >= r2.Left - 5 &&
                    r1.Top <= r2.Bottom - (r2.Width / 4) &&
                    r1.Bottom >= r2.Top + (r2.Width / 4));
        }

        public static bool TouchRightOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Left &&
                    r1.Left <= r2.Right + 5 &&
                    r1.Top <= r2.Bottom - (r2.Width / 4) &&
                    r1.Bottom >= r2.Top + (r2.Width / 4));
        }*/



        public void Update()
        {
            foreach (Worms entity in this.entities)
            {
                this.position = entity.Position;
                this.velocity = entity.Velocity;
                this.flag = entity.direction;
                foreach (Tiles tile in map.Tiles)
                {
                    if (entity.Hitbox.Intersects(tile.Rectangle))
                    {
                        
                    
                        position.X -= 10;
                        entity.Position = position;
                        /*
                        if (velocity.Y < 0)
                        {
                            position.Y += 1;
                            entity.Position = position;
                        }

                        if (velocity.Y > 0)
                        {
                            position.Y -= 1;
                            entity.Position = position;
                        }
                        */
                      
                    }
                }
            }
        }
    }
}
