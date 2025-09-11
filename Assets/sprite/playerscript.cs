using UnityEditor.SearchService;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    public float playerspeed = 11;
    public GameObject projectile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //move to postion
        transform.position = new Vector3(0, -4, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * playerspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * playerspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * playerspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
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

}




