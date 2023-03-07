using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://docs.unity3d.com/ScriptReference/Random-insideUnitCircle.html

namespace Inheritance
{
    public class BigSlimeGen : EnemyGeneric
    {
        
        
        public override void Start()
        {
            //int fullhealth = 15;
            speed = 3;
            pointGain = 3;
            base.Start();
        }


        public GameObject babySlimes;
        public GameObject babySlimesDrop;


        public override void Die()
        {
            player.GetComponent<PlayerScript>().points += pointGain;

            anim.SetBool("dead", true);
            GameObject todrop = Instantiate(drop);
            todrop.transform.position = transform.position;

            //instantiate 2 small slimes
            //assign drops of baby slimes
            for (int a = 0; a < 2; a++)
            {
                GameObject baby = Instantiate(babySlimes);
                Vector2 great = Random.insideUnitCircle*1;

                baby.transform.position = new Vector2(great.x +transform.position.x, great.y + transform.position.y);




                SmallSlimeGen babyscript = baby.GetComponentInChildren<SmallSlimeGen>();
                babyscript.drop = babySlimesDrop;
                babyscript.player = player;

                //babyscript.anim = 
            }


        }




    }
}

