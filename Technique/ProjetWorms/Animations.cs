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
    class Animations
    {
        protected bool flag_attend;
        protected bool flag_droite;
        protected bool flag_gauche;
        protected bool flag_saut;
        public SimpleAnimationSprite[] sprite;

        public Animations()
        {
            this.sprite = new SimpleAnimationSprite[] { };
        }
        public void Initialise(Game game)
        {
            SimpleAnimationSprite sprite0 = new SimpleAnimationSprite(game, new SimpleAnimationDefinition()
            {
                AssetName = "wormsAttendreD",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 36),
            });

            SimpleAnimationSprite sprite1 = new SimpleAnimationSprite(game, new SimpleAnimationDefinition()
            {
                AssetName = "wormsDroite",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 15),
            });

            SimpleAnimationSprite sprite2 = new SimpleAnimationSprite(game, new SimpleAnimationDefinition()
            {
                AssetName = "wormsGauche",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 15),
            });

            this.sprite = new SimpleAnimationSprite[] { sprite0, sprite1, sprite2, sprite0 };
        }
        public void LoadContent(SpriteBatch spritebatch)
        {
            foreach (SimpleAnimationSprite anim in this.sprite)
            {
                anim.LoadContent(spritebatch);
            }
        }
        public void Update(GameTime gameTime, KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Right))
            {
                Droite(gameTime);
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                Gauche(gameTime);
            }
            else if (state.IsKeyDown(Keys.Space))
            {
                Saut(gameTime);
            }
            else
            {
                Attend(gameTime);
            }
        }
        public void Attend(GameTime time) {
            if (!(flag_droite || flag_gauche || flag_saut))
            {
                flag_attend = true;
                sprite[0].Update(time);
                flag_attend = false;
            }
        }
        public void Droite(GameTime time) {
            if (!(flag_attend || flag_gauche || flag_saut))
            {
                flag_droite = true;
                sprite[1].Update(time);
                flag_droite = false;
            }
        }
        public void Gauche(GameTime time) {
            if (!(flag_droite || flag_attend || flag_saut))
            {
                flag_gauche = true;
                sprite[2].Update(time);
                flag_gauche = false;
            }
        }
        public void Saut(GameTime time) {
            if (!(flag_droite || flag_gauche || flag_attend))
            {
                flag_saut = true;
                sprite[0].Update(time);
                flag_saut = false;
            }
        }
        public void Draw(GameTime time, KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Right))
            {
                sprite[1].Draw(time);
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                sprite[2].Draw(time);
            }
            else if (state.IsKeyDown(Keys.Space))
            {
                sprite[3].Draw(time);
            }
            else
            {
                sprite[0].Draw(time);
            }
        }
    }
}
