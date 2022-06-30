using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextRoundSetting : MonoBehaviour
{
    // [SerializeField]
    // private int position;
    // Start is called before the first frame update
    void Start()
    {
        // GetComponent<RectTransform>().localPosition = new Vector3(0, position, -2);
     

        // roundDisplay.GetComponent<TMPro.TextMeshPro>().text =  ""+ GameMaster.round;
        //     Debug.Log("round "+ GameMaster.round);
    }

    public void restoreEN()
    {
           GameMaster.round++;
        for(int i = 0; i< 3 ; i++){
            if(GameMaster.p1EN <100){
                 GameMaster.p1EN += 5;
            }
            if(GameMaster.p2EN < 100){
                  GameMaster.p2EN += 5;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
