using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//useless script.
public class characterInfo : MonoBehaviour
{
  
    private int HP, EN;
    void Awake()
    {
        HP = 100;
        EN = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void setHP(int h){
        HP = h;
    }
    public void setEN(int e){
        EN = e;
    }
    public int getHP(){
        return HP;
    }
    public int getEN(){
        return EN;
    }
}
