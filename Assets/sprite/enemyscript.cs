using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class enemyscript : MonoBehaviour
{
    private Vector3 moveDirection;
    private float enemy = 1.0f; // Added this line to define the 'enemy' variable
    public GameObject enemyspawner; // Reference to the spawn point

    // Start is called before the first frame update
    void Start()
    {
        //move to postion
        transform.position = new Vector3(0, -4, 0);
        moveDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0f
        ).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * enemy * Time.deltaTime);
        //move to postion
        transform.position = new Vector3(0, -4, 0);

        // Start is called before the first frame update
    }

   
}