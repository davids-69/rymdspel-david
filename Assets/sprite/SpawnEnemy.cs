using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    bool canSpawn = false;
    public int enemyCounter = 0;
    public Vector2 spawnPosition;
    public float spawnTimer = 1;
    public float Speed = 4f;


    void Start()
    {
        StartCoroutine(spawnEnemy());
        canSpawn = true;
    }

    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
        if  (transform.position.y <=4)
        {
            transform.position = new Vector3(Random.Range(-5f, 5f), 6, 0);
        }

    }

    //if(GameObject != null && canSpawm == true && Spawncooldown <0);
    //Start

    private IEnumerator spawnEnemy()
    {
        while (true)
        {
            if (enemyCounter < 100)
            {
                if (player.GetComponent<playerscript>().lives >= 0)
                {
                    spawnPosition = new Vector2(Random.Range(-8, 8), 5.5f);
                    spawnTimer = Random.Range(3, 4);

                    Instantiate(enemy, spawnPosition, Quaternion.identity);
                    enemyCounter++;
                    yield return new WaitForSeconds(spawnTimer);

                }
            }
            else yield return null;
        }
    }   
}

