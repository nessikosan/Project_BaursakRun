using BaursakRun.Controllers;
using BaursakRun.Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Zenject;

namespace BaursakRun
{
   public class PlayScreen : MonoBehaviour
   {
        [SerializeField] private TMP_Text _scoretext;
        [SerializeField] private Image _scoreBerry;
        [SerializeField] private Button _pause;
        

       
        public void ShowPlayScreen(int score)
        {
            _scoretext.text = score.ToString();
        }
      

    } 
}

