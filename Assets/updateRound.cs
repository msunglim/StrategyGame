using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateRound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMPro.TextMeshPro>().text = ""+GameMaster.round;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
