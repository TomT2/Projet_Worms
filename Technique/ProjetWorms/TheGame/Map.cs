using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWorms.TheGame
{
    class Map
    {
        private Game game;
        private List<Tiles> tiles;
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
            tiles = new List<Tiles>();
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
                            name = "c1";
                            break;

                        case 2:
                            name = "c2";
                            break;

                        case 3:
                            name = "c3";
                            break;

                        case 4:
                            name = "c4";
                            break;

                        case 5:
                            name = "c5";
                            break;

                        default:
                            name = "";
                            break;
                    }
                    if (name != "")
                        tiles.Add(new Tiles(game, name, new Rectangle(x * psize, y * psize, psize, psize)));
                    // permet de connaitre la taille de notre carte
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

        public void Draw()
        {
            foreach (Tiles tile in tiles)
                tile.Draw();
        }

    }
}
