using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addtionalCardListManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
      [SerializeField]

    private GameObject skillCard;
    // Start is called before the first frame update
    void Start()
    {
        if(GameMaster.match == 0 && GameMaster.round == 1){
            GameObject p = Instantiate(panel, new Vector3(0,1,-4),
                    Quaternion.identity);
            p.transform.parent = gameObject.transform;
            float [] xList = new float[] { -3.6f, -1.8f, 0.0f, 1.8f, 3.6f };
            float y = 0.0f;
            for(int i = 0; i < 5; i++){
                GameObject card =  Instantiate(skillCard, new Vector3(xList[i],y,-4.5f),
                    Quaternion.identity);
                    card.GetComponent<SkillCardManager>().setIsUsedInCombatPanel(false);
                card.GetComponent<SkillCardManager>().tailOfCard();
                card.transform.parent = gameObject.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
