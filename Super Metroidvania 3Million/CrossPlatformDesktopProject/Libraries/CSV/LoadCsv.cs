﻿using System.Linq;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.CSV.Object_Generators;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman
    public class LoadCsv
    {
        private int levelWidth;
        private int levelHeight;
        private static LoadCsv instance = new LoadCsv();

        public static LoadCsv Instance
        {
            get
            {
                return instance;
            }
        }

        public void Load(string levelName, Vector2 playerSpawn, Game1 game)
        {
            GameObjectContainer.Instance.Clear();

            GameObjectContainer.Instance.Player.UpdateLocation(playerSpawn);

            string projectPath = @"..\..\..\..\";
            string levelPath = projectPath + @"Libraries\Levels\" + levelName;

            string[] lines = File.ReadAllLines(levelPath);
            levelHeight = lines.Count();
            levelWidth = lines[0].Split(',').Length;

            //Game1.ChangeResolution(rows, columns);

            using (TextFieldParser parser = new TextFieldParser(levelPath))
            {
                int column = 0;
                int row;
                Vector2 location;
                //float cameraX = game.GetCamera().CameraPosition.X;
                //float cameraY = game.GetCamera().CameraPosition.Y;


                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    row = 0;
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {

                        location = new Vector2(row * 32 /* - cameraX */, column * 32 /* - cameraY */);

                        //Blocks
                        if (File.Exists(projectPath + @"Libraries\GameObjects\Blocks\" + field + ".cs"))
                        {
                            BlockObjectGenerator.Instance.createBlock(location, field);
                        }
                        //Items
                        else if (File.Exists(projectPath + @"Libraries\GameObjects\Items\Game Objects\" + field + ".cs"))
                        {
                            ItemObjectGenerator.Instance.createItem(location, field);
                        }
                        //Enemies
                        else if (File.Exists(projectPath + @"Libraries\GameObjects\Enemies\Game Objects\" + field + ".cs"))
                        {
                            EnemyObjectGenerator.Instance.createEnemy(location, field, game);
                        }
                        row++;
                    }
                    column++;
                }
            }
        }

        public Vector2 LevelDimensions()
        {
            return new Vector2(levelWidth, levelHeight);
        }

    }
}
