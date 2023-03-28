using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace BirdGame
{
    public class SettingsMenu : MonoBehaviour
    {
        private CanvasManager _canvasManager;
        [SerializeField] private AudioMixer _mixer;
        [SerializeField] private Slider _sfxSlider;
        [SerializeField] private Slider _musicSlider;

        private const float _defaultSliderValue = .7f;
        private void Start()
        {
            _canvasManager = CanvasManager.Instance;
            _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", _defaultSliderValue);
            _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", _defaultSliderValue);
        }

        public void Back()
        {
            // Back to main menu
            _canvasManager.SwitchCanvas(CanvasTypeEnum.MainMenu);
        }

        public void  SFXSlider(float _volume)
        {
            _mixer.SetFloat("MasterVolume", Mathf.Log10(_volume) * 20);
            PlayerPrefs.SetFloat("SFXVolume", _volume);
        }

        public void MusicSlider(float _volume)
        {
            _mixer.SetFloat("MusicVolume", Mathf.Log10(_volume) * 20);
            PlayerPrefs.SetFloat("MusicVolume", _volume);
        }
    }
}

