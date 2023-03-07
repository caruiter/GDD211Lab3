using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{

    public class SmallBlueSlime : SmallSlimeGen
    {
        // Start is called before the first frame update
        public override void Start()
        {

            speed = 2;
            atk = 3;

            base.Start();
        }

    }
}
