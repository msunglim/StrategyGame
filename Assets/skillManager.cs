using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillManager : MonoBehaviour
{
    [SerializeField]
    int[] targetArea;
    [SerializeField]
    GameObject skillEffect;


    // Start is called before the first frame update
    void Start()
    {

    }
    public int [] getTargetArea(){
        return targetArea;
    }
    public void effect(int direction, float x, float y)
    {
        GameObject effect = Instantiate(skillEffect, new Vector3(x, y, -2), Quaternion.identity);
        effect.GetComponent<MoveToDirection>().setDirection(direction * 10, 0); //10 is speed of skill
    }

}
