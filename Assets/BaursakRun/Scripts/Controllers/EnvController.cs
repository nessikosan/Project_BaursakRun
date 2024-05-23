using BaursakRun.Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BaursakRun.Controllers
{
  public class EnvController : MonoBehaviour
  {
        [SerializeField] private GameObject _env;
        [SerializeField] private GameObject _envNew;
        [SerializeField] private float _mergeDistance;
        [SerializeField] private EnvData _envData;
      

        private Vector3 _startPosition;

        void Start()
        {                       
             _startPosition = _env.transform.localPosition;
                foreach (var Element in _envData.elements)
                {
                    var obj = Instantiate(Element, Vector3.zero, Quaternion.identity, transform);
                    obj.transform.localPosition = new Vector3(Random.Range(14, 22), Random.Range(5.1f, 8.8f), 0);
                }
        }
      
        void Update()
        {           
            _env.transform.localPosition += 5.5f * Time.deltaTime * -Vector3.right;

                 if (_env.transform.localPosition.x < 2.5)
                 {
                   if (!_envNew)
                   {
                    _envNew = Instantiate(_env, new Vector3(18, 3.48f, 0), Quaternion.identity, transform);
                    _envNew.transform.localPosition = new Vector3(_mergeDistance, 3.48f, 0);
                   }
                 }

                if (_envNew)
                {
                     _envNew.transform.localPosition += 5.5f * Time.deltaTime * -Vector3.right;
 
                    if (_envNew.transform.localPosition.x < 2.5)
                    {
                         Destroy(_envNew);
                         _env.transform.localPosition = _startPosition;
                    }
                }                                                                                        
        }


  }
}

