using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//actually FieldManager would be more appropriate name.
public class FieldGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject field;

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;

    //this is the clone of player 1 and 2 that are actually shown in the screen.
    GameObject p1;
    GameObject p2;
    // Start is called before the first frame update
    GameObject[,] list = new GameObject[3, 4];

    private playerControll p1controll, p2controll;
    private float[] x, y;
    //true if p1 -> <- p2. false if p2 -> <-p1.
    private bool crossDirection;
    void Start()
    {
        crossDirection = false;
        x = new float[] { -4.5f, -1.5f, 1.5f, 4.5f };
        y = new float[] { 0.0f, -1.3f, -2.6f };
        //+-0.5f is adjusting.
        GameObject player1Character = player1.GetComponent<playerControll>().getCharacter();
        Debug.Log(player1Character);
        p1 = Instantiate(player1Character, new Vector3(x[0] - 0.5f, y[1] + 0.8f, -2), Quaternion.identity);
        p1controll = p1.GetComponent<playerControll>();
        p1controll.setXY(0, 1);

        // p2 = Instantiate(player2, new Vector3(x[2] + 0.5f, y[1] + 0.8f, -2), Quaternion.identity);
        // p2controll = p2.GetComponent<playerControll>();
        // p2controll.setXY(2, 1);
        //180도 돌리는건 유지해야해!!!
        // sr2.transform.Rotate(new Vector3(0, 180, 0));
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject clone = Instantiate(field, new Vector3(x[j], y[i], -1), Quaternion.identity);
                list[i, j] = clone;
            }

        }


    }
    private void movePlayer(float inputX, float inputY, GameObject player)
    {
        float adjustedX = (player == p1) ? inputX - 0.5f : inputX + 0.5f;
        float adjustedY = inputY +0.8f;
        player.transform.position = new Vector3(adjustedX, adjustedY, -2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            p1controll.useSkill1();
        }
        // if (Input.GetKeyDown("f"))
        // {
        //     p2controll.useSkill1();
        // }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            p1controll.moveLeft();
            movePlayer(x[p1controll.getX()], y[p1controll.getY()], p1);
            // p1.transform.position = new Vector3(x[p1controll.getX()], y[p1controll.getY()], -2);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            p1controll.moveRight();
            movePlayer(x[p1controll.getX()], y[p1controll.getY()], p1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            p1controll.moveUp();
            movePlayer(x[p1controll.getX()], y[p1controll.getY()], p1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            p1controll.moveDown();
            movePlayer(x[p1controll.getX()], y[p1controll.getY()], p1);
        }


        int p1x = p1controll.getX();
        // int p2x = p2controll.getX();
        // if (crossDirection && p1x <= p2x)
        // {
        //     p1controll.changeDirection();
        //     p2controll.changeDirection();
        //     crossDirection = !crossDirection;
        // }
        // else if (!crossDirection && p1x > p2x)
        // {
        //     p1controll.changeDirection();
        //     p2controll.changeDirection();
        //     crossDirection = !crossDirection;
        // }

    }
}
