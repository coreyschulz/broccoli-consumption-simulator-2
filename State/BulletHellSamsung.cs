using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace State
{
    public class BulletHellSamsung : State
    {
        private Vector2 bcmanPosition = new Vector2(1280 / 2, 720 - 100);

        private Vector2 samsungPosition = new Vector2(1280 / 2, 76);
        private Vector2 samsungVelocity = new Vector2(3, 0);
        private float bulletSpread = (float)Math.PI;

        private float bcmanHealth = 100.0f;
        private float samsungHealth = 100.0f;

        private int samsungMode = 0;
        private float firingRate = 0.4f;
        private int firingMult = 1;

        private int flashTime = 0;
        private int yellTimer = 60;
        private bool yellPlayed = false;

        private int timer = 240;

        private bool musicStarted = false;

        private List<Bullet> bullets = new List<Bullet>();

        Random random = new Random();

        public override void Update(GameTime gameTime)
        {
            if(yellTimer > 0)
                yellTimer -= 1;
            else if(!yellPlayed)
            {
                Assets.Assets.SoundEffects["zak/bullet/yell"].Play();
                yellPlayed = true;
            }

            bcmanPosition = Mouse.GetState().Position.ToVector2();

            if(bcmanPosition.X < 0)
                bcmanPosition.X = 0;

            if(bcmanPosition.X > 1280)
                bcmanPosition.X = 1280;

            if(bcmanPosition.Y < 0)
                bcmanPosition.Y = 0;

            if(bcmanPosition.Y > 720)
                bcmanPosition.Y = 720;

            samsungPosition += samsungVelocity;
            if(samsungPosition.X < 200 || samsungPosition.X > 1280 - 200)
                samsungVelocity.X *= -1;

            if(samsungPosition.Y < 76 || samsungPosition.Y > 720 - 76)
                samsungVelocity.Y *= -1;

            if(timer <= 0)
            {
                if(!musicStarted)
                {
                    MediaPlayer.Play(Assets.Assets.Songs["zak/bullet/undertale"]);
                    musicStarted = true;
                }

                for(int index = 0; index < firingMult; index++)
                {
                    if(random.NextDouble() < firingRate)
                    {
                        double angle = random.NextDouble() * bulletSpread;
                        bullets.Add(new Bullet() { Position = samsungPosition, Velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 10, Friendly = false, Color = Color.Red });
                    }
                }

                if(Mouse.GetState().LeftButton == ButtonState.Pressed && random.NextDouble() < 0.1)
                {
                    bullets.Add(new Bullet() { Position = bcmanPosition, Velocity = new Vector2(0, -10), Friendly = true, Color = Color.Green });
                }
            }
            else
            {
                timer -= 1;
            }

            if(flashTime > 0)
                flashTime -= 1;

            foreach(Bullet bullet in bullets)
            {
                bullet.Update();

                if(!bullet.Friendly && (bcmanPosition - bullet.Position).Length() < 50)
                {
                    bullet.Position = new Vector2(10000, 10000);
                    bcmanHealth -= 2;
                    flashTime = 10;
                }

                if(bullet.Friendly && bullet.Position.X > samsungPosition.X - 200 && bullet.Position.X < samsungPosition.X + 200 && bullet.Position.Y > samsungPosition.Y - 76 && bullet.Position.Y < samsungPosition.Y + 76)
                {
                    bullet.Position = new Vector2(10000, 10000);
                    samsungHealth -= 1;
                }
            }

            if(samsungHealth < 80.0f && samsungMode < 1)
            {
                samsungVelocity.Y = 3;
                bulletSpread = 2 * (float)Math.PI;
                samsungMode = 1;
            }

            if(samsungHealth < 50.0f && samsungMode < 2)
            {
                firingRate = 0.8f;
                samsungMode = 2;
            }

            if(samsungHealth < 30.0f && samsungMode < 3)
            {
                firingRate = 1.0f;
                samsungVelocity *= 2;
                samsungMode = 3;
            }

            if(samsungHealth < 20.0f && samsungMode < 4)
            {
                firingMult = 2;
                samsungMode = 4;
            }

            if(samsungHealth < 15.0f && samsungMode < 5)
            {
                firingMult = 4;
                samsungMode = 5;
            }

            if(samsungHealth < 10.0f && samsungMode < 6)
            {
                firingMult = 30;
                samsungMode = 6;
            }

            bullets.RemoveAll(bullet => bullet.Position.X < 0 || bullet.Position.X > 1280 || bullet.Position.Y < 0 || bullet.Position.Y > 720);

            if(bcmanHealth <= 0.0)
            {
                StateManager.GetInstance().Set(new CoreyState());
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.GraphicsDevice.Clear(new Color(246, 138, 39)); // 174 225 243 (BCS BLUE)

            spriteBatch.Begin();

            foreach(Bullet bullet in bullets)
                spriteBatch.Draw(Assets.Assets.Textures["zak/bullet/bullet"], bullet.Position, null, bullet.Color, (float)Math.Atan2(bullet.Velocity.Y, bullet.Velocity.X), new Vector2(45, 15), 1.0f, SpriteEffects.None, 1.0f);
            
            spriteBatch.Draw(Assets.Assets.Textures["zak/bullet/samsung"], samsungPosition, null, Color.White, 0.0f, new Vector2(200, 76), 1.0f, SpriteEffects.None, 1.0f);
            spriteBatch.Draw(Assets.Assets.Textures["zak/bullet/bcman"], bcmanPosition, null, flashTime > 0 ? Color.Red : Color.White, 0.0f, new Vector2(50, 50), 1.0f, SpriteEffects.None, 1.0f);

            spriteBatch.End();
        }
    }

    class Bullet
    {
        public bool Friendly { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Color Color { get; set; } = Color.White;

        public void Update()
        {
            Position += Velocity;
        }
    }
}
