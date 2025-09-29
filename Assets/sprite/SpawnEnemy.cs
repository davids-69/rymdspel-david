using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    bool canSpawn = false;
    public static int enemyCounter = 0;
    private float spawnTimer = 1;


    void Start()
    {
        StartCoroutine(spawnEnemy());
        canSpawn = true;
    }

    void Update()
    {

    }
    //if(GameObject != null && canSpawm == true && Spawncooldown <0);
    //Start

    private IEnumerator spawnEnemy()
    {
        while (true)
        {
            if (enemyCounter < 100 && GameObject.Find("player") != null)
            {
                Instantiate(enemy, new Vector3(0, 5.6f, 0), Quaternion.identity);
                enemyCounter++;
                yield return new WaitForSeconds(spawnTimer);
            }
            else yield return null;
        }
    }   
}

