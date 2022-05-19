using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this Gameobject controls player's location and contains character info.
public class playerControll : MonoBehaviour
{
    [SerializeField]
    private int playerCode; // player 1 : 1 , player 2= -1 . this also means which direction a player looks at.
    [SerializeField]
    private GameObject character;

    private int x, y; //x y index for fields.
    // private int direction;
    // private SpriteRenderer sr;
    // private Animator anime;
    // Start is called before the first frame update


    void Start()
    {
    }
    public GameObject getCharacter()
    {
        return character;
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

}
