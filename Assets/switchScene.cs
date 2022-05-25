using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class switchScene : MonoBehaviour
{
    [SerializeField]
    private Object destination;

    public void SwitchScene(){
        // SceneManager.UnloadScene( SceneManager.GetActiveScene());
        SceneManager.LoadScene(destination.name);
        
    }
}
