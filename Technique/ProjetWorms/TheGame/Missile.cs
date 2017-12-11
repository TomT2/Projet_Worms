using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjetWorms.TheGame
{
    class Missile : Entity
    {
        private int dammage;
        private int explosionAreaX;
        private int explosionAreaY;

        private bool hasExplosed;

        public int Dammage { get => dammage; set => dammage = value; }
        public bool HasExplosed { get => hasExplosed; set => hasExplosed = value; }
        public int ExplosionAreaY { get => explosionAreaY; set => explosionAreaY = value; }
        public int ExplosionAreaX { get => explosionAreaX; set => explosionAreaX = value; }

        public Missile(Game game) : base(game)
        {
            type = "Missile";
            IsMyTurn = false;
            hasExplosed = false;
            dammage = 0;
            explosionAreaX = 0;
            explosionAreaY = 0;
            hitbox.Width = 15;
            hitbox.Height = 25;
        }

        public Missile(Game game, int pdammage, int perx, int pery) : base(game)
        {
            type = "Missile";
            IsMyTurn = false;
            hasExplosed = false;
            dammage = pdammage;
            explosionAreaX = perx;
            explosionAreaY = pery;
            hitbox.Width = 15;
            hitbox.Height = 25;
        }

        public override void Initialise()
        {
            Sprite sprite0 = new Sprite(game, new SpriteDefinition()
            {
                AssetName = "boule2",
                FrameRate = 60,
                FrameSize = new Point(60, 60),
                NbFrames = new Point(1, 4),
                Loop = true,
            });

            sprites.Add(sprite0);

            foreach (Sprite anim in sprites)
            {
                anim.Initialize();
                anim.Position = position;
            }

            return;
        }

        public override void LoadContent(SpriteBatch pspritebatch)
        {
            foreach (Sprite anim in sprites)
                anim.LoadContent(pspritebatch);

            return;
        }

        public override void Update(GameTime pgameTime)
        {
            position += velocity;

            //Update hitbox
            
            if (hasExplosed)
            {
                hitbox.Width = explosionAreaX;
                hitbox.Height = explosionAreaY;
            }
            
            hitbox.X = position.X;
            hitbox.Y = position.Y;

            //Update positions sprites
            foreach (Sprite anim in sprites)
            {
                anim.Position = new Point(position.X - 22, position.Y - 17);
                anim.Update(pgameTime);
            }

            return;
        }

        public override void Draw(GameTime ptime)
        {
            if (isMyTurn && !hasExplosed)
                sprites[0].Draw(ptime);

            return;
        }
    }
}
