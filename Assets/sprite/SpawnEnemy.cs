using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnEnemy : MonoBehaviour
{
    private Vector3 moveDirection;
    private float enemy = 1.0f; // Added this line to define the 'enemy' variable
    public GameObject EnemySpawn; // Reference to the spawn point
    public float Speed = 1f;
    //public GameObject laser;
    public int health = 50;
    public float spawncooldown;
    public bool canspawn = true;

    [Header("randomise spawm loction")]
    public float minValue;
    public float maxValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(SpawnEnemy());
        canspawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * enemy * Time.deltaTime);
        //move to postion


        // Start is called before the first frame update

        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if (transform.position.y <= -5.5f)
        {
            transform.position = new Vector3(Random.Range(-7, 7), 5.5f, 0);
            Instantiate(gameObject, transform.position, Quaternion.identity);
        }
    }
    //if(GameObject != null && canSpawm == true && Spawncooldown <0);
    //Start

    private void OnTriggerEnter2D(Collider2D playerbullet)
    {
        Destroy(gameObject);
    }
    public void TakeDamage()
    {
        health = health - 50;
    }
    
}
