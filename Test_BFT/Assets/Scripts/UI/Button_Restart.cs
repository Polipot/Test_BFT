using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Restart : MonoBehaviour
{
    int idScene;
    

    public void Restart()
    {
        idScene = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(idScene);

            
    }
}
