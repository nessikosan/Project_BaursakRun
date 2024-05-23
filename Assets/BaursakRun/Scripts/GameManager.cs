using BaursakRun.Controllers;
using BaursakRun.Data;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace BaursakRun
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Button _play;
        [SerializeField] private Button _quit;
        [SerializeField] private GameObject _mainMenu;  
        [SerializeField] private PlayScreen _screen;
        [SerializeField] private GameObject _playScreen;
        [SerializeField] private GameObject _endScreen;
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private BaursakController _baursak;      
                 
        private void OnEnable()
        {
            _play.onClick.AddListener(StartGame);
            _quit.onClick.AddListener(Quit);
            _baursak.OnBaursakControllerDisabled += OnBaursakControllerDisabled;
           
        }          
        private void OnDisable()
        {
            _baursak.OnBaursakControllerDisabled -= OnBaursakControllerDisabled;
        }
        private void OnBaursakControllerDisabled()
        {
            _endScreen.SetActive(true);
           _playScreen.SetActive(false);
           _pausePanel.SetActive(false);
        }
        public void StartGame()
        {           
            _playScreen.SetActive(true);
            _baursak.gameObject.SetActive(true);
           _pausePanel.gameObject.SetActive(false);
            _mainMenu.SetActive(false);           
        }     
        public void Quit()
        {
            Application.Quit();
        }       
    }

}

