using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    public enum GameStateEnum
    {
        Waiting,
        Flying,
        Dead,
        Invalid,
        Menu
    }

    public enum CanvasTypeEnum
    {
        Game,
        MainMenu,
        Settings,
        BestScore
    }
    public static class Manager
    {
        private static GameStateEnum _gameState;
        public static GameStateEnum PreviousGameState { get; private set; }

        public static bool Init()
        {
            // Check textures & prefabs are not missing
            GameState = GameStateEnum.Waiting;
            return true;
        }

        public static GameStateEnum GameState
        {
            get
            {
                return _gameState;
            }
            set
            {
                PreviousGameState = _gameState;
                _gameState = value;
            }
        }
    }
}

