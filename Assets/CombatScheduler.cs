using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScheduler : MonoBehaviour
{
 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void add(GameObject newCard){
        newCard.GetComponent<SkillCardManager>().setIsAdd(true);
        transform.GetChild(0).GetComponent<ScheduledSkillManager>().setSkillCard(newCard);
    }
    

}
