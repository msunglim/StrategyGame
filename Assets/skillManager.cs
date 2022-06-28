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
    private int

            damage,
            cost;

    [SerializeField]
    private Sprite skillMinImage;

    [SerializeField]
    private string skillName;

    [SerializeField]
    private int skillPriority;

    private bool isUsed;

    private GameObject currEffect;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void setIsUsed(bool tf)
    {
        isUsed = tf;
    }

    public bool getIsUsed()
    {
        return isUsed;
    }

    public int getSkillPriority()
    {
        return skillPriority;
    }

    public string getSkillName()
    {
        return skillName;
    }

    public Sprite getSkillMinImage()
    {
        return skillMinImage;
    }

    public int[] getTargetArea()
    {
        return targetArea;
    }

    //direction : where the player is currently headed
    //x, y: location of player
    //dx,dy: where the effect will be headed
    public void effect(int direction, float x, float y, int dx, int dy, int rotate)
    {
        GameObject effect =
            Instantiate(skillEffect,
            new Vector3(x, y, -1.55f),
            Quaternion.identity);
        effect.GetComponent<MoveToDirection>().setDirection(direction * dx, dy); //10 is speed of skill
        if(rotate != 0){
            effect.transform.Rotate(0, 0, rotate);
        }
    }

    //animation과 병행하면좋음
    public void create(float x, float y)
    {
        currEffect =
            Instantiate(skillEffect,
            new Vector3(x, y, -1.55f),
            Quaternion.identity);
        Destroy(currEffect, 2.0f);
    }

    public void moveToward(int x, int y, int direction, int rotate)
    {
        GameObject field = GameObject.Find("Battlefield");
        if (y < 10) //if enemy is in range
        {
            currEffect
                .GetComponent<MoveToDestination>()
                .setDestinationWithRotation(field
                    .GetComponent<FieldGenerator>()
                    .getXList()[x],
                field.GetComponent<FieldGenerator>().getYList()[y],
                direction,
                true,
                rotate);
        }
        else
        {
            currEffect
                .GetComponent<MoveToDestination>()
                .setDestinationWithRotation(field
                    .GetComponent<FieldGenerator>()
                    .getXList()[x],
                y,
                direction,
                true,
                90);
            
        }
    }

    public int getDamage()
    {
        return damage;
    }

    public int getCost()
    {
        return cost;
    }
}
