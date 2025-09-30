using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    private Vector3 moveDirection;
    public GameObject Laser; // Reference to the spawn point
    public float Speed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if (transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.GetComponent<playerscript>().TakeDamage();
            Destroy(gameObject);
        }

        
    }

}
