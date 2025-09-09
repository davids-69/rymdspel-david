using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float enemySpeed;
    public int enemyHealth;

    [Header("Enemy Weapon Variables")]
    public bool canFire = true;
    public GameObject enemyLaser;
    public float laserCooldown;
    public Vector3 spawnPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        //This single line dictates the enemy's movement. It can currently only go downwards at a speed that's decided by the enemySpeed variable.
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);

        //Here we call a method called VerticalWrap. You can identify methods and functions by the parenthesis. You will find the method below.
        VerticalWrap();

        //This line of code checks whether there enemyLaser variable is empty or not and whether the laser has a cooldown and whether it can fire. All of these conditions must be met in order for the code within the {} brackets to execute.
        if (enemyLaser != null && laserCooldown > 0 && canFire == true)
        {
            StartCoroutine(WeaponFire());
            canFire = false;
        }

        if(enemyHealth < 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    //This is the code that controls when the enemy should wrap back up on to the top of the screen.
    private void VerticalWrap()
    {
        if(transform.position.y < -6)
        {
            transform.position = new Vector2(transform.position.x, 7);
        }
    }

    //This is an IEnumerator is a so called "coroutine". Coroutines allow us to break up bigger tasks into smaller, more manageable ones.
    //In this case, the coroutine will spawn a laser and then wait until it progresses to the next line of code. If you look back at row 35
    //you can see that the variable canFire has been set to false. This means that the update function won't execute yet another WeaponFire()
    //until the coroutine has finished. It's a relatively simple way of making a cooldown.
    private IEnumerator WeaponFire()
    {
        //The below code will instantiate the object that exists within the "enemyLaser" variable.
        //It will spawn at the current game object's position + whatever values you've assigned to the spawnPosition variable.
        //And the spawned object's rotation will be set to 0 on the X-axis and the Y-axis, and 180f on the Z-axis.
        Instantiate(enemyLaser, transform.position + spawnPosition, Quaternion.Euler(0f, 0f, 180f));
        yield return new WaitForSeconds(laserCooldown);
        canFire = true;
    }
}
