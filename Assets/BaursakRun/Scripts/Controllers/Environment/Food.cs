using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BaursakRun.Controllers.Environment
{
   public class Food : MonoBehaviour,IObstacle
   {
      [SerializeField] private float _speed;
      [SerializeField] private Rigidbody2D _rigidbody;      
       public bool isIncrease;
       private int amount = 5;
        
        private void Update()
        {
            MoveObstacle();
        }

      private void OnTriggerEnter2D(Collider2D collision)
      {
            if (collision.gameObject.CompareTag("Destroy"))
            {
                Destroy(this.gameObject);
            }
      }
      private void OnCollisionEnter2D(Collision2D collision)
      {
        if (collision.gameObject.GetComponent<IPlayer>() is IPlayer player)
        {                       
               if(isIncrease)
               {
                    AddScore(player);           
               }
               else
               {
                    ReduceScore(player);                   
               }      
                Destroy(this.gameObject);
        }           
      }        
        private void AddScore(IPlayer player)
        {
            player.IncreaseScore(amount);
        }
        private void ReduceScore(IPlayer player)
        {
            player.DecreaseScore(amount);
        }
        public void MoveObstacle()
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
    }
}

