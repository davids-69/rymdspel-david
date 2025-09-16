using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class enemyscript : MonoBehaviour
{
    private Vector3 moveDirection;
    private float enemy = 1.0f; // Added this line to define the 'enemy' variable
    public GameObject enemyspawner; // Reference to the spawn point
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        //move to postion
        transform.position = new Vector3(0, -4, 0);
        /*moveDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0f
        ).normalized;*/
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
        }

    }
    private void OnTriggerEnter2D(Collider2D player) 
    { 
    
    
    }
}




