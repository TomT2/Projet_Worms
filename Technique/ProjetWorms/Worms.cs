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
        public Point position;
        public Animations animation;
        public Game game;

        public Worms(Game game)
        {
            this.game = game;
            this.animation = new Animations();
            this.position.X = 100;
            this.position.Y = 100;
        }
        public void Initialise()
        {
            animation.Initialise(this.game);
            foreach (SimpleAnimationSprite anim in this.animation.sprite)
            {
                anim.Initialize();
                anim.Position = this.position;
            }
        }
        public void LoadContent(SpriteBatch spritebatch)
        {
            animation.LoadContent(spritebatch);
        }
        public void Update(GameTime gameTime,KeyboardState state)
        {
            foreach (SimpleAnimationSprite anim in this.animation.sprite)
            {
                anim.Position = this.position;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                this.position.X++;
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                this.position.X--;
            }
            //faire le saut etc..
            animation.Update(gameTime, state);
        }
        public void Draw(GameTime time, KeyboardState state)
        {
            animation.Draw(time, state);
        }
    }
}
