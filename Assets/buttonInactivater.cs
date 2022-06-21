using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 using UnityEngine.UI;
public class buttonInactivater : MonoBehaviour
{
    [SerializeField]
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("lengt"+ GameMaster.p1Size);
        if(GameMaster.p1Size < 3){
            button.interactable = false;
        }else{
            button.interactable = true;
        }
    }
}
