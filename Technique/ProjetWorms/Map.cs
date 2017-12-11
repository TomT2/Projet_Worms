using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWorms
{
    class Map
    {
        private Game game;
        private List<Tiles> tiles = new List<Tiles>();
        private int width, height;

        public List<Tiles> Tiles
        {
            get { return tiles; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Map(Game pgame)
        {
            this.game = pgame;
        }

        public void Generate(int[,] pmap, int psize)
        {
            for(int x = 0; x < pmap.GetLength(1); x++)
            {
                for (int y = 0; y < pmap.GetLength(0); y++)
                {
                    int number = pmap[y, x];
                    String name;

                    switch(number)
                    {
                        case 1:
                            name = "durt";
                            break;

                        case 2:
                            name = "grass";
                            break;

                        default:
                            name = "";
                            break;
                    }
                    if (name != "")
                        tiles.Add(new Tiles(game, name, new Rectangle(x * psize, y * psize, psize, psize)));
                    width = (x + 1) * psize;
                    height = (y + 1) * psize;
                }
            }
        }
        public void LoadContent(SpriteBatch pspriteBatch)
        {
            foreach (Tiles tile in tiles)
                tile.LoadContent(pspriteBatch);
        }

        public void Draw(GameTime ptime)
        {
            foreach (Tiles tile in tiles)
                tile.Draw(ptime);
        }

    }
}
