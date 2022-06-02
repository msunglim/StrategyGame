using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearCombatSkills : MonoBehaviour
{
  
    [SerializeField]
    private GameObject minmap, p1Stat, combatSchedule;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void clear(){
        
        for(int i = 0; i< GameMaster.p1Skills.Length; i++){
            GameObject currSkill = GameMaster.p1Skills[i];
            if(currSkill!=null){
                GameObject skillcardchild = combatSchedule.transform.GetChild(i).transform.GetChild(0).gameObject; 
                GameObject parent = skillcardchild.GetComponent<SkillCardManager>().getParent();
                Debug.Log("parent is nu? " + (parent==null));
                parent.GetComponent<SkillCardManager>().removeFilter();
                Destroy(skillcardchild);

                GameMaster.p1Skills[i]= null;

                
            }
        }
        //GameMaster.p1Skills = new GameObject[3]; 
        GameMaster.p1Size = 0;

        minmap.GetComponent<MinMapGenerator>().setAvailableEN(GameMaster.p1EN);
        p1Stat
                .GetComponent<statManager>()
                .updateENbar(GameMaster.p1EN);

    }
}
