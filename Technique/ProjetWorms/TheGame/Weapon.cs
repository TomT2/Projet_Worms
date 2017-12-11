using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWorms.TheGame
{
    abstract class Weapon
    {
        protected String name;
        protected Game game;
        protected Missile missile;
        protected Sprite sprite;

        private Point missilePos;

        protected Point force;
        protected String direction;

        public string Name { get => name; }
        public Point Force { get => force; set => force = value; }
        public Missile Missile { get => missile; set => missile = value; }
        public Sprite Sprite { get => sprite; }
        public Point MissilePos { get => missilePos; set => missilePos = value; }
        public String Direction { get => direction; set => direction = value; }

        public Weapon(Game pgame,Missile pmissile)
        {
            name = "Arme";
            game = pgame;
            missile = pmissile;
            sprite = null;
            force = new Point(0, 0);
            direction = "";
        }

        public abstract void Update(GameTime ptime);
        public abstract void Draw(GameTime ptime);
        public abstract void LoadContent(SpriteBatch pspriteBatch);

        public void Fire()
        {
            missile.Position = missilePos;
            missile.Velocity = force;
            missile.IsMoving = true;
            missile.IsMyTurn = true;
        }
    }
}
