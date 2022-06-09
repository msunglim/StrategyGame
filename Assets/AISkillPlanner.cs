using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISkillPlanner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int availableEN = GameMaster.p2EN;
        GameObject[] skillList =
            GameMaster
                .p2c
                .getCharacter()
                .GetComponent<characterSetting>()
                .getSkillList();

        GameObject[] p2skillList = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            if (availableEN <= 20 &&  !skillList[9].GetComponent<skillManager>().getIsUsed())
            {
                availableEN -=
                    skillList[9].GetComponent<skillManager>().getCost();
                skillList[9].GetComponent<skillManager>().setIsUsed(true);
                p2skillList[i] = skillList[9];
            }
            else
            {
                int rnd = Random.Range(0, 10);
                while (skillList[rnd].GetComponent<skillManager>().getCost() >
                    availableEN ||
                    skillList[rnd].GetComponent<skillManager>().getIsUsed() ||
                    (
                    availableEN == 100 &&
                    skillList[rnd] ==
                    GameMaster
                        .p2c
                        .getCharacter()
                        .GetComponent<characterSetting>()
                        .getSkillList()[9]
                    ) ||
                    (
                    GameMaster.p2y == 0 &&
                    skillList[rnd] ==
                    GameMaster
                        .p2c
                        .getCharacter()
                        .GetComponent<characterSetting>()
                        .getSkillList()[0]
                    ) ||
                    (
                    GameMaster.p2y == 2 &&
                    skillList[rnd] ==
                    GameMaster
                        .p2c
                        .getCharacter()
                        .GetComponent<characterSetting>()
                        .getSkillList()[1]
                    ) ||
                    (
                    GameMaster.p2x == 0 &&
                    skillList[rnd] ==
                    GameMaster
                        .p2c
                        .getCharacter()
                        .GetComponent<characterSetting>()
                        .getSkillList()[2]
                    ) ||
                    (
                    GameMaster.p2x == 3 &&
                    skillList[rnd] ==
                    GameMaster
                        .p2c
                        .getCharacter()
                        .GetComponent<characterSetting>()
                        .getSkillList()[3]
                    )
                )
                {
                    rnd = Random.Range(0, 10);
                }

                availableEN -=
                    skillList[rnd].GetComponent<skillManager>().getCost();
                skillList[rnd].GetComponent<skillManager>().setIsUsed(true);
                p2skillList[i] = skillList[rnd];
            }
        }
        GameMaster.p2Skills = p2skillList;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
