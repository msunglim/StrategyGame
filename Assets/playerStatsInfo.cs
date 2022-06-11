using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatsInfo : MonoBehaviour
{
    [SerializeField]
    private int HPorEN; //0: HP , 1: EN
     [SerializeField]
    private int playerCode; //0: player 1 , 1:player 2
    // Start is called before the first frame update
    void Start()
    {
        string type = (HPorEN ==0 ) ? "HP" : "EN";
        string data = ""; 
        if(HPorEN == 0){
            if(playerCode ==0){
                data += GameMaster.p1HP;
            }else{
                data += GameMaster.p2HP;
            }
        }else{
            if(playerCode ==0){
                data += GameMaster.p1EN;
            }else{
                data += GameMaster.p2EN;
            }
        }
         
        GetComponent<TMPro.TextMeshPro>().text =  type + data;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
