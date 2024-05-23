using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaursakRun.Data
{
    public enum ObstacleType
    {
        Enemy,
        Food
    }
    [CreateAssetMenu(fileName = "Obstacle", menuName = "BaursakRaun/ObstacleData")]
    public class ObstacleData : ScriptableObject
    {
        public GameObject Prefab;                 
        public ObstacleType ObstacleType;
       
    }
  
}


