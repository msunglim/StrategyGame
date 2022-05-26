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
    [SerializeField]
    private GameObject minProfile;
    //private GameObject skill1Effect;
    private Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sp;

    }
    public GameObject getMinProfile(){
        return minProfile;
    }
    public void setDirection(int d)
    {
        direction = d;
    }
    public GameObject useSkill1(playerControll pc)
    {
        
        //use skill if it has enough energy to cast.
        if (pc.getEN() >= skillList[0].GetComponent<skillManager>().getCost())
        {
            anime.SetInteger("useSkill", 1);
            pc.setEN(pc.getEN() - skillList[0].GetComponent<skillManager>().getCost());
            return skillList[0];
        }
        else
        {
            return null;
        }
        // anime.SetInteger("useSkill", 1);

    }
    public void effect1()
    {
        skillList[0].GetComponent<skillManager>().effect(direction, transform.position.x, transform.position.y);
    }

    public void getHit(){
        anime.SetBool("isHit", true);
    }
    public void standBack(){
         anime.SetBool("isHit", false);
    }
    public void die(){
        
        anime.SetBool("isDead", true);
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
