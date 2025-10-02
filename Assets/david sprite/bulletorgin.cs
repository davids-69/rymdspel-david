using UnityEngine;

public class bulletorgin : MonoBehaviour

{
    private Vector3 moveDirection;
    public GameObject bullet; // Reference to the spawn point
    public float Speed = 2f; 
    public float bulletdamage = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        if (transform.position.y <= -5.5f)
        {
            transform.position = new Vector3(Random.Range(-7, 7), 5.5f, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyscript Enemy = collision.gameObject.GetComponent<enemyscript>();    

            if (Enemy != null)
            {
                Enemy.TakeDamage(bulletdamage);
            }
            Destroy(gameObject);
        }
    }
}
