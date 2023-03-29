using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    public class MainMenu : MonoBehaviour
    {
        private CanvasManager _canvasManager;
        private MenuManager _menuManager;
        private void Start()
        {
            _canvasManager = CanvasManager.Instance;
            _menuManager = MenuManager.Instance;
        }
        public void Resume()
        {
            _menuManager.PlaySelectSound();
            if (Manager.GameState == GameStateEnum.Menu)
            {
                _menuManager.CloseMenu();
            }
            else
            {
                Debug.LogWarning("Tried to Resume game when game was not paused");
            }
        }

        public void Settings()
        {
            _menuManager.PlaySelectSound();
            _canvasManager.SwitchCanvas(CanvasTypeEnum.Settings);
        }

        public void Quit()
        {
            _menuManager.PlaySelectSound();
            Debug.Log("Quitting game");
        }
    }
}

