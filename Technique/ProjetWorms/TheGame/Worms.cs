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
    class Worms : Entity
    {
        private bool hasJumped;
        private Weapon weapon;
        private bool hasFired;

        public Worms(Game pgame,int posx, int posy, Weapon pweapon)
            :base(pgame, posx,posy)
        {
            type = "Worms";
            isMyTurn = true; //avant d'implémenter le timer
            hitbox.Width = 15;
            hitbox.Height = 25;
            weapon = pweapon;
            hasFired = false;
        }

        public override void Initialise()
        {
            Sprite sprite0 = new Sprite(game, new SpriteDefinition()
            {
                AssetName = "wormsAttendreD",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 36),
                Loop = true,
            });

            Sprite sprite1 = new Sprite(game, new SpriteDefinition()
            {
                AssetName = "wormsDroite",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 15),
                Loop = true,
            });

            Sprite sprite2 = new Sprite(game, new SpriteDefinition()
            {
                AssetName = "wormsSautD",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 7),
                Loop = false,
            });

            Sprite sprite3 = new Sprite(game, new SpriteDefinition()
            {
                AssetName = "doubleJump",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 22),
                Loop = false,
            });

            sprites.Add(sprite0);
            sprites.Add(sprite1);
            sprites.Add(sprite2);
            sprites.Add(sprite3);

            foreach (Sprite anim in sprites)
            {
                anim.Initialize();
                anim.Position = position;
            }
            return;
        }

        public override void LoadContent(SpriteBatch pspritebatch)
        {
            foreach (Sprite anim in sprites)
                anim.LoadContent(pspritebatch);

            weapon.LoadContent(pspritebatch);

            return;
        }

        public override void Update(GameTime pgameTime)
        {
            position += velocity;

            //Update hitbox
            hitbox.X = Position.X;
            hitbox.Y = Position.Y;

            //Update positions sprites
            weapon.Sprite.Position = new Point(position.X - 22, position.Y - 17);
            foreach (Sprite anim in sprites)
                anim.Position = new Point(position.X - 22,position.Y - 17);

            //Right and Left
            if (Keyboard.GetState().IsKeyDown(Keys.D) && isMyTurn)
            {
                isMoving = true;
                if (velocity.X < 1)
                    velocity.X += 1;
                foreach (Sprite anim in sprites)
                    anim.SpriteEffects = SpriteEffects.None;
                weapon.Direction = "right";
                sprites[1].Update(pgameTime);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Q) && isMyTurn)
            {
                isMoving = true;
                if (velocity.X > -1)
                    velocity.X -= 1;
                foreach (Sprite anim in sprites)
                    anim.SpriteEffects = SpriteEffects.FlipHorizontally;
                weapon.Direction = "left";
                sprites[1].Update(pgameTime);
            }
            else
            {
                isMoving = false;
                velocity.X = 0;
                sprites[0].Update(pgameTime);
            }

            //Jump
            if (isGrounded == true)
                hasJumped = false;
            else
                hasJumped = true;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !hasJumped && isMyTurn)
            {
                sprites[2].Update(pgameTime);
                velocity.Y = -13;
                hasJumped = true;
            }

            if (hasJumped)
            {
                sprites[2].Update(pgameTime);
                isMoving = true;
            }

            if (!hasJumped)
                sprites[2].Reset();

            //Armed mod
            if (!isMoving && isMyTurn)
            {
                weapon.Update(pgameTime);
                weapon.MissilePos = position;
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                    hasFired = true;
                if (Keyboard.GetState().IsKeyUp(Keys.E) && hasFired)
                {
                    weapon.Fire();
                    hasFired = false;
                }
            }

            return;
        }

        public override void Draw(GameTime ptime)
        {
            //priority : Jump
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !hasJumped && isMyTurn)
                sprites[2].Draw(ptime);

            else if (hasJumped)
                sprites[2].Draw(ptime);

            //Left and Right
            else if (Keyboard.GetState().IsKeyDown(Keys.D) && !hasJumped && isMyTurn)
                sprites[1].Draw(ptime);

            else if (Keyboard.GetState().IsKeyDown(Keys.Q) && !hasJumped && isMyTurn)
                sprites[1].Draw(ptime);

            //armed mod
            else if (isMyTurn)
                weapon.Draw(ptime);

            //else : wait
            else
                sprites[0].Draw(ptime);

            return;
        }
    }
}
