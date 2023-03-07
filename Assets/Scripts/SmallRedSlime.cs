using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{

    public class SmallRedSlime : SmallSlimeGen
    {
        // Start is called before the first frame update
         public override void Start()
        {

            speed = 3;
            atk = 2;

            base.Start();
        }
    }

}