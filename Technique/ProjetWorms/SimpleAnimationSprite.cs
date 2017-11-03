using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjetWorms
{
    class SimpleAnimationSprite
    {
        public Point Position; //position d'affichage
        protected Game Game;
        public SimpleAnimationDefinition Definition;
        protected SpriteBatch spriteBatch;
        protected Texture2D sprite;
        protected Point CurrentFrame;
        protected double TimeBetweenFrame = 16; // 60 fps 
        protected double lastFrameUpdatedTime = 0;
        private int _Framerate = 60;
        public int Framerate
        {
            get { return this._Framerate; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Framerate can't be less or equal to 0");
                if (this._Framerate != value)
                {
                    this._Framerate = value;
                    this.TimeBetweenFrame = 1000.0d / (double)this._Framerate;
                }
            }
        }

        /* Proprietes */
        public SimpleAnimationSprite(Game game, SimpleAnimationDefinition definition)
        {
            /* Constructeur */
            this.Game = game;
            this.Definition = definition;
            this.Position = new Point();
            this.CurrentFrame = new Point();
        }

        public void Initialize()
        {
            /* Initialisation */
            this.Framerate = this.Definition.FrameRate;
        }

        public void LoadContent(SpriteBatch spritebatch)
        {
            /* Chargements des donnees */
            this.sprite = this.Game.Content.Load < Texture2D>(this.Definition.AssetName);
            this.spriteBatch = spritebatch;
        }

        public void Reset()
        {
            /* Reinitialisation de l'animation */
            this.CurrentFrame = new Point();
            this.lastFrameUpdatedTime = 0;
        }

        public void Update(GameTime time)
        {
            /* Mise a jour des donnees en vue de l'affichage */
            this.lastFrameUpdatedTime += time.ElapsedGameTime.Milliseconds;
            if (this.lastFrameUpdatedTime > this.TimeBetweenFrame)
            {
                this.lastFrameUpdatedTime = 0;
                this.CurrentFrame.X++;
                if (this.CurrentFrame.X >= this.Definition.NbFrames.X)
                {
                    this.CurrentFrame.X = 0;
                    this.CurrentFrame.Y++;
                    if (this.CurrentFrame.Y >= this.Definition.NbFrames.Y)
                    {
                    this.CurrentFrame.Y = 0;
                    }
                }
            }
        }

        public void Draw(GameTime time)
        {
            /* Affichage de l'animation */

            this.spriteBatch.Draw(this.sprite,
                                  new Rectangle(this.Position.X, this.Position.Y, this.Definition.FrameSize.X, this.Definition.FrameSize.Y),
                                  new Rectangle(this.CurrentFrame.X * this.Definition.FrameSize.X, this.CurrentFrame.Y * this.Definition.FrameSize.Y, this.Definition.FrameSize.X, this.Definition.FrameSize.Y),
                                  Color.White);

        }
    }
}
