using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victorySceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject characterPose; 
    // Start is called before the first frame update
    void Start()
    {
        characterPose.GetComponent<SpriteRenderer>().sprite =
            GameMaster
                .p1.GetComponent<playerControll>().getCharacter()
                .GetComponent<characterSetting>()
                .getVictoryPose();
     
        float profileSizeWidth =
            (characterPose.transform.localScale.x );
        float profileSizeHeight =
            (characterPose.transform.localScale.y );

        characterPose.transform.localScale =
            new Vector3(profileSizeWidth, profileSizeHeight, 1);

        characterPose.GetComponent<MoveToDestination>().setDestination(0, 0, 1, false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
