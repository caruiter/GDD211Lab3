using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class bigBlueSlime : BigSlimeGen
    {
        public override void Start()
        {
            atk = 10;
            fullHealth = 15;

            base.Start();
        }
        

    }

}
