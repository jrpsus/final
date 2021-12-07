using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float cooldown;
    public int spawnsRemaining = 7;
    public int level = 1;
    public Text levelText;
    public PlayerControls playerControls;
    public GameObject small;
    public GameObject normal;
    public GameObject large;
    public GameObject xl;
    void Start()
    {
        playerControls = GameObject.Find("Player").GetComponent<PlayerControls>();
    }
    private void MoveRandomly()
    {
        Vector3 spawnHere = new Vector3(Random.Range(-11.0f, 11.0f), 7, 0);
        transform.position = spawnHere;
    }
    private void SpawnSomething()
    {
        if (level <= 2)
        {
            Instantiate(small, transform.position, Quaternion.identity);
        }
        MoveRandomly();
        if (level >= 2 && level <= 4)
        {
            Instantiate(small, transform.position, Quaternion.identity);
        }
        MoveRandomly();
        if (level >= 3 && level <= 7)
        {
            Instantiate(normal, transform.position, Quaternion.identity);
        }
        MoveRandomly();
        if (level == 7)
        {
            Instantiate(small, transform.position, Quaternion.identity);
            MoveRandomly();
            Instantiate(small, transform.position, Quaternion.identity);
            MoveRandomly();
            Instantiate(small, transform.position, Quaternion.identity);
        }
        MoveRandomly();
        if (level >= 8 && level <= 11)
        {
            Instantiate(large, transform.position, Quaternion.identity);
        }
        MoveRandomly();
        if (level >= 10 && level <= 11)
        {
            Instantiate(normal, transform.position, Quaternion.identity);
            MoveRandomly();
            Instantiate(normal, transform.position, Quaternion.identity);
        }
        MoveRandomly();
        if (level == 15)
        {
            Instantiate(normal, transform.position, Quaternion.identity);
            MoveRandomly();
            Instantiate(normal, transform.position, Quaternion.identity);
            MoveRandomly();
            Instantiate(normal, transform.position, Quaternion.identity);
            MoveRandomly();
            Instantiate(normal, transform.position, Quaternion.identity);
        }
        MoveRandomly();
        if (level >= 12 && level != 15)
        {
            Instantiate(xl, transform.position, Quaternion.identity);
        }
        MoveRandomly();
        if (level >= 20)
        {
            Instantiate(large, transform.position, Quaternion.identity);
            MoveRandomly();
            Instantiate(large, transform.position, Quaternion.identity);
            MoveRandomly();
            Instantiate(large, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            if (level <= 20)
            {
                cooldown += 3.2f - (level / 10);
            }
            else
            {
                cooldown = 1;
            }
            MoveRandomly();
            SpawnSomething();
            spawnsRemaining -= 1;
            if (spawnsRemaining <= 0)
            {
                level += 1;
                playerControls.money += 10 * level;
                spawnsRemaining = level * 2;
                levelText.text = "LEVEL " + level;
            }
        }
    }
}
