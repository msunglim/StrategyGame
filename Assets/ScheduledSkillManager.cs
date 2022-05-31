using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduledSkillManager : MonoBehaviour
{
    private GameObject skillcard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setSkillCard(GameObject s){
        skillcard = s;
    }
    public void OnMouseDown(){
        Debug.Log("hi");
        //쓸모없는거같기도..
    }

}
