using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControll : MonoBehaviour
{
    [SerializeField]
    private int playerCode; // player 1 : 1 , player 2= -1 . this also means which direction a player looks at.
    [SerializeField]
    GameObject character;

    private int x, y; //x y index for fields.
    private int direction;
    private SpriteRenderer sr;
    private Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        direction = playerCode;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = character.GetComponent<characterSetting>().getSprite();
        anime = GetComponent<Animator>();
        anime.runtimeAnimatorController = character.GetComponent<characterSetting>().getAnimator();
    }
 
    public void useSkill1()
    {
        // character.GetComponent<characterSetting>().useSkill1();
        anime.SetInteger("useSkill", 1);
    }
    public void effect1()
    {
        // int direction = GetComponent<playerControll>().getDirection();
        GameObject skill1 = character.GetComponent<characterSetting>().getSkill1();
        GameObject effect = Instantiate(skill1, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
        effect.GetComponent<MoveToDirection>().setDirection(direction * 10, 0); //10 is speed of skill
    }
    public void actionComplete()
    {
        anime.SetInteger("useSkill", 0);

    }
    public void moveLeft()
    {
        if (x == 0) return;
        x--;
    }
    public void moveRight()
    {
        if (x == 3) return;
        x++;
    }
    public void moveUp()
    {
        if (y == 0) return;
        y--;
    }
    public void moveDown()
    {
        if (y == 2) return;
        y++;
    }

    public void setXY(int a, int b)
    {
        x = a;
        y = b;
    }
    public int getX()
    {
        return x;
    }
    public int getY()
    {
        return y;
    }
    public void changeDirection()
    {
        direction = -direction;
        transform.Rotate(new Vector3(0, 180, 0));
        Debug.Log("dirction" + direction);

    }


}
