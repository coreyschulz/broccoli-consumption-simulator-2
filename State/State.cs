using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace State
{
    public abstract class State
    {
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
