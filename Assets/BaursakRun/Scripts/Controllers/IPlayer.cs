using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaursakRun.Controllers
{
   public interface IPlayer 
   {
        void  TakeDamage();
        void IncreaseScore(int amount);
        void DecreaseScore(int amount);
   }  
}

