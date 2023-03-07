using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneric : MonoBehaviour
{
    public int fullHealth;
    public float currentHealth;
    public float speed;
    public int atk;

    public int pointGain;

    public Animator anim;

    /**
    public Animation death;
    public Animation attack;
    public Animation isHit;**/

    public GameObject drop;
    public GameObject player;

    public GameObject theBox;

    int seconds;
    float ct;

    public virtual void Start()
    {
        currentHealth = fullHealth;
        anim = gameObject.GetComponent<Animator>();

        seconds = 0;
        ct = 0; 
    }

    //death animation plays, drop happens
    public virtual void Die()
    {
        //instantitate drop
        GameObject toDrop = Instantiate(drop);
        toDrop.transform.position = gameObject.transform.position;

        GetComponent<BoxCollider2D>().enabled = false;

        player.GetComponent<PlayerScript>().UpdatePoints(pointGain);

        anim.SetBool("dead", true);
        //animation should call full death function at end
    }

    //gameobject is deleted
    public void FullDeath()
    {
        gameObject.SetActive(false);
    }

    //enemy attacks
    public void Attack()
    {
        anim.SetBool("attack", true);
    }

    //enemy moves
    public void Move()
    {
        //check nearness to player
        float closeX = player.transform.position.x - transform.position.x;
        float closeY = player.transform.position.y - transform.position.y;

        float closeness = Mathf.Sqrt(closeX + closeY);

        //Debug.Log(closeness);
        if (closeness <= 1)
        {
            Attack();
        }

            //pick if moving on x or y axis
            int coin = Random.Range(0,2);

            if (coin >= 1) //moving X
            {
            Debug.Log("X");
                if(player.transform.position.x > transform.position.x)
                {
                    theBox.transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                }
                else
                {
                    theBox.transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
                }
            }
            else //moving Y
            {
            Debug.Log("Y");
            if (player.transform.position.y > gameObject.transform.position.y) 
                {
                    theBox.transform.position = new Vector2(transform.position.x, transform.position.y+1f);
                }
                else
                {
                    theBox.transform.position = new Vector2(transform.position.x, transform.position.y-1f);
                }
            }
        //check layers
        
        if (player.transform.position.y > gameObject.transform.position.y)
            {
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "back";
            }
            else
            {
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "front";
        }
        

        /**
            if(player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            flipX = false;
        }**/
        

    }

    //enemy is hit
    public void IsHit()
    {
        anim.SetBool("hit", true);
        currentHealth -= 5;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    //tick time forwards
    public void Update()
    {
        ct += Time.deltaTime;

        if (ct >= 1)
        {
            seconds++;
            ct = 0;
        }
        if (seconds >= speed)
        {
            Move();
            seconds = 0;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Trying");
            transform.position = new Vector2(theBox.transform.position.x + 5, transform.position.y);
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enemy trigger");
        GameObject hit = other.gameObject;
        HitSomething(hit);
    }


    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enemy collision");
        GameObject hit = collision.gameObject;
        HitSomething(hit);
    }


    public void HitSomething(GameObject hit)
    {
        Debug.Log("hit function: " +hit.name);

        if (hit.CompareTag("Attack"))
        {
            IsHit();
        }
        else if (hit.CompareTag("Player"))
        {
            player.GetComponent<PlayerScript>().TakeDamage(atk);
        }
    }

    public void ClearTriggers()
    {
        anim.SetBool("hit", false);
        anim.SetBool("attack", false);
    }




}
