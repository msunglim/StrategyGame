using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class additionalSkillManager : MonoBehaviour
{
    [SerializeField]
    private GameObject [] additionalSkills;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject [] getAdditionalSkills(){
        return additionalSkills;
    }
}
