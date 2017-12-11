using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjetWorms.TheGame
{
    class BackgroundManagement
    {
        private Game game;
        private List<Background> backgrounds = new List<Background>();

        public BackgroundManagement(Game pGame)
        {
            game = pGame;
        }

        public void AddBackground(Background pbackground)
        {
            backgrounds.Add(pbackground);
        }

        public void Update()
        {
            foreach (Background background in backgrounds)
                background.Update();
        }

        public void LoadContent(SpriteBatch pspriteBatch)
        {
            foreach (Background background in backgrounds)
                background.LoadContent(pspriteBatch);
        }

        public void Draw()
        {
            foreach (Background background in backgrounds)
                background.Draw();
        }

    }
}