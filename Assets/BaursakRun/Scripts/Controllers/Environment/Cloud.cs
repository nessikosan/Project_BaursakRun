using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaursakRun.Controllers.Environment
{
    public class Cloud : Element
    {
        private float _speed;
        private Vector3 _startPosition;

        private void OnEnable()
        {
            OnTrigger += ResetCloud;
        }

        private void OnDisable()
        {
            OnTrigger -= ResetCloud;
        }
        protected override void Start()
        {
            base.Start();
            _startPosition = transform.localPosition;
            _speed = Random.Range(1.5f, 2.5f);
        }

        protected override void Update()
        {
            transform.localPosition += _speed * Time.deltaTime * -Vector3.right;
        }

        private void ResetCloud(Collider2D collider)
        {
            _speed = Random.Range(1.5f, 2.5f);
            transform.localPosition = new Vector3(_startPosition.x, Random.Range(4.7f, 8.5f), 0);
            Rigidbody.Sleep();
        }
    }

}

