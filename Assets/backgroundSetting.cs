using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundSetting : MonoBehaviour
{
    [SerializeField]
    private Sprite [] fieldList, backgroundList;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = fieldList[GameMaster.match];
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = backgroundList[GameMaster.match];
        
        AudioMaster.playBattleFieldAudio(2 + GameMaster.match);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
