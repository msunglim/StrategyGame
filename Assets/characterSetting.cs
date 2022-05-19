using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSetting : MonoBehaviour
{
    private Animator anime;
    [SerializeField]
    private GameObject skill1Effect;
    [SerializeField]
    private Sprite sp;
    private SpriteRenderer spr;
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sp;
        anime = GetComponent<Animator>();
        
    }
    public void setDirection(int d)
    {
        direction = d;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject getSkill1()
    {
        return skill1Effect;
    }

    public Sprite getSprite()
    {
        return sp;
    }
    public void useSkill1()
    {
        anime.SetInteger("useSkill", 1);
    }
    public void effect1()
    {
        GameObject effect = Instantiate(skill1Effect, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
        effect.GetComponent<MoveToDirection>().setDirection(direction * 10, 0); //10 is speed of skill
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
