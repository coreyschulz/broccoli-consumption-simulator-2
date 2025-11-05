using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input; 
using Assets;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace State
{
    public class CoreyState : State
    {
        Color bcsBlue = new Color(174, 225, 243);
        Color bcsOrange = new Color(246, 138, 39);
        Color bcsWhite = Color.White;
        Color bcsGrey = Color.DarkGray; 
        Vector2 boxPos = new Vector2(0, 470);
        Rectangle boxRect = new Rectangle(0, 0, 1280, 250); 
        Vector2 namePos = new Vector2(30, 480);
        Vector2 line1Pos = new Vector2(15, 575);
        Vector2 line2Pos = new Vector2(15, 640);
        KeyboardState oldKeyboardState; 
        bool initialized = false; 
        string[] initialLines = System.IO.File.ReadAllLines("../../../../../State/Scripts/script.txt");
        string[] notFightLines = System.IO.File.ReadAllLines("../../../../../State/Scripts/notFightScript.txt");
        string[] fightLines = System.IO.File.ReadAllLines("../../../../../State/Scripts/fightScript.txt");
        List<string[]> initialDialogue = new List<string[]>();
        List<string[]> fightDialogue = new List<string[]>();
        List<string[]> notFightDialogue = new List<string[]>(); 
        List<string[]> currentDialogue;
        int i; // used for dialogue progression...
        string choice = "default";

        Song defaultSound;
        Song fightSound;
        Song notFightSound;

        // CHARACTER POSITIONS ON SCREEN
        Rectangle bgPos = new Rectangle(0, 0, 1280, 470); 
        Rectangle bcmanPos = new Rectangle(100, 100, 200, 400);
        Rectangle samsungPos = new Rectangle(650, 100, 600, 300);
        Rectangle broccoliPos = new Rectangle(750, 50, 400, 400); 

        public void initialize(string[] initialLines, string[] notFightLines, string[] fightLines)
        {
            for (int i = 0; i < initialLines.Length; i++)
            {
                initialDialogue.Add(initialLines[i].Split('*')); 
            }
            for (int i = 0; i < notFightLines.Length; i++)
            {
                notFightDialogue.Add(notFightLines[i].Split('*')); 
            }
            for (int i = 0; i < fightLines.Length; i++)
            {
                fightDialogue.Add(fightLines[i].Split('*')); 
            }
            currentDialogue = initialDialogue;
            i = 0;

            defaultSound = Assets.Assets.Songs["corey/default"];
            fightSound = Assets.Assets.Songs["corey/fight"];
            notFightSound = Assets.Assets.Songs["corey/notFight"];

            MediaPlayer.Play(defaultSound);
            MediaPlayer.IsRepeating = true; 

            initialized = true; 
        }

        public void DrawVisualNovel(SpriteBatch spriteBatch, String background, String char1, String char2, String speaker, String line1, String line2)
        {
            // Draw background image... 
            if (background != "none")
                spriteBatch.Draw(Assets.Assets.Textures["corey/" + background], bgPos, null, bcsWhite);
            // Draw characters... 
            if (char1 != "none")
                spriteBatch.Draw(Assets.Assets.Textures["corey/" + char1], bcmanPos, null, bcsWhite);
            if (char2 != "none")
            {
                if (char2 == "samsung")
                    spriteBatch.Draw(Assets.Assets.Textures["corey/" + char2], samsungPos, null, bcsWhite);
                if (char2 == "broccoli")
                    spriteBatch.Draw(Assets.Assets.Textures["corey/" + char2], broccoliPos, null, bcsWhite); 
            }


            // Draw text
            spriteBatch.Draw(Assets.Assets.Textures["corey/rectangleBase"], boxPos, boxRect, bcsBlue);

            if(speaker != "none")
                spriteBatch.DrawString(Assets.Assets.SpriteFonts["corey/bcsFont2"], speaker, namePos, bcsGrey);
            if(line1 != "none")
                spriteBatch.DrawString(Assets.Assets.SpriteFonts["corey/bcsFont"], line1, line1Pos, bcsWhite);
            if(line2 != "none")
                spriteBatch.DrawString(Assets.Assets.SpriteFonts["corey/bcsFont"], line2, line2Pos, bcsWhite);

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if(initialized == false)
            {
                initialize(initialLines, notFightLines, fightLines); 
            }

            spriteBatch.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();


            KeyboardState keyboardState = Keyboard.GetState();

            try
            {
                DrawVisualNovel(spriteBatch, currentDialogue[i][1], currentDialogue[i][2], currentDialogue[i][3], currentDialogue[i][4], currentDialogue[i][5], currentDialogue[i][6]);
            }
            catch
            {
                if (choice == "notFight") {
                    MediaPlayer.Stop();
                    StateManager.GetInstance().Set(new OriginalBCS());
                }

                if (choice == "fight") StateManager.GetInstance().Pop(); 
            }


            if (keyboardState.IsKeyDown(Keys.Space) && oldKeyboardState.IsKeyUp(Keys.Space) && currentDialogue[i][0] == "n")
                i += 1;

            if(choice == "default" && currentDialogue[i][0] == "y")
            {
                if (keyboardState.IsKeyDown(Keys.N) && oldKeyboardState.IsKeyUp(Keys.N))
                {
                    MediaPlayer.Stop();
                    MediaPlayer.Volume = 8; 
                    MediaPlayer.Play(notFightSound); 
                    choice = "notFight"; 
                    currentDialogue = notFightDialogue;
                    i = 0; 
                }
                if (keyboardState.IsKeyDown(Keys.Y) && oldKeyboardState.IsKeyUp(Keys.Y))
                {
                    MediaPlayer.Stop();
                    MediaPlayer.Volume = 10;
                    MediaPlayer.Play(fightSound); 
                    choice = "fight";
                    currentDialogue = fightDialogue;
                    i = 0; 
                }
            }


            oldKeyboardState = keyboardState; 
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
