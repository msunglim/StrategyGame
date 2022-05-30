using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCardManager : MonoBehaviour
{
    //min image for skill
    private SpriteRenderer spr;

    private string skillname;

    private string skillStatData;

    [SerializeField]
    private GameObject areaCell;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void setImage(int index)
    {
        spr = transform.GetChild(0).GetComponent<SpriteRenderer>();

        //generate area cells
        float[] areaX = new float[] { -0.5f, -0.3f, -0.1f };
        float[] areaY = new float[] { -0.4f, -0.6f, -0.8f };
        GameObject[] areaCellList = new GameObject[9];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                areaCellList[i*3 + j] =
                    Instantiate(areaCell,
                    new Vector3(transform.position.x + areaX[j],
                        transform.position.y + areaY[i],
                        -3),
                    Quaternion.identity);
            }
        }

        //skill number
      //  if (index < 5)
        //temporary if statement. since character doesn't have 10 skills yet,
        //if index is greater than the number of skills character currently have,
        //there will be error.
       // {
            skillManager currSkillManager =
                GameMaster
                    .p1c
                    .getCharacter()
                    .GetComponent<characterSetting>()
                    .getSkillList()[index]
                    .GetComponent<skillManager>();
            spr.sprite = currSkillManager.getSkillMinImage();

            skillname = currSkillManager.getSkillName();

            skillStatData =
                "" +
                currSkillManager.getDamage() +
                "\n" +
                currSkillManager.getCost();

            for (int t = 0; t < currSkillManager.getTargetArea().Length; t++)
            {
                areaCellList[currSkillManager.getTargetArea()[t]].GetComponent<SpriteRenderer>().color =
                    Color.red;
            }
        

        transform.GetChild(1).GetComponent<TMPro.TextMeshPro>().text =
            skillname;
        spr.transform.localScale = new Vector3(0.5f, 0.5f, 0);

        //set DM and EN stats
        transform
            .GetChild(2)
            .transform
            .GetChild(2)
            .GetComponent<TMPro.TextMeshPro>()
            .text = skillStatData;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
