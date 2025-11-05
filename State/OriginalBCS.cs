using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace State
{
    public class OriginalBCS : State
    {
        Vector2 bcsManPosition = new Vector2(200, 200);
        Vector2 bcsManVelocity = new Vector2(0, 0);

        Vector2 brocolliPosition = new Vector2(400, 400);

        int score = 0;
        bool musicStarted = false;
        
        string[] frames = new string[]
        {
            "zak/original/bcman",
            "zak/original/bcman_left",
            "zak/original/bcman",
            "zak/original/bcman_right"
        };

        double currentFrame = 0;

        bool cutscene = false;

        float speed = 1.0f;

        float preWaitTime = 90;
        float postWaitTime = 90;
        float transitionTime = 0;
        float nextSceneTime = 400;

        Random random = new Random();

        public override void Update(GameTime gameTime)
        {
            if(!cutscene)
                NormalPlay();
            else
                UpdateCutscene();
        }

        private void NormalPlay()
        {

            if(!musicStarted)
            {
                MediaPlayer.Play(Assets.Assets.Songs["zak/original/sakura_ost"]);
                musicStarted = true;
            }

            KeyboardState keyboardState = Keyboard.GetState();

            bcsManVelocity = new Vector2(0, 0);

            if(keyboardState.IsKeyDown(Keys.Right))
                bcsManVelocity.X += 5;

            if(keyboardState.IsKeyDown(Keys.Left))
                bcsManVelocity.X -= 5;

            if(keyboardState.IsKeyDown(Keys.Up))
                bcsManVelocity.Y -= 5;

            if(keyboardState.IsKeyDown(Keys.Down))
                bcsManVelocity.Y += 5;

            bcsManPosition += bcsManVelocity;

            currentFrame += 0.15;
            currentFrame %= frames.Length;

            if((bcsManPosition - brocolliPosition).Length() < 100)
            {
                brocolliPosition = new Vector2(50 + random.Next(1280 - 100), 50 + random.Next(720 - 100));
                score += 10;

                if(score >= 100)
                {
                    bcsManVelocity = new Vector2(0, 0);

                    speed = (new Vector2(1280 / 2, 720 / 2) - bcsManPosition).Length() / 290;

                    cutscene = true;
                }
            }
        }

        private void UpdateCutscene()
        {

            if(preWaitTime > 0)
            {
                if(musicStarted)
                {
                    MediaPlayer.Stop();
                    musicStarted = false;
                }

                preWaitTime -= 1;
            }
            else if(bcsManPosition != new Vector2(1280 / 2, 720 / 2))
            {
                if(!musicStarted)
                {
                    MediaPlayer.Play(Assets.Assets.Songs["zak/original/epic"]);
                    musicStarted = true;
                }

                Vector2 offset = new Vector2(1280 / 2, 720 / 2) - bcsManPosition;
                float distance = offset.Length();

                if(distance > speed)
                    distance = speed;

                bcsManPosition += Vector2.Normalize(offset) * distance;
            }
            else if(postWaitTime > 0)
            {
                postWaitTime -= 1;
            }
            else if(transitionTime < 100)
            {
                transitionTime += 1;
            }
            else if(nextSceneTime > 0)
            {
                nextSceneTime -= 1;
            }
            else
            {
                MediaPlayer.Stop();
                StateManager.GetInstance().Set(new MasonState());
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.GraphicsDevice.Clear(new Color(246, 138, 39)); // 174 225 243 (BCS BLUE)

            spriteBatch.Begin();

            if(!cutscene)
                NormalDraw(spriteBatch);
            else
                CutsceneDraw(spriteBatch);

            spriteBatch.End();
        }

        private void NormalDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.Assets.Textures["zak/original/brocolli"], brocolliPosition, null, Color.White, 0.0f, new Vector2(50, 50), 1.0f, SpriteEffects.None, 1.0f);
            spriteBatch.Draw(Assets.Assets.Textures[bcsManVelocity.Length() > 0 ? frames[(int)currentFrame] : frames[0]], bcsManPosition, null, Color.White, 0.0f, new Vector2(50, 150), 1.0f, SpriteEffects.None, 1.0f);

            spriteBatch.DrawString(Assets.Assets.SpriteFonts["zak/original/bcsfont"], $"Score: {score}", new Vector2(10, 10), Color.Black);
        }
        
        private void CutsceneDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.Assets.Textures["zak/original/brocolli"], brocolliPosition, null, Color.White, 0.0f, new Vector2(50, 50), 1.0f, SpriteEffects.None, 1.0f);

            double amount = random.NextDouble();
            spriteBatch.Draw(Assets.Assets.Textures[100 * amount * amount < transitionTime ? "zak/original/bcman_new" : "zak/original/bcman"], bcsManPosition, null, Color.White, 0.0f, new Vector2(50, 150), 1.0f, SpriteEffects.None, 1.0f);

            spriteBatch.DrawString(Assets.Assets.SpriteFonts["zak/original/bcsfont"], $"Score: {score}", new Vector2(10, 10), Color.Black);
        }
    }
}
