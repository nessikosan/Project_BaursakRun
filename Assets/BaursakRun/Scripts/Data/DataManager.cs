using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BaursakRun.Data
{
   public class DataManager : MonoBehaviour
   {
      public static DataManager instance;
      public ScoreInfo scoreInfo;
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
        }
        public void SaveData()
        {
            string json = JsonUtility.ToJson(scoreInfo);
            string path = Path.Combine(Application.persistentDataPath + "GameScore.json");
            File.WriteAllText(path, json);           
        }

        public void LoadData()
        {
            if(File.Exists(Application.persistentDataPath + "GameScore.json"))
            {
                string path = Path.Combine(Application.persistentDataPath + "GameScore.json");
                scoreInfo = JsonUtility.FromJson<ScoreInfo>(File.ReadAllText(path));
            }

        }
   }

    [Serializable]

    public class ScoreInfo
    {
        public int score;
        public int highScore;
    }
}

