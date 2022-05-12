using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControll : MonoBehaviour
{
    [SerializeField]
    private int playerCode; // player 1 : 1 , player 2= -1 . this also means which direction a player looks at.
    private Animator anime;
    [SerializeField]
    private GameObject skill1Effect;
    private int x, y;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
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
    public void useSkill1()
    {
        anime.SetInteger("useSkill", 1);
    }
    public void effect1()
    {
        GameObject effect = Instantiate(skill1Effect, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
        effect.GetComponent<MoveToDirection>().setDirection(2, 0);

    }
    public void actionComplete()
    {
        anime.SetInteger("useSkill", 0);

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
}
