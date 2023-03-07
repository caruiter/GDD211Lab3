using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerScript : MonoBehaviour
{

    public GameObject BigBlueSlimePrefab;
    public GameObject BigRedSlimePrefab;
    public GameObject SmallBlueSlimePrefab;
    public GameObject SmallRedSlimePrefab;

    public GameObject player;
    public GameObject toDrop;

    public GameObject instructions;

    private float ct;
    private int sec;
    private int fullTime;


    // Start is called before the first frame update
    void Start()
    {
        ct = 0;
        sec = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerScript>().gamedone == false)
        {
            ct += Time.deltaTime;
            if (ct >= 1)
            {
                ct = 0;
                sec++;
            }
        }


        //every so often, instantiate new enemy
        if (sec >= 10)
        {
            sec = 0;
            int randomize = Random.Range(0, 6);
            switch (randomize)
            {
                case 0: Create(SmallBlueSlimePrefab); break;
                case 1: Create(SmallRedSlimePrefab); break;
                case 2: Create(BigBlueSlimePrefab); break;
                case 3: Create(BigBlueSlimePrefab); break;
                case 4: Create(BigRedSlimePrefab); break;
                case 5: Create(BigRedSlimePrefab); break; 
                default: Create(SmallBlueSlimePrefab); break;
            }
            instructions.SetActive(false);
        }
    }

    public void Create(GameObject what)
    {
        GameObject created = Instantiate(what);

        int where = Random.Range(0, 2);

        if(where == 0)
        {
            created.transform.position = new Vector2(-8,0);
        }
        else
        {
            created.transform.position = new Vector2(8,0);
        }

        //assign variables based on enemy type
        if (what.name.Contains("Big"))
        {
            Inheritance.BigSlimeGen cScript = created.GetComponentInChildren<Inheritance.BigSlimeGen>();
            cScript.drop = toDrop;
            cScript.babySlimesDrop = toDrop;
            if (what.name.Contains("Red"))
            {
                cScript.babySlimes = SmallRedSlimePrefab;
            }
            else
            {
                cScript.babySlimes = SmallBlueSlimePrefab;
            }
        }
        else
        {
            Inheritance.SmallSlimeGen cScript = created.GetComponentInChildren<Inheritance.SmallSlimeGen>();
            cScript.drop = toDrop;
        }

        EnemyGeneric eScript = created.GetComponentInChildren<EnemyGeneric>();
        eScript.player = player;

    }

    public void RestartGame()
    {
        Debug.Log("scene?");
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
