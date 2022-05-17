using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSetting : MonoBehaviour
{
 [SerializeField]
    private RuntimeAnimatorController anime;
    [SerializeField]
    private GameObject skill1Effect;
    [SerializeField]
    private Sprite sp;
    private SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sp;
        // anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject getSkill1(){
        return skill1Effect;
    }
    public RuntimeAnimatorController getAnimator()
    {
        return anime;
    }
    public Sprite getSprite()
    {
        return sp;
    }
    public void useSkill1()
    {
        // anime.SetInteger("useSkill", 1);
    }
   
}
