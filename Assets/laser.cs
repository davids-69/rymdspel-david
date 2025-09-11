using UnityEngine;

public class laser : MonoBehaviour
{
    public float shoot = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5.0f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * shoot * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
 
        Destroy(gameObject);
        
    }


      
}