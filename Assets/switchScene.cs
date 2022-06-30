using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 using System; 
public class switchScene : MonoBehaviour
{
    [SerializeField]
    private string destination;
    // private UnityEngine.Object destination;

    public void SwitchScene(){
        try{
            //  SceneManager.LoadScene(destination.name);
             SceneManager.LoadScene(destination);
        }
        catch(NullReferenceException ex){

            Debug.Log("Error Error!" + ex);
        }
        
    }
}
