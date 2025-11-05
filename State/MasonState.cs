using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Assets;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace State
{
    public class MasonState : State
    {
        private Vector2 screenCenter = new Vector2(1280f / 2f, 720f / 2f);
        private Rectangle girlRectangle = new Rectangle(600, 300, 100, 100);
        private Rectangle boyRectangle = new Rectangle(700, 300, 100, 100);

        private Rectangle bcsManRectangle = new Rectangle(100, 100, 100, 100);
        private Vector2 bcsManVelocity;
        private float bcsManRotation = 0f;

        private Rectangle needleRectangle;
        private Rectangle cocaineRectangle;
        private Rectangle pillRectangle;
        private Random random = new Random();
        private SoundEffectInstance musicInstance = null;

        private int score = 0;
        private string gameplayState = "game";


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.GraphicsDevice.Clear(new Color(246, 138, 39));

            spriteBatch.Begin();
            spriteBatch.DrawString(Assets.Assets.SpriteFonts["mason_assets/arial_font"], "Score: " + score, Vector2.Zero, Color.White);
            spriteBatch.Draw(Assets.Assets.Textures["mason_assets/boy"], boyRectangle, Color.White);
            spriteBatch.Draw(Assets.Assets.Textures["mason_assets/girl"], girlRectangle, Color.White);
            spriteBatch.Draw(Assets.Assets.Textures["mason_assets/bcs_man"], bcsManRectangle, null, Color.White, bcsManRotation, new Vector2(Assets.Assets.Textures["mason_assets/bcs_man"].Width / 2f, Assets.Assets.Textures["mason_assets/bcs_man"].Height / 2f), SpriteEffects.None, 0f);

            if (needleRectangle != null)
            {
                spriteBatch.Draw(Assets.Assets.Textures["mason_assets/drug_needle"], needleRectangle, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
            }

            if (cocaineRectangle != null)
            {
                spriteBatch.Draw(Assets.Assets.Textures["mason_assets/cocaine"], cocaineRectangle, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
            }

            if (pillRectangle != null)
            {
                spriteBatch.Draw(Assets.Assets.Textures["mason_assets/pill"], pillRectangle, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
            }
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if(musicInstance == null)
            {
                musicInstance = Assets.Assets.SoundEffects["mason_assets/BC_theme"].CreateInstance();
            }

            if (musicInstance.State == SoundState.Stopped)
            {
                musicInstance.Play();
            }

            if (gameplayState == "game")
            {
                KeyboardState keyState = Keyboard.GetState();
                if (keyState.IsKeyDown(Keys.Up))
                {
                    bcsManVelocity.Y -= 4;
                }

                if (keyState.IsKeyDown(Keys.Down))
                {
                    bcsManVelocity.Y += 4;
                }

                if (keyState.IsKeyDown(Keys.Right))
                {
                    bcsManVelocity.X += 4;
                }

                if (keyState.IsKeyDown(Keys.Left))
                {
                    bcsManVelocity.X -= 4;
                }

                if (bcsManVelocity != Vector2.Zero)
                {
                    bcsManRotation = (float)Math.Atan2(bcsManVelocity.Y, bcsManVelocity.X) + (float)Math.PI / 2f;
                }
                else
                {
                    bcsManRotation = 0;
                }
                bcsManRectangle.X += (int)bcsManVelocity.X;
                bcsManRectangle.Y += (int)bcsManVelocity.Y;
                bcsManVelocity = Vector2.Zero;

                if (needleRectangle == Rectangle.Empty)
                {
                    needleRectangle = GenerateSpawnRectangle();
                }
                else
                {
                    Vector2 directionToCenterOfScreen = screenCenter - needleRectangle.Center.ToVector2();
                    if (directionToCenterOfScreen != Vector2.Zero)
                        directionToCenterOfScreen.Normalize();

                    needleRectangle.X += (int)(directionToCenterOfScreen.X * 4f);
                    needleRectangle.Y += (int)(directionToCenterOfScreen.Y * 4f);
                }

                if (cocaineRectangle == Rectangle.Empty)
                {
                    cocaineRectangle = GenerateSpawnRectangle();
                }
                else
                {
                    Vector2 directionToCenterOfScreen = screenCenter - cocaineRectangle.Center.ToVector2();
                    if (directionToCenterOfScreen != Vector2.Zero)
                        directionToCenterOfScreen.Normalize();

                    cocaineRectangle.X += (int)(directionToCenterOfScreen.X * 4f);
                    cocaineRectangle.Y += (int)(directionToCenterOfScreen.Y * 4f);
                }

                if (pillRectangle == Rectangle.Empty)
                {
                    pillRectangle = GenerateSpawnRectangle();
                }
                else
                {
                    Vector2 directionToCenterOfScreen = screenCenter - pillRectangle.Center.ToVector2();
                    if (directionToCenterOfScreen != Vector2.Zero)
                        directionToCenterOfScreen.Normalize();

                    pillRectangle.X += (int)(directionToCenterOfScreen.X * 4f);
                    pillRectangle.Y += (int)(directionToCenterOfScreen.Y * 4f);
                }


                if (bcsManRectangle.Intersects(needleRectangle))
                {
                    needleRectangle = Rectangle.Empty;
                    score += 10;
                }

                if (bcsManRectangle.Intersects(cocaineRectangle))
                {
                    cocaineRectangle = Rectangle.Empty;
                    score += 10;
                }

                if (bcsManRectangle.Intersects(pillRectangle))
                {
                    pillRectangle = Rectangle.Empty;
                    score += 10;
                }

                if (pillRectangle.Intersects(girlRectangle) || pillRectangle.Intersects(boyRectangle))
                {
                    pillRectangle = Rectangle.Empty;
                    score -= 20;
                }

                if (cocaineRectangle.Intersects(girlRectangle) || cocaineRectangle.Intersects(boyRectangle))
                {
                    cocaineRectangle = Rectangle.Empty;
                    score -= 20;
                }

                if (needleRectangle.Intersects(girlRectangle) || needleRectangle.Intersects(boyRectangle))
                {
                    needleRectangle = Rectangle.Empty;
                    score -= 20;
                }
                
                if (score >= 100)
                {
                    gameplayState = "end";
                }
            }
            else if (gameplayState == "end")
            {
                StateManager.GetInstance().Set(new BulletHellSamsung());
                musicInstance.Stop();
            }
        }

        private Rectangle GenerateSpawnRectangle()
        {
            int screenSide = random.Next() % 4;
            int xSpawn = 0;
            int ySpawn = 0;

            if (screenSide == 0)
            {
                xSpawn = random.Next() % 1500 - 100;
                ySpawn = -200;
            }
            else if (screenSide == 1)
            {
                xSpawn = random.Next() % 1500 - 100;
                ySpawn = 920;
            }
            else if (screenSide == 2)
            {
                xSpawn = -200;
                ySpawn = random.Next() % 920 - 100;
            }
            else if (screenSide == 3)
            {
                xSpawn = 1480;
                ySpawn = random.Next() % 920 - 100;
            }

            return new Rectangle(xSpawn, ySpawn, 100, 100);
        }
    }
}
