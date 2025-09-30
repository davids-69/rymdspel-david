using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class enemyscript : MonoBehaviour
{
    private Vector3 moveDirection;
    public float enemy = 1.0f; // Added this line to define the 'enemy' variable
    public GameObject enemyspawner; // Reference to the spawn point
    public float Speed = 1f;
    public GameObject laser;
    public int health = 50;
    public float enemylasercooldown;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyShootingMechanic());
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
            Instantiate(laser, transform.position, Quaternion.identity);
        }

    }

    public void TakeDamage(float damage)
    {
        health = health - 50;

        //OM health blir 0 eller mindre så ska jag dö


        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
        IEnumerator EnemyShootingMechanic() //loop for enemy shooting
        {
            while (enemylasercooldown > 0)
            {
                Instantiate(laser, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(enemylasercooldown);
            }
            yield return null;

        }
    }




