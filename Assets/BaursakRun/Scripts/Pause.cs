using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace BaursakRun
{
   public class Pause : MonoBehaviour
   {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _playScreen;
       
        private void OnEnable()
        {
           
        }
        public void PauseButtonPressed()
        {
            _playScreen.SetActive(false);
            _pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }

        public void PauseButtonUnPressed()
        {
            _pausePanel.SetActive(false);
            _playScreen.SetActive(true);
            Time.timeScale = 1f;
        }
       
    }

}
