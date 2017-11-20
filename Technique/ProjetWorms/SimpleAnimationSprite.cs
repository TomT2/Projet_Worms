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
        private Point position; //position d'affichage
        private Vector2 origin;
        protected Game Game;
        public SimpleAnimationDefinition Definition;
        private SpriteEffects spriteEffects;
        private SpriteBatch spriteBatch;
        protected Texture2D sprite;
        protected Point CurrentFrame;
        private bool finishedAnimation = false;
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
        private float rotationAngle = 0;

        public Point Position { get => position; set => position = value; }

        public bool FinishedAnimation { get => finishedAnimation; set => finishedAnimation = value; }
        public float RotationAngle { get => rotationAngle; set => rotationAngle = value; }
        public SpriteEffects SpriteEffects { get => spriteEffects; set => spriteEffects = value; }

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
            this.CurrentFrame.X = 0;
            this.CurrentFrame.Y = 0;
        }

        public void LoadContent(SpriteBatch spritebatch)
        {
            /* Chargements des donnees */
            this.sprite = this.Game.Content.Load < Texture2D>(this.Definition.AssetName);
            this.spriteBatch = spritebatch;
            this.origin.X = 0;
            this.origin.Y = 0;
            this.spriteEffects = SpriteEffects.None;
        }

        public void Reset()
        {
            /* Reinitialisation de l'animation */
            this.CurrentFrame = new Point();
            this.FinishedAnimation = false;
            this.lastFrameUpdatedTime = 0;
        }

        public void Update(GameTime time)
        {
            /* Mise a jour des donnees en vue de l'affichage */
            if (FinishedAnimation) return;
            this.lastFrameUpdatedTime += time.ElapsedGameTime.Milliseconds;
            if (this.lastFrameUpdatedTime > this.TimeBetweenFrame)
            {
                this.lastFrameUpdatedTime = 0;
                if (this.Definition.Loop)
                {
                    this.CurrentFrame.X++;
                    if (this.CurrentFrame.X >= this.Definition.NbFrames.X)
                    {
                        this.CurrentFrame.X = 0;
                        this.CurrentFrame.Y++;
                        if (this.CurrentFrame.Y >= this.Definition.NbFrames.Y)
                            this.CurrentFrame.Y = 0;
                    }
                }
                else
                {
                    this.CurrentFrame.X++;
                    if (this.CurrentFrame.X >= this.Definition.NbFrames.X)
                    {
                        this.CurrentFrame.X = 0;
                        this.CurrentFrame.Y++;
                        if (this.CurrentFrame.Y >= this.Definition.NbFrames.Y)
                        {
                            this.CurrentFrame.X = this.Definition.NbFrames.X - 1;
                            this.CurrentFrame.Y = this.Definition.NbFrames.Y - 1;
                            this.FinishedAnimation = true;
                        }
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
                                    Color.White, rotationAngle, origin, spriteEffects,0f);
        }
    }
}
