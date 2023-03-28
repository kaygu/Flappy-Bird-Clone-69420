using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager Instance { get; private set; }
        private CanvasManager _canvasManager;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogError("Could not instantiate MenuManager Singleton");
                Destroy(this);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            _canvasManager = CanvasManager.Instance;
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Manager.GameState == GameStateEnum.Menu)
                {
                    if (_canvasManager.ActiveCanvas.CanvasType == CanvasTypeEnum.Settings)
                    {
                        _canvasManager.SwitchCanvas(CanvasTypeEnum.MainMenu);
                    } 
                    else if (_canvasManager.ActiveCanvas.CanvasType == CanvasTypeEnum.MainMenu)
                    {
                        CloseMenu();
                    }
                    else
                    {
                        Debug.LogWarning("Unexpected menu behaviour ! Tried to unpause when " + _canvasManager.ActiveCanvas.CanvasType + "is active");
                    }

                } 
                else
                {
                    OpenMenu();
                }
            }
        }

        public void OpenMenu()
        {
            Manager.GameState = GameStateEnum.Menu;
            _canvasManager.SwitchCanvas(CanvasTypeEnum.MainMenu);
        }

        public void CloseMenu()
        {
            Manager.GameState = Manager.PreviousGameState;
            _canvasManager.SwitchCanvas(CanvasTypeEnum.Game);
            PlayerPrefs.Save();
        }
    }
}

