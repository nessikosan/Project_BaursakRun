using BaursakRun.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace BaursakRun.Controllers
{
  public class BaursakController : MonoBehaviour,IPlayer
  {
        public event Action OnBaursakControllerDisabled;
     
        private Rigidbody2D _rb;     
        [SerializeField] private float _jumpForce;     
        [SerializeField] private GameObject[] _lifes;
        [SerializeField] private TMP_Text _scoretext;
        [SerializeField] private TMP_Text _highScore;
        [SerializeField] private GameObject _endScreen;
        [SerializeField] private GameOver _gameOver;
        [SerializeField] private GameObject _playScreen;
        [SerializeField] private AudioSource _playerSound;
        [SerializeField] private AudioClip[] sound;
       
        public static int _score;
        private bool _isground = false;      
        private int _health = 5 ;
        private Animator _animator;

        private void OnEnable()
        {   
            _animator = GetComponent<Animator>();          
            _gameOver.OnGameRestarted += OnGameRestarted;         
        }
        private void OnDisable()
        {
            gameObject.SetActive(false);         
            OnBaursakControllerDisabled?.Invoke();
            ShowEndScreen();
            DataManager.instance.LoadData();
            _highScore.text = DataManager.instance.scoreInfo.highScore.ToString();
        }
        private void ShowEndScreen()
        {
            _gameOver.ShowEndScreen(int.Parse(_scoretext.text));
        }        
       private void OnGameRestarted()
       {
            gameObject.SetActive(true);
            _score = 0;
            _health = 5;        
            foreach (var l in _lifes)
            {
               l.gameObject.SetActive(true );
            }
       }
        void Start()
        {
            InitBaursak();
            _health = _lifes.Length;
            _score = 0;          
            _score = DataManager.instance.scoreInfo.score;
            _scoretext.text = _score.ToString();
            DataManager.instance.LoadData();
           _highScore.text = DataManager.instance.scoreInfo.highScore.ToString();
        }

        private void InitBaursak()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
           
        }
        private void Update()
        { 
            try
            {
                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began&& _isground == true)
                {
                     Jump();
                    _animator.Play("BaursakJump");
                } 
                
                if(touch.phase == TouchPhase.Ended  && _isground == true)
                {
                     _animator.Play("BaursakRun");
                }
            }
            catch (System.Exception)
            {

            }
        }
        private void Jump()
        {
            //  _rb.AddForce(new Vector2(0, _jumpForce));
            _rb.AddForce(Vector2.up *_jumpForce, ForceMode2D.Impulse);
            _isground = false;           
            _score++;
            UpdateScore();
            CheckHighScore();
            PlaySound(sound[0]);
        }     
        public void TakeDamage()
        {
           // _rb.AddForce(Vector2.up * _jumpForce);
            if (_health >= 1)
            {
               _health = _health - 1;

                _lifes[_health].gameObject.SetActive(false);
                PlaySound(sound[1]);
                            
               if (_health < 1)
               {                 
                    PlaySound(sound[3]);
                    OnDisable();
                    UpdateScore();
                    CheckHighScore();
                   DataManager.instance.SaveData();
                    
               }  
            }           
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                if (_isground == false)
                {
                    _isground = true;
                }
            }
        }
        public void IncreaseScore(int amount)
        {
            _score += amount;
            UpdateScore();
            CheckHighScore();
            PlaySound(sound[2]);
        }
        public void DecreaseScore(int amount)
        {
           _score -= amount;

            if(_score <= 0)
            {
                _score = 0;
            }
            UpdateScore();
            CheckHighScore();
            PlaySound(sound[2]);
        }
        private void CheckHighScore()
        {
           if (_score > DataManager.instance.scoreInfo.highScore)
           {
                DataManager.instance.scoreInfo.highScore = _score;
                DataManager.instance.SaveData();
           }
        }
       private void UpdateScore()
       {
            _scoretext.text = _score.ToString();
            DataManager.instance.scoreInfo.score = _score;
            DataManager.instance.SaveData();
       }
        public void PlaySound(AudioClip sound)
        {
            _playerSound.clip = sound;
            _playerSound.Play();
        }
   }

}

