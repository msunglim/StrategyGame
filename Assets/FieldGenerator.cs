using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//actually FieldManager would be more appropriate name.
public class FieldGenerator : MonoBehaviour
{
    //'field' is a cell of field
    [SerializeField]
    private GameObject field;

    [SerializeField]
    private GameObject player1;

    [SerializeField]
    private GameObject player2;

    //this is the clone of player 1 and 2 that are actually shown in the screen.
    //to control players, we need to use this objects.
    private GameObject p1;

    private GameObject p2;

    //list is consisted of 'field' which is a cell.
    private GameObject[,] list = new GameObject[3, 4];

    private float[]

            x,
            y;

    //player.GetComponent<playerControll>();
    private playerControll

            p1controll,
            p2controll;

    //true if p1 -> <- p2. false if p2 -> <-p1.
    private bool crossDirection;

    void Awake()
    {
        crossDirection = false;
        x = new float[] { -4.5f, -1.5f, 1.5f, 4.5f };
        y = new float[] { -0.4f, -1.4f, -2.4f };

        //+-0.5f is to adjust player image and field.
        GameObject player1Character =
            GameMaster.p1.GetComponent<playerControll>().getCharacter();
        p1 =
            Instantiate(player1Character,
            new Vector3(x[GameMaster.p1x] - 0.5f, y[GameMaster.p1y] + 0.8f, -1.5f),
            Quaternion.identity);

        p1controll = GameMaster.p1.GetComponent<playerControll>();
        p1controll.setXY(GameMaster.p1x, GameMaster.p1y);
        p1controll.setHP(GameMaster.p1HP);
        p1controll.setEN(GameMaster.p1EN);
        p1controll.setDEF(0);
        p1.GetComponent<characterSetting>().setDirection(1);

        GameObject player2Character =
            GameMaster.p2.GetComponent<playerControll>().getCharacter();
        p2 =
            Instantiate(player2Character,
            new Vector3(x[GameMaster.p2x] + 0.5f, y[GameMaster.p2y] + 0.8f, -1.5f),
            Quaternion.identity);
        p2controll = GameMaster.p2.GetComponent<playerControll>();
        p2controll.setXY(GameMaster.p2x, GameMaster.p2y);
        p2controll.setHP(GameMaster.p2HP);
        p2controll.setDEF(0);
        p2controll.setEN(GameMaster.p2EN);
        p2.GetComponent<characterSetting>().setDirection(-1);
        p2.transform.Rotate(new Vector3(0, 180, 0));

        //this will allow other scenes to get min profile of players.
        // GameMaster.p1c = p1controll;
        // GameMaster.p2c = p2controll;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject clone =
                    Instantiate(field,
                    new Vector3(x[j], y[i], -1),
                    Quaternion.identity);
                list[i, j] = clone;
            }
        }
    }
    public GameObject [,] getCellList(){
        return list;
    }
    //왜 p1.getcomponent가 안되냐면 p1은 clone이기때문에 등록된게없음.. player object에 등록되었기때문에 관리자는 player object임..
    public playerControll getPlayer1Controll()
    {
        return p1controll;
    }
   public playerControll getPlayer2Controll()
    {
        return p2controll;
    }

    public GameObject getPlayer1()
    {
        return p1;
    }
     public GameObject getPlayer2()
    {
        return p2;
    }


    // private void movePlayer(float endX, float endY, GameObject player)
    // {
    //     float adjustedX = (player == p1) ? endX - 0.5f : endX + 0.5f;
    //     float adjustedY = endY + 0.8f;

    //     GameObject skill =
    //         p1.GetComponent<characterSetting>().move(adjustedX, adjustedY);
    // }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown("f"))
        // {
        //     // p2.GetComponent<characterSetting>().useSkill1();
        //     GameObject skill =
        //         p2.GetComponent<characterSetting>().useSkill(p2controll, 1);
        //     if (skill != null)
        //     {
        //         int[] targetArea =
        //             skill.GetComponent<skillManager>().getTargetArea();
        //         StartCoroutine(applyAttackSkill(skill,
        //         targetArea,
        //         p2controll,
        //         p1controll));
        //         StartCoroutine(endPhase(p1.GetComponent<characterSetting>(),
        //         p2.GetComponent<characterSetting>()));
        //     }
        // }
        int p1X = p1controll.getX();
        int p1Y = p1controll.getY();
        int p2X = p2controll.getX();
        int p2Y = p2controll.getY();

     
        //Switch players' way they look if they cross each other.
        if ((crossDirection && p1X <= p2X) || (!crossDirection && p1X > p2X))
        {
            p1.GetComponent<characterSetting>().changeDirection();
            p2.GetComponent<characterSetting>().changeDirection();
            crossDirection = !crossDirection;
        }
    }

    public float[] getXList()
    {
        return x;
    }

    public float[] getYList()
    {
        return y;
    }

  
}
