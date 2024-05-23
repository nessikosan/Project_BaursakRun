using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BaursakRun.Controllers;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using BaursakRun.Data;
using Zenject.SpaceFighter;
using Unity.VisualScripting;
using BaursakRun;

namespace BaursakRun
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _endScreen;
        [SerializeField] private Image _img;
        [SerializeField] private Image _eaten;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private TMP_Text _highScore;
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exit;        
        [SerializeField] private BaursakController _baursak;     
        [SerializeField] private GameObject _playScreen;
   
        public event Action OnGameRestarted;
                
        private int score;
        private int onClick;
        private void OnEnable()
        {            
            _exit.onClick.AddListener(ExitGame);
            _restart.onClick.AddListener(RestartGame);
        }
        private void Start()
        {          
            _baursak.GetComponent<BaursakController>();
            score = BaursakController._score;            
        }
        public void ShowEndScreen(int score)
        {
            _score.text = score.ToString();
           
        }
        public void ExitGame()
        {
            Application.Quit();
        }                    
        public void RestartGame()
        {           
            _baursak.gameObject.SetActive(true);
            _playScreen.SetActive(true);
             _endScreen.SetActive(false);
            OnGameRestarted?.Invoke();
         
        }    
    }
}

