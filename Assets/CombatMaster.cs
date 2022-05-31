using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMaster : MonoBehaviour
{
    GameObject [] p1Skills, p2Skills;
    [SerializeField]
    GameObject combatSchedule;
    public static CombatMaster cm = null;
    // Start is called before the first frame update
    void Start()
    {
        
        if (cm != null)
        {
            Destroy (gameObject);
            return;
        }
        cm = this;
        DontDestroyOnLoad (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getCombatSchedule(){
        return combatSchedule;
    }
}
