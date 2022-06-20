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
    
    private int hp;

    private int en;
    private int def; 
    private int

            x,
            y; //x y index for fields.

    // private int direction;
    // private SpriteRenderer sr;
    // private Animator anime;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    public Sprite getCharacterProfile(){
       return character.GetComponent<characterSetting>().getCharacterProfile();
    }
    public GameObject getMinProfile()
    {
        return character.GetComponent<characterSetting>().getMinProfile();
    }
    public void setCharacter(GameObject c){
        
        character =  c;
    }
    public void setDEF(int d){
        def = d;
    }
    public int getDEF(){
        return def;
    }
    public void setHP(int newHP)
    {
        if (playerCode == 1)
        {
            GameMaster.p1HP = newHP;
        }
        else
        {
            GameMaster.p2HP = newHP;
        }
        hp = newHP;
    }

    public int getHP()
    {
        if (playerCode == 1)
        {
            return GameMaster.p1HP;
        }
        else
        {
            return GameMaster.p2HP;
        }
        // return hp;
    }

    public void setEN(int newEN)
    {
        if (playerCode == 1)
        {
            GameMaster.p1EN = newEN;
        }
        else
        {
            GameMaster.p2EN = newEN;
        }
        en = newEN;
    }

    public int getEN()
    {
        if (playerCode == 1)
        {
            return GameMaster.p1EN;
        }
        else
        {
            return GameMaster.p2EN;
        }
        // return en;
    }

    public GameObject getCharacter()
    {
        return character;
    }

    public void moveLeft()
    {
        if (x == 0) return;
        x--;
         if (playerCode == 1)
        {
             GameMaster.p1x = x;
        }
        else
        {
             GameMaster.p2x = x;
        }
    }

    public void moveRight()
    {
        if (x == 3) return;
        x++;
        if (playerCode == 1)
        {
             GameMaster.p1x = x;
        }
        else
        {
             GameMaster.p2x = x;
        }
    }

    public void moveUp()
    {
        if (y == 0) return;
        y--;
        if (playerCode == 1)
        {
             GameMaster.p1y = y;
        }
        else
        {
             GameMaster.p2y = y;
        }
    }

    public void moveDown()
    {
        if (y == 2) return;
        y++;
        if (playerCode == 1)
        {
             GameMaster.p1y = y;
        }
        else
        {
             GameMaster.p2y = y;
        }
    }

    public void setXY(int a, int b)
    {
        x = a;
        y = b;
    }

    public int getX()
    {
           if (playerCode == 1)
            {
                 return GameMaster.p1x;
            }
            else
            {
                 return GameMaster.p2x;
            }
        // return x;
    }

    public int getY()
    {
           if (playerCode == 1)
            {
                 return GameMaster.p1y;
            }
            else
            {
                 return GameMaster.p2y;
            }
        // return y;
    }
}
