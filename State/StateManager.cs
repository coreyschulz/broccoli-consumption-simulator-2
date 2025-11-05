using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace State
{
    public class StateManager
    {
        private Stack<State> states;

        private StateManager()
        {
            states = new Stack<State>();
        }

        public bool Empty()
        {
            return states.Count == 0;
        }

        public void Pop()
        {
            if(!Empty())
                states.Pop();
        }

        public void Push(State state)
        {
            states.Push(state);
        }

        public void Set(State state)
        {
            Pop();
            Push(state);
        }

        
        public void Update(GameTime gameTime)
        {
            if(!Empty())
                states.Peek().Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if(!Empty())
                states.Peek().Draw(spriteBatch, gameTime);
        }


        private static StateManager Instance = new StateManager();

        public static StateManager GetInstance()
        {
            return Instance;
        }
    }
}
