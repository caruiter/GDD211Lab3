using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float health;
    public int points;
    public float speed;

    public Animator anim;
    public GameObject attack;

    public GameObject EndScreen;
    public TextMeshProUGUI pointScore;
    public TextMeshProUGUI healthTracker;

    public bool gamedone;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        EndScreen.SetActive(false);
        health = 100;
        gamedone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamedone == false)
        {

            //moving left or right
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = new Vector2(transform.position.x - speed, transform.position.y);

               
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = new Vector2(transform.position.x + speed, transform.position.y);

            }

            //moving up or down
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + speed);
               
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed);

            }

            if (transform.position.x < -8.5)
            {
                transform.position = new Vector2(-8.5f, transform.position.y);
            }
            else if (transform.position.x > 8.5)
            {
                transform.position = new Vector2(8.5f, transform.position.y);
            }
            if (transform.position.y > 4.3)
            {
                transform.position = new Vector2(transform.position.x, 4.3f);
            }
            else if (transform.position.y < -4.3)
            {
                transform.position = new Vector2(transform.position.x,- 4.3f);
            }

            //attacking
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }

    }

    //player hit by attack
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthTracker.text = "Health: " + health;

        //check if out of health
        if (health <= 0)
        {
            GameOver();
        }
    }

    //called from outside
    public void Attack()
    {
        anim.SetBool("attack", true);

    }
    //called by animation?
    public void EndAttack()
    {
        anim.SetBool("attack", false);
    }

    //game over, player dead
    public void GameOver()
    {
        EndScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void UpdatePoints(int earned)
    {
        points += earned;
        pointScore.text = "Points: " + points;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("player HIT");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy");
            other.GetComponent<EnemyGeneric>().HitSomething(gameObject);
        }
        
        
    }

    //control layers of attack
    public void ToggleAttack(int front)
    {
        if (front == 1)
        {
            attack.GetComponent<SpriteRenderer>().sortingLayerName = "front";
        }
        else
        {
            attack.GetComponent<SpriteRenderer>().sortingLayerName = "back";
        }
        
    }

    public void AddHealth()
    {
        health += 5;
        healthTracker.text = "Health: " + health;
    }
}
