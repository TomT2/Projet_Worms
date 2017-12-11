using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjetWorms.TheGame
{
    class Bazooka : Weapon
    {
        public Bazooka(Game pgame, Missile pmissile) : base(pgame, pmissile)
        {
            name = "Bazooka";
            sprite = new Sprite(game, new SpriteDefinition()
            {
                AssetName = "bazooka",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 31),
                Loop = true,
            });
            Force = new Point(10,15);
        }

        public override void LoadContent(SpriteBatch pspriteBatch)
        {
            missile.LoadContent(pspriteBatch);
            sprite.LoadContent(pspriteBatch);
        }

        public override void Update(GameTime ptime)
        {
            switch(direction)
            {
                case "right":
                    sprite.SpriteEffects = SpriteEffects.None;
                    if (Force.X < 0)
                        Force *= new Point(-1, 1);
                    break;

                case "left":
                    sprite.SpriteEffects = SpriteEffects.FlipHorizontally;
                    if (Force.X > 0)
                        Force *= new Point(-1, 1);
                    break;

                default:
                    sprite.SpriteEffects = SpriteEffects.None;
                    if (Force.X < 0)
                        Force *= new Point(-1, 1);
                    break;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                sprite.IncrementCurrentFrameY(ptime);
                if(Force.Y > -15*2)
                    Force -= new Point(0, 1*2);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                sprite.DecrementCurrentFrameY(ptime);
                if(Force.Y <= 15*2)
                    Force += new Point(0, 1*2);
            }

             return;
        }

        public override void Draw(GameTime ptime)
        {
            missile.Draw(ptime);
            sprite.Draw(ptime);
        }

        
    }
}
