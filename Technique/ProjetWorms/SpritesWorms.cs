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
    class SpritesWorms
    {
        public SimpleAnimationSprite[] sprites;

        public SpritesWorms(Game game)
        {
            SimpleAnimationSprite sprite0 = new SimpleAnimationSprite(game, new SimpleAnimationDefinition()
            {
                AssetName = "sprite1",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 36),
                DecalX = false,
                DecalY = false,
                Decalage = new Point(0, 0)
            });

            SimpleAnimationSprite sprite1 = new SimpleAnimationSprite(game, new SimpleAnimationDefinition()
            {
                AssetName = "spriteDroite",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 15),
                DecalX = false,
                DecalY = true,
                Decalage = new Point(10, 0)
            });

            SimpleAnimationSprite sprite2 = new SimpleAnimationSprite(game, new SimpleAnimationDefinition()
            {
                AssetName = "spriteGauche",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 15),
                DecalX = false,
                DecalY = true,
                Decalage = new Point(-10, 0)
            });

            this.sprites = new SimpleAnimationSprite[] { sprite0, sprite1, sprite2, sprite0 };
        }
    }
}
