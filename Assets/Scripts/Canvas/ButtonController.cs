using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BirdGame
{
    [RequireComponent(typeof(Button))]
    public class ButtonController : MonoBehaviour
    {
        private enum ButtonType
        {
            Resume,
            Quit,
            Settings,
            MainMenu
        }
        [SerializeField] private ButtonType _buttonType;
        private CanvasManager _canvasManager;
        private Button _menuButton;

        private void Start()
        {
            _menuButton = GetComponent<Button>();
            _menuButton.onClick.AddListener(onButtonClicked);
            _canvasManager = CanvasManager.Instance;
        }

        private void onButtonClicked()
        {
            switch (_buttonType)
            {
                case ButtonType.Resume:
                    Manager.GameState = Manager.PreviousGameState;
                    _canvasManager.SwichCanvas(CanvasTypeEnum.Game);
                    break;
                case ButtonType.Quit:
                    Debug.Log("Quitting game");
                    break;
                case ButtonType.Settings:
                    _canvasManager.SwichCanvas(CanvasTypeEnum.Settings);
                    break;
                case ButtonType.MainMenu:
                    _canvasManager.SwichCanvas(CanvasTypeEnum.MainMenu);
                    break;
                default:
                    Debug.LogWarning(string.Format("Button Type {0} was not found", _buttonType));
                    break;
            }
        }
    }
}

