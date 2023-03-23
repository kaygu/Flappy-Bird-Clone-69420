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
        Invalid

    }
    public static class Manager
    {
        public static GameStateEnum GameState;

        public static bool Init()
        {
            // Check textures & prefabs are not missing
            GameState = GameStateEnum.Waiting;
            return true;
        }
    }
}

