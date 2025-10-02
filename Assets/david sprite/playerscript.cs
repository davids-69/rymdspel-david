using NUnit.Framework;
using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class playerscript : MonoBehaviour
{
    public float playerspeed = 11;
    public GameObject projectile;
    public int health = 100;
    public int lives = 3;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject GameOver;

    //public List<Image healht> health image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //move to postion
        transform.position = new Vector3(0, -4, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * playerspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * playerspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * playerspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * playerspeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
            //WRAPAROUND

            //Om postionen är mindre än -11
            if (transform.position.y <= -5)

        {
            //tilldela spelarens en ny postion som är X = 9.67f
            transform.position = new Vector3(transform.position.x, 4.9f, 0);
                
            }
        //Om postionen är mer än 11
        if (transform.position.x >= 11)
        {
            //tilldela spelarens en ny postion som är X = 9.67f
            transform.position = new Vector3(-10.9f, transform.position.y, 0);
        }
        if (transform.position.y >= 5)
        {
            //tilldela spelarens en ny postion som är X = 9.67f
            transform.position = new Vector3(transform.position.x, -4.9f, 0);
        }
        //Om postionen är mer än 11
        if (transform.position.x <= -11)
        {
            //tilldela spelarens en ny postion som är X = 9.67f
            transform.position = new Vector3(10.9f, transform.position.y, 0);
        }
    }
    
    public void TakeDamage ()
    {
        health = health - 100;
        if (health <= 0)
        {
            lives--;
            health = 100;
        }
        if (lives == 2)
        {
            life1.gameObject.SetActive(false);
        }
        if (lives == 1)
        {
            life2.gameObject.SetActive(false);
        }
        if (lives == 0)
        {
            life3.gameObject.SetActive(false);
            GameOver.SetActive(true);
            Destroy(gameObject);
        }
   
    }
}




