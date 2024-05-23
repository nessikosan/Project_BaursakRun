using BaursakRun.Data;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BaursakRun.Controllers
{
    public class ObstController : MonoBehaviour
    {  
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private ObstacleList _listObst;

        private void Start()
        {
            StartCoroutine(Spawn());
        }
        public IEnumerator Spawn()
        {
            while (true)
            {
                var pointIndex = Random.Range(0, _spawnPoints.Count);
                var objectIndex = Random.Range(0, _listObst.obstacleDatas.Count);
                
                Instantiate(_listObst.obstacleDatas[objectIndex].Prefab, _spawnPoints[pointIndex].transform.position, Quaternion.identity);

                yield return new WaitForSeconds(Random.Range(1, 2.5f));
            }
        }
    }
}
 