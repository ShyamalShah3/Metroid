﻿using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Command.PlayerCommands;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.GameStates;

namespace CrossPlatformDesktopProject.Libraries.Controller
{
    public class KeyboardController : IController
    {
        //Written by Tristan Roman and Shyamal Shah and Nyigel Spann
        private Dictionary<Keys, ICommand> controllerPressMappings = new Dictionary<Keys, ICommand>();
        private Dictionary<Keys, ICommand> controllerReleaseMappings = new Dictionary<Keys, ICommand>();

        private KeyboardState oldState;
        private KeyboardState newState;
        private Game1 gameState;

        public KeyboardController(Game1 game)
        {
            oldState = Keyboard.GetState();
            gameState = game;
        }
        public void RegisterCommand(Keys key, ICommand releaseCommand)
        {
            if (!controllerReleaseMappings.ContainsKey(key))
            {
                controllerReleaseMappings.Add(key, releaseCommand);
            }
            else {
                controllerReleaseMappings[key] = releaseCommand;
            }
        }

        public void RegisterCommand(Keys key, ICommand pressCommand, ICommand releaseCommand)
        {
            if (!controllerPressMappings.ContainsKey(key))
            {
                controllerPressMappings.Add(key, pressCommand);
                controllerReleaseMappings.Add(key, releaseCommand);
            }
            else
            {
                controllerPressMappings[key] = pressCommand;
                controllerReleaseMappings[key] = releaseCommand;
            }
        }

        public void Update(GameTime gameTime)
        {
            newState = Keyboard.GetState();

            foreach (Keys key in oldState.GetPressedKeys())
            {
                if (controllerPressMappings.ContainsKey(key) && newState.IsKeyDown(key))
                {
                    controllerPressMappings[key].Execute();
                }
                else if (controllerReleaseMappings.ContainsKey(key) && !newState.IsKeyDown(key)) {
                    controllerReleaseMappings[key].Execute();
                }
                
            }

            oldState = newState;

        }


        public void MakePlayDict()     // If else of possible actions that updates choice
        {
            IPlayer player = GameObjectContainer.Instance.Player; // The player sprite

            controllerPressMappings.Clear();
            controllerReleaseMappings.Clear();

            RegisterCommand(Keys.Space, new PlayerJumpCommand(player));

            RegisterCommand(Keys.W, new PlayerAimUpCommand(player));
            RegisterCommand(Keys.Up, new PlayerAimUpCommand(player));

            RegisterCommand(Keys.S, new PlayerMorphCommand(player), new PlayerIdleCommand(player));
            RegisterCommand(Keys.Down, new PlayerMorphCommand(player), new PlayerIdleCommand(player));

            RegisterCommand(Keys.A, new PlayerMoveLeftCommand(player), new PlayerIdleCommand(player));
            RegisterCommand(Keys.Left, new PlayerMoveLeftCommand(player), new PlayerIdleCommand(player));

            RegisterCommand(Keys.D, new PlayerMoveRightCommand(player), new PlayerIdleCommand(player));
            RegisterCommand(Keys.Right, new PlayerMoveRightCommand(player), new PlayerIdleCommand(player));

            RegisterCommand(Keys.Z, new PlayerAttackCommand(player));
            RegisterCommand(Keys.N, new PlayerAttackCommand(player));

            RegisterCommand(Keys.C, new CycleBeamMissileCommand(player));

            RegisterCommand(Keys.Q, new QuitCommand(gameState));

            RegisterCommand(Keys.R, new RestartCommand(gameState));

            RegisterCommand(Keys.T, new CycleLevelCommand(gameState));

            RegisterCommand(Keys.F, new ToggleFullscreenCommand(gameState));

            RegisterCommand(Keys.K, new PlayNextThemeCommand());
            RegisterCommand(Keys.L, new ShuffleThemesCommand());
            RegisterCommand(Keys.O, new UnShuffleThemesCommand());
            RegisterCommand(Keys.P, new PauseGameCommand());

        }
        public void MakePausedDict()
        {
            IPlayer player = GameObjectContainer.Instance.Player; // The player sprite

            controllerPressMappings.Clear();
            controllerReleaseMappings.Clear();

            
            RegisterCommand(Keys.P, new UnpauseGameCommand());

        }
        public void MakeGameWinDict()
        {
            IPlayer player = GameObjectContainer.Instance.Player; // The player sprite

            controllerPressMappings.Clear();
            controllerReleaseMappings.Clear();


            RegisterCommand(Keys.R, new RestartCommand(gameState));

        }

        public void MakeMenuDict(IMenuState menuState)     // If else of possible actions that updates choice
        {

            controllerPressMappings.Clear();
            controllerReleaseMappings.Clear();


            RegisterCommand(Keys.W, new MenuUpCommand(menuState));
            RegisterCommand(Keys.Up, new MenuUpCommand(menuState));

            RegisterCommand(Keys.S, new MenuDownCommand(menuState));
            RegisterCommand(Keys.Down, new MenuDownCommand(menuState));

            RegisterCommand(Keys.A, new MenuLeftCommand(menuState));
            RegisterCommand(Keys.Left, new MenuLeftCommand(menuState));

            RegisterCommand(Keys.D, new MenuRightCommand(menuState));
            RegisterCommand(Keys.Right, new MenuRightCommand(menuState));

            RegisterCommand(Keys.Escape, new MenuExitCommand(menuState));

        }
    }
}

