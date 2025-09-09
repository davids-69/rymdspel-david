using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    [Header("Player stats")]
    public float playerSpeed;
    public int playerHealth = 3;
    public List<Image> healthImage;

    [Header("Player sprites")]
    public Sprite playerIdle;
    public Sprite playerLeft;
    public Sprite playerRight;
    private SpriteRenderer spriteRenderer;

    [Header("Player Weapon Variables")]
    public GameObject laserShot;
    public Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the player's position to the X, Y, Z coordintes set within the parenthesis
        transform.position = new Vector3(0, -3.5f, 0);

        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalSpeed = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * horizontalSpeed * playerSpeed * Time.deltaTime);

        //This is a "null check". We check whether or not the variables within the IF-statement are null or not. This is a good way to avoid errors.
        if(playerIdle != null && playerLeft != null && playerRight != null)
        {
            ShipAnimation();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laserShot, transform.position + spawnPosition, Quaternion.identity);
        }

        if(playerHealth < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void takeDamage()
    {
        playerHealth--;
        UpdateHealth();
        
    }

    private void UpdateHealth()
    {
        //Here we have a so-called "for loop". It can be a bit tricky to understand the logic of how it works, so let's go through it step by step:
        //First it creates an int variable called "i" and sets it to 0. 
        //Then it checks for a condition: is "i" less than the number of items in the healthImage list? If there is no item in the healthImage list then the loop will immediately cancel.
        //It will then add 1 to "i" and execute the code below. 
        //It will then the condition. Is "i" less than healthImage.count? At this point, "i" will be 1. If there was only one item in the list then the condition would not be met, as "i" would be equal to healthImage.count. 
        for (int i = 0; i < healthImage.Count; i++)
        {
            //Here we are using the "i" variable to check whether it is less than the player's health. In this example, let's say that the player's health is set to 3.
            //So for the first loop it reads "is 0 less than 3?"
            //And for the second loop it reads "is 1 less than 3?" 
            //It will do this until it asks "is 3 less than 3?", which it is not. And once the condition is no longer true it will execute the code in the else statement.
            if (i < playerHealth)
            {
                //Here we are once again using "i" in our code. Whatever number "i" has we are using when selecting an element in the list.
                //The first element in a list is 0, the second element is 1 and the third element is 2. 
                healthImage[i].enabled = true;
            }
            else
            {
                //Here we are doing the same thing, except we are disabling rather than enabling images. 
                //Let's say the player has taken damage and their health is now 2. Then the above code will only execute when "i" is 0 or 1. 
                //When "i" reaches 2 it will enter the code below and disable healthImage[2]; that is to say the third element in the list, as lists always count from 0.
                healthImage[i].enabled = false;
            }
        }
    }

    private void ShipAnimation()
    {
        float horizontalSpeed = Input.GetAxisRaw("Horizontal");

        if(horizontalSpeed < 0)
        {
            spriteRenderer.sprite = playerLeft;
        }
        else if(horizontalSpeed > 0)
        {
            spriteRenderer.sprite = playerRight;
        }
        else
        {
            spriteRenderer.sprite = playerIdle;
        }
    }

}
