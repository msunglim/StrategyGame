using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillManager : MonoBehaviour
{
    [SerializeField]
    private int[] targetArea;
    [SerializeField]
    private GameObject skillEffect;
    [SerializeField]
    private int damage, cost;
        [SerializeField]
    private Sprite skillMinImage;
    [SerializeField]
    private string skillName;

    // Start is called before the first frame update
    void Start()
    {

    }
    public string getSkillName(){
        return skillName;
    }
    public Sprite getSkillMinImage(){
        return skillMinImage;
    }
    public int [] getTargetArea(){
        return targetArea;
    }
    public void effect(int direction, float x, float y)
    {
        GameObject effect = Instantiate(skillEffect, new Vector3(x, y, -2), Quaternion.identity);
        effect.GetComponent<MoveToDirection>().setDirection(direction * 10, 0); //10 is speed of skill
    }
    public int getDamage(){
        return damage;
    }
    public int getCost(){
        return cost;
    }
}
