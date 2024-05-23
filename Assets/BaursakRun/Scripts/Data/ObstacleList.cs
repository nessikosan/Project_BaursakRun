using BaursakRun.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaursakRun.Data
{
    [CreateAssetMenu(fileName = "ObstaclesData", menuName = "BaursakRaun/ObstaclesData")]
    public class ObstacleList : ScriptableObject
    {
       public List<ObstacleData> obstacleDatas = new List<ObstacleData>();

    }

}

