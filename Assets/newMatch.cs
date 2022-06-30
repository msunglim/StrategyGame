using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMatch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void prepareForNewMatch()
    {
        GameMaster.p1HP = 100;

        GameMaster.p1EN = 100;

        GameMaster.p2HP = 100;

        GameMaster.p2EN = 100;

        GameMaster.p1x = 1;

        GameMaster.p1y = 1;

        GameMaster.p2x = 2;

        GameMaster.p2y = 1;

        GameMaster.round = 1;
       
   
    }
    
}
