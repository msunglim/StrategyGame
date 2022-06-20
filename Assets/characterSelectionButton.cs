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
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = GameMaster.characterList[characterIndex].GetComponent<characterSetting>().getCharacterProfile();
        float profileSizeWidth = (transform.GetChild(0).transform.localScale.x/2.86f);
        float profileSizeHeight = (transform.GetChild(0).transform.localScale.y/2.96f);

        transform.GetChild(0).transform.localScale = new Vector3( profileSizeWidth,profileSizeHeight ,1);
        if(characterIndex > 1){
             transform.GetChild(0).GetComponent<SpriteRenderer>()
                .transform
                .Rotate(new Vector3(0, 180, 0));
        }
        transform.GetChild(1).GetComponent<TMPro.TextMeshPro>().text =  GameMaster.characterList[characterIndex].GetComponent<characterSetting>().getCharacterName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown(){
        GameMaster.p1c.setCharacter(GameMaster.characterList[characterIndex]);
        GameMaster.p1SkillList = GameMaster.characterList[characterIndex].GetComponent<characterSetting>().getSkillList();
        GetComponent<switchScene>().SwitchScene();

    }
}
