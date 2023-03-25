using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    public class Menu : MonoBehaviour
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
                    Manager.GameState = Manager.PreviousGameState;
                    _canvasManager.SwichCanvas(CanvasTypeEnum.Game);
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

