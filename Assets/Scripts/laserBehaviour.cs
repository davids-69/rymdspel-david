using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBehaviour : MonoBehaviour
{
    public float laserSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);

        if (transform.position.y < -10 || transform.position.y > 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<playerScript>().takeDamage();
        }
        if(other.tag == "Enemy")
        {
            other.GetComponent<enemyBehaviour>().enemyHealth--;
        }
        Debug.Log("Hit " + other.name);
        Destroy(this.gameObject);
    }
}