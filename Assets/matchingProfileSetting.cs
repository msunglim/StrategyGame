using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchingProfileSetting : MonoBehaviour
{
    [SerializeField]
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        if(index == 0){
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = GameMaster.p1c.getCharacter().GetComponent<characterSetting>().getCharacterProfile();
        }else{
            int enemeyIndex = ((System.Array.IndexOf(GameMaster.characterList, GameMaster.p1c.getCharacter())) + index )% GameMaster.characterList.Length;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = GameMaster.characterList[enemeyIndex].GetComponent<characterSetting>().getCharacterProfile();
        }
        
        float profileSizeWidth = (transform.GetChild(0).transform.localScale.x/2.86f);
        float profileSizeHeight = (transform.GetChild(0).transform.localScale.y/2.96f);
          transform.GetChild(0).transform.localScale = new Vector3( profileSizeWidth,profileSizeHeight ,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
