using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterSelectionButton : MonoBehaviour
{
    [SerializeField]
    private int characterIndex;

    // [SerializeField]
    // private Object destination;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =
            GameMaster
                .characterList[characterIndex]
                .GetComponent<characterSetting>()
                .getCharacterProfile();
        float profileSizeWidth =
            (transform.GetChild(0).transform.localScale.x / 2.86f);
        float profileSizeHeight =
            (transform.GetChild(0).transform.localScale.y / 2.96f);

        transform.GetChild(0).transform.localScale =
            new Vector3(profileSizeWidth, profileSizeHeight, 1);
        if (characterIndex > 1)
        {
            transform
                .GetChild(0)
                .GetComponent<SpriteRenderer>()
                .transform
                .Rotate(new Vector3(0, 180, 0));
        }
        transform.GetChild(1).GetComponent<TMPro.TextMeshPro>().text =
            GameMaster
                .characterList[characterIndex]
                .GetComponent<characterSetting>()
                .getCharacterName();
    }

   
    private void OnMouseDown()
    {
        GameMaster.p1c.setCharacter(GameMaster.characterList[characterIndex]);
        GameMaster.p1SkillList =
            GameMaster
                .characterList[characterIndex]
                .GetComponent<characterSetting>()
                .getSkillList();

        GameMaster.p1HP = 100;

        GameMaster.p1EN = 100;

        GameMaster.p2HP = 100;

        GameMaster.p2EN = 100;

        GameMaster.p1x = 1;

        GameMaster.p1y = 1;

        GameMaster.p2x = 2;

        GameMaster.p2y = 1;

        GameMaster.p1Size = 0;

        GameMaster.p2Size = 0;

        GameMaster.round = 1;

        //how many characters this player has competed with.
        GameMaster.match = 0; //start from 0 to 3

        GetComponent<switchScene>().SwitchScene();
    }
}
