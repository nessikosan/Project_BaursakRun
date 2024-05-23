using BaursakRun.Controllers.Environment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaursakRun.Data
{
    [CreateAssetMenu(fileName = "EnvData", menuName ="BaursakRun/EnvData")]
   public class EnvData : ScriptableObject
   {
            public List<Element> elements = new List<Element> ();
   } 

}

