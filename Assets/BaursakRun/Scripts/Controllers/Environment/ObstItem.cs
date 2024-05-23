using BaursakRun.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;


namespace BaursakRun.Controllers.Environment
{
    public class ObstItem : MonoBehaviour, IObstacle
    {           
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rigidbody;      
      
        private void Update()
        {
            MoveObstacle();
        }
        protected virtual void DamagePlayer(IPlayer player)
        {
            player.TakeDamage();
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
            if(collision.gameObject.GetComponent<IPlayer>() is IPlayer player)
            {
                DamagePlayer(player);             
                Destroy(this.gameObject);
            }
           
        }               
        public void MoveObstacle()
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);

        }

    }
}


