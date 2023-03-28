using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    public class SettingsMenu : MonoBehaviour
    {
        private CanvasManager _canvasManager;
        private void Start()
        {
            _canvasManager = CanvasManager.Instance;
        }

        public void Back()
        {
            // Back to main menu
            _canvasManager.SwichCanvas(CanvasTypeEnum.MainMenu);
        }

        public void  SFXSlider(float _volume)
        {
            Debug.Log("SFX : " + _volume);
        }

        public void MusicSlider(float _volume)
        {
            Debug.Log("Music : " + _volume);
        }
    }
}

