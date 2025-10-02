using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void loadgame()
    {
        //load game
        SceneManager.LoadScene(1); //game scene
    }
}