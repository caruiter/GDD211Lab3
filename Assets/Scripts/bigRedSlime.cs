using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class bigRedSlime : BigSlimeGen
    {
        public override void Start()
        {
            atk = 15;
            fullHealth = 10;

            base.Start();
        }


    }

}