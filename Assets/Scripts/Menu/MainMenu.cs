using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    public class MainMenu : MonoBehaviour
    {
        private CanvasManager _canvasManager;
        private void Start()
        {
            _canvasManager = CanvasManager.Instance;
        }
        public void Resume()
        {
            if (Manager.GameState == GameStateEnum.Menu)
            {
                Manager.GameState = Manager.PreviousGameState;
                _canvasManager.SwichCanvas(CanvasTypeEnum.Game);
            }
            else
            {
                Debug.LogWarning("Tried to Resume game when game was not paused");
            }
        }

        public void Settings()
        {
            _canvasManager.SwichCanvas(CanvasTypeEnum.Settings);
        }

        public void Quit()
        {
            Debug.Log("Quitting game");
        }
    }
}

