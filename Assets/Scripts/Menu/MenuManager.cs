using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    public class MenuManager : MonoBehaviour
    {
        private CanvasManager _canvasManager;

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
                        _canvasManager.SwichCanvas(CanvasTypeEnum.MainMenu);
                    } 
                    else if (_canvasManager.ActiveCanvas.CanvasType == CanvasTypeEnum.MainMenu)
                    {
                        Manager.GameState = Manager.PreviousGameState;
                        _canvasManager.SwichCanvas(CanvasTypeEnum.Game);
                    }
                    else
                    {
                        Debug.LogWarning("Unexpected menu behaviour ! Tried to unpause when " + _canvasManager.ActiveCanvas.CanvasType + "is active");
                    }

                } 
                else
                {
                    Manager.GameState = GameStateEnum.Menu;
                    _canvasManager.SwichCanvas(CanvasTypeEnum.MainMenu);
                }
            }
        }
    }
}

