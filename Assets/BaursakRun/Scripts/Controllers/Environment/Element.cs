using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaursakRun.Controllers.Environment
{
  public class Element : MonoBehaviour
  {
        protected Action<Collider2D> OnTrigger;
        protected Rigidbody2D Rigidbody;
        protected virtual void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        protected virtual void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnTrigger?.Invoke(collision);
        }
    } 
}

