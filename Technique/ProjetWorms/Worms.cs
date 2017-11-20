using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjetWorms
{
    class Worms
    {
        private Point position;
        private Game game;
        private Point velocity;
        private SimpleAnimationSprite[] sprites;

        private bool hasJumped;
        private bool hasDoubleJumped;

        public Point Position { get => position; set => position = value; }

        public Worms(Game game)
        {
            this.game = game;
            this.sprites = new SimpleAnimationSprite[] { };

            this.position.X = 200;
            this.position.Y = 300;
        }

        public void Initialise()
        {
            SimpleAnimationSprite sprite0 = new SimpleAnimationSprite(game, new SimpleAnimationDefinition()
            {
                AssetName = "wormsAttendreD",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 36),
                Loop = true,
            });

            SimpleAnimationSprite sprite1 = new SimpleAnimationSprite(game, new SimpleAnimationDefinition()
            {
                AssetName = "wormsDroite",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 15),
                Loop = true,
            });

            SimpleAnimationSprite sprite2 = new SimpleAnimationSprite(game, new SimpleAnimationDefinition()
            {
                AssetName = "wormsSautD",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 7),
                Loop = false,
            });

            SimpleAnimationSprite sprite3 = new SimpleAnimationSprite(game, new SimpleAnimationDefinition()
            {
                AssetName = "doubleJump",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 22),
                Loop = false,
            });

            this.sprites = new SimpleAnimationSprite[] { sprite0, sprite1, sprite2, sprite3};

            foreach (SimpleAnimationSprite anim in this.sprites)
            {
                anim.Initialize();
                anim.Position = this.position;
            }
        }

        public void LoadContent(SpriteBatch spritebatch)
        {
            foreach (SimpleAnimationSprite anim in this.sprites)
            {
                anim.LoadContent(spritebatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            //Update de la position selon la vélocity
            this.position += this.velocity;
            //Update de la positions des sprites
            foreach (SimpleAnimationSprite anim in this.sprites)
            {
                anim.Position = this.position;
            }

            //Right and Left
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                this.velocity.X = 2;
                foreach (SimpleAnimationSprite anim in this.sprites)
                    anim.SpriteEffects = SpriteEffects.None;
                sprites[1].Update(gameTime);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                this.velocity.X = -2;
                foreach(SimpleAnimationSprite anim in this.sprites)
                    anim.SpriteEffects = SpriteEffects.FlipHorizontally;
                sprites[1].Update(gameTime);
            }
            else
            {
                this.velocity.X = 0;
                sprites[0].Update(gameTime);
            }

            //Jump
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                sprites[2].Update(gameTime);
                this.position.Y -= 20;
                this.velocity.Y = -10;
                this.hasJumped = true;
            }

            if (this.hasJumped == true)
            {
                this.velocity.Y += 1;
                sprites[2].Update(gameTime);
            }

            if (this.position.Y >= 300)
            {
                this.hasJumped = false;
            }

            if (this.hasJumped == false)
            {
                this.velocity.Y = 0;
                sprites[2].Reset();
            }

            //Double Jump
            if(Keyboard.GetState().IsKeyDown(Keys.Space) && this.hasJumped == true && this.hasDoubleJumped == false && this.velocity.Y >= 0 )
            {
                sprites[3].Update(gameTime);
                this.position.Y -= 20;
                this.velocity.Y = -10;
                this.hasDoubleJumped = true;
            }

            if(this.hasDoubleJumped == true)
                sprites[3].Update(gameTime);

            if (this.hasDoubleJumped == false)
                sprites[3].Reset();

            if(this.hasJumped == false)
                this.hasDoubleJumped = false;
        }

        public void Draw(GameTime time)
        {
            //Left and Right
            if (Keyboard.GetState().IsKeyDown(Keys.D) && hasJumped == false)
                sprites[1].Draw(time);

            else if (Keyboard.GetState().IsKeyDown(Keys.Q) && hasJumped == false)
                sprites[1].Draw(time);

            else if (hasJumped == false)
                sprites[0].Draw(time);

            //Jump
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
                sprites[2].Draw(time);

            if (this.hasJumped == true && this.hasDoubleJumped == false)
                sprites[2].Draw(time);

            //Double Jump
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && this.hasJumped == true && this.hasDoubleJumped == false)
                sprites[3].Draw(time);

            if (this.hasDoubleJumped == true)
                sprites[3].Draw(time);
        }
    }
}
