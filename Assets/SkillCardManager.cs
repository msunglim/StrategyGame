using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCardManager : MonoBehaviour
{
    //min image for skill
    private SpriteRenderer spr;

    private GameObject skill;

    private skillManager currSkillManager;

    private string skillname;

    private string skillStatData;

    [SerializeField]
    private GameObject areaCell;

    private bool isAdded;

    // [SerializeField]
    // private GameObject combatSchedule;
    // Start is called before the first frame update
    void Start()
    {
        isAdded = false;
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
                areaCellList[i * 3 + j] =
                    Instantiate(areaCell,
                    new Vector3(transform.position.x + areaX[j],
                        transform.position.y + areaY[i],
                        -3),
                    Quaternion.identity);
                areaCellList[i * 3 + j].transform.parent =
                    gameObject.transform.GetChild(2).transform.GetChild(0);
            }
        }

        //skill number
        //  if (index < 5)
        //temporary if statement. since character doesn't have 10 skills yet,
        //if index is greater than the number of skills character currently have,
        //there will be error.
        // {
        skill =
            GameMaster
                .p1c
                .getCharacter()
                .GetComponent<characterSetting>()
                .getSkillList()[index];
        currSkillManager = skill.GetComponent<skillManager>();
        spr.sprite = currSkillManager.getSkillMinImage();

        skillname = currSkillManager.getSkillName();

        skillStatData =
            "" +
            currSkillManager.getDamage() +
            "\n" +
            currSkillManager.getCost();

        for (int t = 0; t < currSkillManager.getTargetArea().Length; t++)
        {
            areaCellList[currSkillManager.getTargetArea()[t]]
                .GetComponent<SpriteRenderer>()
                .color = Color.red;
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
    public void setIsAdd(bool tf){
        isAdded = tf;
    }
    public bool getIsAdded(){
        return isAdded;
    }

    private void OnMouseDown()
    {
        //if isAdd is false, it means, skillcard is not added to combat schedule. so by clicking it, it can be added to cs.
        //if it is true, then it can be removed by clicking out of combat schedule.
        if (!isAdded && GameMaster.p1Size < GameMaster.p1Skills.Length)
        {
            GameObject playerInfo = GameObject.Find("PlayerInfo");
            GameObject p1Stat = playerInfo.transform.GetChild(0).gameObject;

            p1Stat
                .GetComponent<statManager>()
                .updateENbar(GameMaster.p1EN - currSkillManager.getCost());

          
                GameObject combatSchedule = GameObject.Find("CombatSchedule");
                combatSchedule.GetComponent<CombatScheduler>().add(Instantiate(gameObject,
                new Vector3(combatSchedule
                        .transform
                        .GetChild(GameMaster.p1Size)
                        .transform
                        .position
                        .x,
                    combatSchedule
                        .transform
                        .GetChild(GameMaster.p1Size)
                        .transform
                        .position
                        .y,
                    -2),
                Quaternion.identity));
               
          
            GameMaster.addToP1Skills (skill);
            SpriteRenderer[] allspr = GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < allspr.Length; i++)
            {
                allspr[i].color = Color.grey;
            }
            isAdded = true;
        }else{
            
        }
        
    }
}
