using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace BirdGame
{
    public class CanvasManager : MonoBehaviour // Singleton
    {
        public static CanvasManager Instance { get; private set; }

        private List<CanvasController> _canvasControllerList;
        public CanvasController ActiveCanvas;
        

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogError("Could not instantiate CanvasManager Singleton");
                Destroy(this);
                return;
            }
            Instance = this;

            _canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
            _canvasControllerList.ForEach(x => DisableCanvas(x));
            SwitchCanvas(CanvasTypeEnum.BestScore);
        }

        private void Update()
        {
            if (Manager.GameState == GameStateEnum.Waiting || Manager.GameState == GameStateEnum.Dead)
            {
                SwitchCanvas(CanvasTypeEnum.BestScore);
            } else if (Manager.GameState == GameStateEnum.Flying)
            {
                SwitchCanvas(CanvasTypeEnum.Game);
            }
        }

        public void SwitchCanvas(CanvasTypeEnum _type)
        {
            if (ActiveCanvas != null)
            {
                if (ActiveCanvas.CanvasType == _type) return;
                DisableCanvas(ActiveCanvas);
            }
            CanvasController desiredCanvas = _canvasControllerList.Find(x => x.CanvasType == _type);
            if (desiredCanvas != null)
            {
                EnableCanvas(desiredCanvas);
                ActiveCanvas = desiredCanvas;
            } else
            {
                Debug.LogWarning(string.Format("Canvas {0} was not found!", _type));
            }
        }
        private void DisableCanvas(CanvasController _canvasCtlr)
        {
            _canvasCtlr.gameObject.SetActive(false);
        }
        private void EnableCanvas(CanvasController _canvasCtlr)
        {
            _canvasCtlr.gameObject.SetActive(true);
        }
    }
}

