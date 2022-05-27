using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCardManager : MonoBehaviour
{
    private static SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void setImage(int index)
    {
        spr = transform.GetChild(0).GetComponent<SpriteRenderer>();

        spr.transform.localScale = new Vector3(0.5f, 0.5f, -2);
        if (index == 0)
        {
            spr.sprite =
                GameMaster
                    .p1c
                    .getCharacter()
                    .GetComponent<characterSetting>()
                    .getSkillCardImageList()[0];
        }
        else
        {
            spr.sprite =
                GameMaster
                    .p1c
                    .getCharacter()
                    .GetComponent<characterSetting>()
                    .getSkillCardImageList()[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
