using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GalwayGameJam
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Sound sound;

        public Player player;
        public List<Entity> entities = new List<Entity>();
        
        Level_One_Map level_One_Map;
  //      Hallway hallway;
//        bool show_hallway;
  //      Moving_Down_Hall moving_Down_hall;
        Level_Two_Map level_Two_map;
        Lighting lighting;

        public Texture2D wardFloorTexture;
        public Texture2D projectileTexture;
        public AnimatedTexture playerAnimation;
        public Texture2D npcTexture;
        public Texture2D plantTexture;
        public Texture2D deskTexture;
        public Texture2D benchTexture;
        public Texture2D enemyTexture;
        public Texture2D receptionistTexture;
        public Texture2D normalperson1Texture;
        public Texture2D normalperson2Texture;
        public Texture2D receptionFloorTexture;
        public Texture2D doorTexture;
        public Texture2D winScreenTexture;
        public Texture2D doorRightTexture;
        public Texture2D deskDirtyTexture;
        public Texture2D benchDirtyTexture;
        public Texture2D plantDirtyTexture;
        public Texture2D receptionFloorDirtyTexture;

        public Texture2D enemyLeftTexture;
        public Texture2D enemyBackTexture;

        public Texture2D deadScreenTexture;

        public Texture2D electroFloorTexture;
        public Texture2D cabinetLowerTexture;
        public Texture2D electroMachineTexture;
        public Texture2D cleanbed90Texture;
        public Texture2D flashTexture;
        public Texture2D nurseForwardTexture;
        public Texture2D nurseLeftTexture;
        public Texture2D bloodyBedTexture;

        public Texture2D electroMachineDirtyTexture;
        public Texture2D cabinetTexture;
        public Texture2D bloodyBedBitsTexture;
        public Texture2D cleanBedTexture;

        FadeScreen fade;

        public String text = "";
        public int textTimer = 0;
        public SpriteFont font;

        Boolean useLighting = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 8 * 80;
            graphics.PreferredBackBufferWidth = 11 * 80;
        }

        protected override void Initialize()
        {
            sound = new Sound(Content);

//            level_One_Map = new Level_One_Map(Content);
            fade = new FadeScreen(Content);
  //          hallway = new Hallway(Content);
  //          moving_Down_hall = new Moving_Down_Hall(Content.Load<Texture2D>("sprites/darren"), new Vector2(50, 430), 70, 62);
  //          level_Two_map = new Level_Two_Map(Content);

            lighting = new Lighting(Content, GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            projectileTexture = Content.Load<Texture2D>("Sprites/syringe");
            playerAnimation = new AnimatedTexture(Vector2.Zero, 0, 1, 0f); // Origin: new Vector2(31, 40)
            playerAnimation.Load(Content, "Sprites/character", 12, 5);
            npcTexture = Content.Load<Texture2D>("Sprites/talking");
            plantTexture = Content.Load<Texture2D>("Sprites/plant");

            font = Content.Load<SpriteFont>("SpriteFont1");

            receptionFloorTexture = Content.Load<Texture2D>("Sprites/reception_floor");
            wardFloorTexture = Content.Load<Texture2D>("Sprites/ward_floor");

            electroFloorTexture = Content.Load<Texture2D>("Sprites/floor clean");
            cabinetLowerTexture = Content.Load<Texture2D>("Sprites/cabinet lower");
            electroMachineTexture = Content.Load<Texture2D>("Sprites/electro machine clean");
            deadScreenTexture = Content.Load<Texture2D>("Sprites/deadScreen");

            enemyLeftTexture = Content.Load<Texture2D>("Sprites/enemyleft");
            enemyBackTexture = Content.Load<Texture2D>("Sprites/enemyback");

            cleanbed90Texture = Content.Load<Texture2D>("Sprites/cleanbed90");

            deskTexture = Content.Load<Texture2D>("Sprites/desk");
            benchTexture = Content.Load<Texture2D>("Sprites/bench");
            enemyTexture = Content.Load<Texture2D>("Sprites/enemy");
            receptionistTexture = Content.Load<Texture2D>("Sprites/receptionist");
            normalperson1Texture = Content.Load<Texture2D>("Sprites/normalperson1");
            normalperson2Texture = Content.Load<Texture2D>("Sprites/normalperson2");
            winScreenTexture = Content.Load<Texture2D>("Sprites/SuccessScreen");

            flashTexture = Content.Load<Texture2D>("Sprites/blackscreen");
            doorTexture = Content.Load<Texture2D>("Sprites/Door");
            doorRightTexture = Content.Load<Texture2D>("Sprites/Door_Right");
            cleanBedTexture = Content.Load<Texture2D>("Sprites/Clean bed");
            bloodyBedTexture = Content.Load<Texture2D>("Sprites/bloody bed");
            bloodyBedBitsTexture = Content.Load<Texture2D>("Sprites/beds");
            cabinetTexture = Content.Load<Texture2D>("Sprites/Cabinet-Side");
            electroMachineDirtyTexture = Content.Load<Texture2D>("Sprites/bloodyelectromachine");

            deskDirtyTexture = Content.Load<Texture2D>("Sprites/dirty desk");
            benchDirtyTexture = Content.Load<Texture2D>("Sprites/Dirtybench");
            plantDirtyTexture = Content.Load<Texture2D>("Sprites/dead plant");
            receptionFloorDirtyTexture = Content.Load<Texture2D>("Sprites/reception_floor_dirty");

            nurseForwardTexture = Content.Load<Texture2D>("Sprites/nurseforward");
            nurseLeftTexture = Content.Load<Texture2D>("Sprites/nurseleft");


            player = new Player(this, playerAnimation);
            loadLevel(0);
        }

        public void loadLevel(int level)
        {
            entities.Clear();

            if (level == 0)
            {
                sound.play_reception = true;

                showText("");
                player.health = 100;
                player.position = new Vector2(50, 300);

                useLighting = false;
                entities.Add(new Background(receptionFloorTexture));
                entities.Add(new Receptionist(receptionistTexture, new Vector2(450, 70), "Welcome to excerebro Sanatorium for the mentally insane. \nHow can I help you today?", this));
                entities.Add(new TalkingNPC(normalperson1Texture, new Vector2(250, 250), "Oh you're here to visit a friend? \nMy advice is to get him out of here, \nthis place gives me the creeps!", this));
                entities.Add(new TalkingNPC(normalperson2Texture, new Vector2(400, 400), "Man, Tranquilisers are really easy to get around here! \nAnd the floors are really unsafe! This whole place \nis a death trap!", this));
                entities.Add(player);
                entities.Add(new SolidObject(deskTexture, new Vector2(170, 0)));
                entities.Add(new SolidObject(benchTexture, new Vector2(300, 550)));
                entities.Add(new SolidObject(plantTexture, new Vector2(50, 50)));
                entities.Add(new SolidObject(plantTexture, new Vector2(750, 50)));
            }
            else if (level == 1)
            {
                sound.play_Chased = true;

                useLighting = true;
                showText("Huh. what's happening? The lights went out.\nMaybe I should try to find the exit.");
                entities.Add(new Background(receptionFloorDirtyTexture));
                entities.Add(new SolidObject(deskDirtyTexture, new Vector2(170, 0)));
                entities.Add(new SolidObject(benchDirtyTexture, new Vector2(300, 550)));
                entities.Add(new SolidObject(plantDirtyTexture, new Vector2(50, 50)));
                entities.Add(new SolidObject(plantDirtyTexture, new Vector2(750, 50)));
                entities.Add(new Door(doorRightTexture, new Vector2(863, 300), 2, this));
                entities.Add(player);
            }
            else if (level == 2)
            {
                player.position = new Vector2(50, 50);
                showText("Click, the door is closed. I don't think I\ncan open it with all the enemies around.");
                useLighting = true;
                entities.Add(new Background(wardFloorTexture));
                entities.Add(new ShootingEnemy(enemyLeftTexture, this, new Vector2(700, 50), new Vector2(-1, 0)));
                entities.Add(new MovingEnemy(enemyLeftTexture, this, new Vector2(700, 400), new Vector2(-3, 0), 90));
                entities.Add(new MovingEnemy(enemyBackTexture, this, new Vector2(150, 600), new Vector2(0, -3), 90));
                entities.Add(new SolidObject(cleanBedTexture, new Vector2(250, 50)));
                entities.Add(new SolidObject(cleanBedTexture, new Vector2(450, 50)));
                entities.Add(new SolidObject(cleanBedTexture, new Vector2(250, 150)));
                entities.Add(new SolidObject(cleanBedTexture, new Vector2(450, 150)));
                entities.Add(new SolidObject(bloodyBedTexture, new Vector2(300, 300)));
                entities.Add(new SolidObject(bloodyBedBitsTexture, new Vector2(450, 300)));
                entities.Add(new SolidObject(bloodyBedTexture, new Vector2(600, 300)));
                entities.Add(new SolidObject(bloodyBedBitsTexture, new Vector2(200, 500)));
                entities.Add(new SolidObject(bloodyBedBitsTexture, new Vector2(350, 500)));
                entities.Add(new SolidObject(bloodyBedBitsTexture, new Vector2(500, 500)));
                entities.Add(new SolidObject(bloodyBedBitsTexture, new Vector2(650, 500)));
                entities.Add(new SolidObject(cabinetTexture, new Vector2(833, 50)));

                entities.Add(new Door(doorTexture, new Vector2(60, 0), 3, this));

                entities.Add(player);
            }
            else if (level == 3)
            {
                sound.play_asylum = true;

                showText("Sweet jesus!\nWhat are they doing to those people?\nI think they're electrocuting them!");
                player.position = new Vector2(50, 50);
                useLighting = false;
                entities.Add(new Background(electroFloorTexture));
                entities.Add(new SolidObject(electroMachineTexture, new Vector2(700, 100)));
                entities.Add(new SolidObject(electroMachineTexture, new Vector2(700, 300)));
                entities.Add(new SolidObject(electroMachineTexture, new Vector2(400, 100)));
                entities.Add(new SolidObject(electroMachineTexture, new Vector2(400, 300)));
                entities.Add(new SolidObject(cleanbed90Texture, new Vector2(300, 100)));
                entities.Add(new SolidObject(cleanbed90Texture, new Vector2(600, 100)));
                entities.Add(new SolidObject(cleanbed90Texture, new Vector2(600, 300)));
                entities.Add(new SolidObject(cleanbed90Texture, new Vector2(300, 300)));

                entities.Add(new SolidObject(cleanBedTexture, new Vector2(300, 500)));
                entities.Add(new SolidObject(cleanBedTexture, new Vector2(450, 500)));
                entities.Add(new SolidObject(cleanBedTexture, new Vector2(600, 500)));



                entities.Add(new SolidObject(cabinetLowerTexture, new Vector2(100, 600)));
                entities.Add(new SolidObject(cabinetLowerTexture, new Vector2(400, 600)));
                entities.Add(new SolidObject(cabinetLowerTexture, new Vector2(700, 600)));

                entities.Add(new SolidObject(nurseLeftTexture, new Vector2(670, 220)));

                entities.Add(new SolidObject(nurseForwardTexture, new Vector2(470, 450)));
                entities.Add(new SolidObject(normalperson1Texture, new Vector2(470, 480)));
                entities.Add(new SolidObject(normalperson2Texture, new Vector2(600, 200)));

                entities.Add(player);
                entities.Add(new Flash(flashTexture));
            }
            else if (level == 4)
            {
                sound.play_Chased = true;

                showText("Wait was that real?");

                player.position = new Vector2(50, 50);
                useLighting = true;
                entities.Add(new Background(electroFloorTexture));
                entities.Add(new SolidObject(electroMachineDirtyTexture, new Vector2(700, 100)));
                entities.Add(new SolidObject(electroMachineDirtyTexture, new Vector2(700, 300)));
                entities.Add(new SolidObject(electroMachineDirtyTexture, new Vector2(400, 100)));
                entities.Add(new SolidObject(electroMachineDirtyTexture, new Vector2(400, 300)));
                entities.Add(new SolidObject(cleanBedTexture, new Vector2(300, 500)));
                entities.Add(new SolidObject(cleanBedTexture, new Vector2(450, 500)));
                entities.Add(new SolidObject(cleanBedTexture, new Vector2(600, 500)));
                entities.Add(new SolidObject(bloodyBedBitsTexture, new Vector2(300, 100)));
                entities.Add(new SolidObject(bloodyBedTexture, new Vector2(600, 100)));
                entities.Add(new SolidObject(bloodyBedTexture, new Vector2(600, 300)));
                entities.Add(new SolidObject(cleanbed90Texture, new Vector2(300, 300)));

                entities.Add(new ShootingEnemy(enemyLeftTexture, this, new Vector2(700, 170), new Vector2(-1, 0)));
                entities.Add(new ShootingEnemy(enemyLeftTexture, this, new Vector2(400, 230), new Vector2(-1, 1)));
                entities.Add(new ShootingEnemy(enemyLeftTexture, this, new Vector2(600, 500), new Vector2(-1, 0)));
                entities.Add(new MovingEnemy(enemyLeftTexture, this, new Vector2(700, 20), new Vector2(-3, 0), 150));
                entities.Add(new MovingEnemy(enemyLeftTexture, this, new Vector2(700, 420), new Vector2(-3, 0), 90));

                entities.Add(new SolidObject(cabinetLowerTexture, new Vector2(100, 600)));
                entities.Add(new SolidObject(cabinetLowerTexture, new Vector2(400, 600)));
                entities.Add(new SolidObject(cabinetLowerTexture, new Vector2(700, 600)));

                entities.Add(new Door(doorTexture, new Vector2(60, 0), 98, this));


                entities.Add(player);
            }
            else if (level == 98)
            {
                useLighting = false;
                entities.Add(new WinScreen(winScreenTexture));
            }
            else if (level == 99)
            {
                useLighting = false;
                entities.Add(new DeathScreen(deadScreenTexture));
            }

        }

        protected override void UnloadContent()
        {
            
        }

        public void showText(String mytext)
        {
            text = mytext;
            textTimer = 200;
        }

        protected override void Update(GameTime gameTime)
        {
            sound.Update();

            if (player.health < 0)
            {
                loadLevel(99);
            }


            lighting.Update(player.position);

            textTimer--;
            if (textTimer < 0)
            {
                text = "";
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // defensive copy because we may add/remove something to the entity list
            List<Entity> copy = new List<Entity>(entities);
            foreach (Entity e in copy)
            {
                e.update(this, gameTime);
            }

            // do the defensive copy again
            copy = new List<Entity>(entities);
            foreach (Entity e in copy)
            {
                foreach (Entity e2 in copy)
                {
                    if (e != e2)
                    {
                        e.checkCollision(e2, this);
                    }
                }
            }

//            level_One_Map.Update(player.position);
//            level_Two_map.Update();
//            fade.Update();
//            hallway.Update();
//            if (show_hallway)
//                moving_Down_hall.Update(gameTime);

//            if (level_One_Map.exitLevel == true)
//            {
//                fade.fadeIn = true;
//                player.speed = 0;
//                player.position.X += 50;
//                level_One_Map.exitLevel = false;
//            }
            /*
            if (moving_Down_hall.exit_Hall_way)
            {
                if (moving_Down_hall.start_Level_Two)
                {
                    fade.fadeIn = true;
                    player.position.X += 50;
                    moving_Down_hall.exit_Hall_way = false;
                }
            }*/

  //          if (fade.switchToHallway)
  //              show_hallway = true;


            base.Update(gameTime);
        }

        private void drawMain(GameTime gameTime)
        {
            if (useLighting)
            {
                GraphicsDevice.SetRenderTarget(lighting.mainScene);
                GraphicsDevice.Clear(Color.Black);
            }
            /*
            if (moving_Down_hall.start_Level_Two == false)
                level_One_Map.Draw(spriteBatch);
            */
            spriteBatch.Begin();
            //Draw the scence
            foreach (Entity e in entities)
            {
                e.draw(spriteBatch);
            }

            /*
            if (show_hallway && moving_Down_hall.start_Level_Two == false)
            {
                hallway.Draw(spriteBatch);
                moving_Down_hall.Draw(spriteBatch);
            }
            if (moving_Down_hall.start_Level_Two)
            {
                level_Two_map.Draw(spriteBatch);
            }
            */
            fade.Draw(spriteBatch);

            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            drawMain(gameTime);

            if (useLighting)
            {
                lighting.Draw(gameTime, GraphicsDevice, spriteBatch);
            }

            spriteBatch.Begin();

            if (player.health >= 0)
            {
                spriteBatch.DrawString(font, player.health.ToString(), new Vector2(5, 5), Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            }
            spriteBatch.DrawString(font, text, new Vector2(100, 100), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
