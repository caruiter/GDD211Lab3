using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class SmallSlimeGen : EnemyGeneric
    {

        // Start is called before the first frame update
        public override void Start()
        {
            fullHealth = 4;
            pointGain = 3;

            base.Start();

        }

    }
}

