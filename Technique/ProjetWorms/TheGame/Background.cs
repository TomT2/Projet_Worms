using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjetWorms.TheGame
{
    class Background
    {
        private Vector2 position;
        private SpriteBatch spriteBatch;
        private String name;
        private Texture2D image;
        private Game game;
        private float speed;


        public Vector2 Position
        {
            get { return position; }
        }
        public Texture2D Image
        {
            get { return image; }
        }

       public Background(Game pGame, String pName, float pSpeed)
        {
            game = pGame;
            name = pName;
            speed = pSpeed;
            position = new Vector2(0, 0);         
        }

        public void Update()
        {
            position.X += speed;
            if (position.X <= 0 - image.Width)
                position.X = 0;

        }

        public void LoadContent(SpriteBatch pspriteBatch)
        {
            this.spriteBatch = pspriteBatch;
            this.image = this.game.Content.Load<Texture2D>(name);
        }

        public void Draw()
        {
            spriteBatch.Draw(image, position, Color.White);
           if (position.X < 0)
               spriteBatch.Draw(image, new Vector2(position.X + image.Width, 0), Color.White);
        }
    }
}