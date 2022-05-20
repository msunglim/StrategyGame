using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSetting : MonoBehaviour
{

    [SerializeField]
    private Sprite sp;
    private SpriteRenderer spr;
    private int direction;
    [SerializeField]
    private GameObject[] skillList;
    //private GameObject skill1Effect;
    private Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sp;
    }
    public void setDirection(int d)
    {
        direction = d;
    }
    public GameObject useSkill1()
    {
        anime.SetInteger("useSkill", 1);
        return skillList[0];
    }
    public void effect1()
    {
        skillList[0].GetComponent<skillManager>().effect(direction, transform.position.x, transform.position.y);
    }
    public Sprite getSprite()
    {
        return sp;
    }
    public void actionComplete()
    {
        anime.SetInteger("useSkill", 0);
    }
    public void changeDirection()
    {
        direction = -direction;
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
