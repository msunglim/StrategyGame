using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm = null;

    public static int p1HP = 100;

    public static int p1EN = 100;

    public static int p2HP = 100;

    public static int p2EN = 100;

    public static int p1x = 1;

    public static int p1y = 1;

    public static int p2x = 2;

    public static int p2y = 1;

    public static playerControll p1c;

    public static playerControll p2c;

    public static GameObject p1;

    public static GameObject p2;

    public static GameObject[] p1SkillList;
    public static GameObject[] p2SkillList;
    public static GameObject[] p1Skills = new GameObject[3];

    public static int p1Size = 0;

    public static GameObject[] p2Skills = new GameObject[3];

    public static int p2Size = 0;
    
    public static int round = 1;

    //how many characters this player has competed with. 
    public static int match = 0; //start from 0 to 3

    
    [SerializeField]
    public GameObject

            p1Serialize,
            p2Serialize;

    //[SerializeField]
    public static GameObject [] characterList;
    /*
    0: restore
    1: defense
    2: missle
    3: smash

    */ 
    public static GameObject [] additionalSkillList;
    
    void Awake()
    {
        if (gm != null)
        {
            Destroy (gameObject);
            return;
        }
        gm = this;

        //below codes will be removed.
        p1 = p1Serialize;
        p2 = p2Serialize;
        p1c = p1Serialize.GetComponent<playerControll>();
        p2c = p2Serialize.GetComponent<playerControll>();

        characterList = GetComponent<characterManager>().getCharacterList();    
        additionalSkillList = GetComponent<additionalSkillManager>().getAdditionalSkills();

  
        DontDestroyOnLoad (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public static void addToP1SkillList(GameObject s){
            GameObject [] newCharacterSkillList = new GameObject[ p1SkillList.Length + 1];
            for(int i = 0; i < p1SkillList.Length ; i++){
                newCharacterSkillList[i] = p1SkillList[i];
            }
            newCharacterSkillList[p1SkillList.Length] = s;
            p1SkillList = newCharacterSkillList;
    }
    
    //????????? ????????? ?????????????????? ?????? ???????????? ?????????????????????. ??????????????? ???????????????????????? ?????????.
    public static void addToP1Skills(GameObject skill, GameObject skillCard)
    {
        if (p1Size == p1Skills.Length) return;
        GameObject combatSchedule = GameObject.Find("CombatSchedule");
        GameObject added = Instantiate(skillCard);
       
        for (int i = 0; i < p1Skills.Length; i++)
        {
            if (p1Skills[i] == null)
            {

                added.transform.position =
                    new Vector3(combatSchedule
                            .transform
                            .GetChild(i)
                            .transform
                            .position
                            .x,
                        combatSchedule
                            .transform
                            .GetChild(i)
                            .transform
                            .position
                            .y,
                        combatSchedule
                            .transform
                            .GetChild(i)
                            .transform
                            .position
                            .z -1);
                added.transform.parent = combatSchedule.transform.GetChild(i).transform;
                p1Skills[i] = skill;

                p1Size++;
                break;
            }
        }

        // combatSchedule.GetComponent<CombatScheduler>().add(added, gameObject);
        added.GetComponent<SkillCardManager>().setIsAdd(true);
        added.GetComponent<SkillCardManager>().setParent(skillCard);

        // return added;
    }

    public static void removeToP1Skills(GameObject skill, GameObject skillCard)
    {
        for (int i = 0; i < p1Skills.Length; i++)
        {
            if (p1Skills[i] == skill)
            {
                p1Skills[i] = null;

                break;
            }
        }
        Destroy (skillCard);
        p1Size--;
    }
}
