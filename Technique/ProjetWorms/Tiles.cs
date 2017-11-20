using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace ProjetWorms
{
    class Tiles
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private SpriteBatch spriteBatch;
        private String name;
        private Game game;
  
        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value;  }
        }

        public Tiles(Game pgame, String pname, Rectangle prectangle)
        {
            this.game = pgame;
            this.name = pname;
            this.rectangle = prectangle;
        }
            
        public void LoadContent(SpriteBatch pspriteBatch)
        {
            this.spriteBatch = pspriteBatch;
            this.texture = this.game.Content.Load<Texture2D>(name);
        }

        public void Draw(GameTime time)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }        
    }
}
