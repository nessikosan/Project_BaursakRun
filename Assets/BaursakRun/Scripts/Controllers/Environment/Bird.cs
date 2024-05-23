using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaursakRun.Controllers.Environment
{
   public class Bird : Element
   {
        private float _speed;
        private Vector3 _startPosition;
     
        private void OnEnable()
        {
            OnTrigger += ResetBird;
        }

        private void OnDisable()
        {
            OnTrigger -= ResetBird;
        }
        protected override void Start()
        {
            base.Start();
            _startPosition = transform.localPosition;
            _speed = Random.Range(2.5f,4.5f);
        }

        protected override void Update()
        {
            transform.localPosition += _speed * Time.deltaTime * -Vector3.right;
        }

        private void ResetBird(Collider2D collider)
        {
            _speed = Random.Range(2.5f, 4.5f);
            transform.localPosition = new Vector3(_startPosition.x, Random.Range(5.1f,8.7f), 0);
            Rigidbody.Sleep();
        }
   }
}

