using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWorms.TheGame
{
    class PhysicEntity : Physic
    {
        public PhysicEntity(int pgravityForce, int pwidth, int pheight)
            :base(pgravityForce,pwidth,pheight)
        {
        }

        public void Gravity(Entity pentity)
        {
            if (!pentity.IsGrounded)
                pentity.Velocity += new Point(0, gravityForce);
        }

        public void AnticipationColisions(Entity pentity, Rectangle r2)
        {
            Point vTemps = pentity.Velocity;

            if (pentity.IsMoving)
            {
                if (LeftColision(pentity.Hitbox, pentity.Velocity, r2))
                    vTemps.X = r2.Left - pentity.Hitbox.Right;
                else if (RightColision(pentity.Hitbox, pentity.Velocity, r2))
                    vTemps.X = r2.Right - pentity.Hitbox.Left;

                if (TopColision(pentity.Hitbox, pentity.Velocity, r2))
                    vTemps.Y = r2.Bottom - pentity.Hitbox.Top;
               
                if (CornerColision(pentity.Hitbox, pentity.Velocity, r2))
                {
                    if (vTemps.X * vTemps.X > vTemps.Y * vTemps.Y)
                        vTemps.Y = 0;
                    else
                        vTemps.X = 0;
                }

                
            }
            if (BottomColision(pentity.Hitbox, pentity.Velocity, r2))
            {
                vTemps.Y = r2.Top - pentity.Hitbox.Bottom;
                pentity.IsGrounded = true;
            }



            pentity.Velocity = vTemps;
        }
    }
}
