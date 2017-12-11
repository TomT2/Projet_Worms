using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWorms.TheGame
{
    abstract class Entity
    {
        protected String type;
        protected Game game;

        protected Point position;
        protected Point velocity;
        protected Rectangle hitbox;
        
        protected bool isGrounded;
        protected bool isMoving;
        protected bool isMyTurn;

        protected List<Sprite> sprites;

        public String Type { get => type;}
        public Point Position { get => position; set => position = value; }
        public Point Velocity { get => velocity; set => velocity = value; }
        public Rectangle Hitbox { get => hitbox; }

        public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
        public bool IsMoving { get => isMoving; set => isMoving = value; }
        public bool IsMyTurn { get => IsMyTurn; set => isMyTurn = value; }

        public List<Sprite> Sprites { get => sprites;}

        public Entity(Game pgame, int posx,int posy)
        {
            type = "Entity";
            game = pgame;
            position.X = posx;
            position.Y = posy;
            hitbox = new Rectangle();
            Velocity = new Point(0, 0);
            isGrounded = false;
            isMoving = false;
            IsMyTurn = false;
            sprites = new List<Sprite>();
        }

        public Entity(Game pgame)
        {
            type = "Entity";
            game = pgame;
            position.X = 0;
            position.Y = 0;
            hitbox = new Rectangle();
            Velocity = new Point(0, 0);
            isGrounded = false;
            isMoving = false;
            IsMyTurn = false;
            sprites = new List<Sprite>();
        }

        public abstract void Initialise();
        public abstract void LoadContent(SpriteBatch pspritebatch);
        public abstract void Update(GameTime pgameTime);
        public abstract void Draw(GameTime ptime);
    }
}
