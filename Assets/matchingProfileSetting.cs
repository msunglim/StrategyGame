using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchingProfileSetting : MonoBehaviour
{
    [SerializeField]
    private int index;

    private GameObject ult;

    // Start is called before the first frame update
    void Start()
    {
        characterSetting cs;
        if (index == 0)
        {
            int[] xlist = new int[3] { -3, -1, 1 };
            cs = GameMaster.p1c.getCharacter().GetComponent<characterSetting>();
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =
                cs.getCharacterProfile();
            transform.position = new Vector3(xlist[GameMaster.match], -1, 0);
            transform.GetChild(1).GetComponent<TMPro.TextMeshPro>().text =
                cs.getCharacterName();
            ult =
                Instantiate(cs.getUlt(),
                new Vector3(-10, 0, 2),
                Quaternion.identity);
            ult.transform.localScale =
            new Vector3(3, 3, 2);        
         
        }
        else
        {
            //set current enemy
            int enemeyIndex =
                (
                (
                System
                    .Array
                    .IndexOf(GameMaster.characterList,
                    GameMaster.p1c.getCharacter())
                ) +
                index
                ) %
                GameMaster.characterList.Length;
            cs =
                GameMaster
                    .characterList[enemeyIndex]
                    .GetComponent<characterSetting>();
         
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =
                cs.getCharacterProfile();
            transform.GetChild(1).GetComponent<TMPro.TextMeshPro>().text =
                cs.getCharacterName();
            transform
                .GetChild(0)
                .GetComponent<SpriteRenderer>()
                .transform
                .Rotate(new Vector3(0, 180, 0));
            if(GameMaster.match+1== index){
                    GameMaster.p2c.setCharacter( GameMaster.characterList[enemeyIndex]);
                    ult =
                Instantiate(cs.getUlt(),
                new Vector3(10, 0, 2),
                Quaternion.identity);
            ult.transform.localScale =
            new Vector3(3, 3, 2);   
              ult.GetComponent<SpriteRenderer>()
                .transform
                .Rotate(new Vector3(0, 180, 0));
                GameMaster.p2SkillList =  GameMaster.characterList[enemeyIndex].GetComponent<characterSetting>().getSkillList();
            }
        }

        float profileSizeWidth =
            (transform.GetChild(0).transform.localScale.x / 2.86f);
        float profileSizeHeight =
            (transform.GetChild(0).transform.localScale.y / 2.96f);
        transform.GetChild(0).transform.localScale =
            new Vector3(profileSizeWidth, profileSizeHeight, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (ult != null)
        {
            if(index == 0){
                ult.transform.position =
                Vector3
                    .MoveTowards( ult.transform.position,
                    new Vector3(-3, 0, 1),
                    Time.deltaTime * 15);
            }else{
                ult.transform.position =
                Vector3
                    .MoveTowards( ult.transform.position,
                    new Vector3(3, 0, 2),
                    Time.deltaTime * 15);
            }
            
        }
    }
}
