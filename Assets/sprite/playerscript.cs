using UnityEditor.SearchService;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    public float playerspeed = 11;

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

        //WRAPAROUND

        //Om postionen �r mindre �n -11
        if (transform.position.y <= -11)

        {
            //tilldela spelarens en ny postion som �r X = 9.67f
            transform.position = new Vector3(9.67f, transform.position.y, 0);
                
            }
        //Om postionen �r mer �n 11
        if (transform.position.x >= 11)
        {
            //tilldela spelarens en ny postion som �r X = 9.67f
            transform.position = new Vector3(-9.67f, transform.position.x, 0);
        }
        if (transform.position.y <= -4.53)

        {
            //tilldela spelarens en ny postion som �r X = 9.67f
            transform.position = new Vector3(transform.position.y, 4.53f, 0);

        }
        //Om postionen �r mer �n 11
        if (transform.position.x >= 4.53)
        {
            //tilldela spelarens en ny postion som �r X = 9.67f
            transform.position = new Vector3(transform.position.x, -4.53f, 0);
        }
    }

}




