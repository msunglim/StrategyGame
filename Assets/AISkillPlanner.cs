using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISkillPlanner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int availableEN = GameMaster.p2EN;
        GameObject [] skillList= GameMaster.p2c.getCharacter().GetComponent<characterSetting>().getSkillList();

        GameObject [] p2skillList = new GameObject[3];
        for(int i = 0 ; i < 3; i++){
            int rnd = Random.Range(0, 10);
            while(skillList[rnd].GetComponent<skillManager>().getCost()> availableEN){
                rnd = Random.Range(0,10);
            }
            
            availableEN -=skillList[rnd].GetComponent<skillManager>().getCost();
            p2skillList[i] = skillList[rnd];
            Debug.Log("added skill " + skillList[rnd].GetComponent<skillManager>().getSkillName());

        }
        GameMaster.p2Skills = skillList;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
