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

    GameObject p1;
    GameObject p2;
    // Start is called before the first frame update
    GameObject[,] list = new GameObject[3, 4];

    private playerControll p1controll, p2controll;
    private SpriteRenderer sr1, sr2;
    private float[] x, y;
    void Start()
    {
        x = new float[] { -4.5f, -1.5f, 1.5f, 4.5f };
        y = new float[] { 0.0f, -1.3f, -2.6f };
        p1 = Instantiate(player1, new Vector3(x[0], y[1], -2), Quaternion.identity);
        p1controll = p1.GetComponent<playerControll>();
        p1controll.setXY(0, 1);
        sr1 = p1.GetComponent<SpriteRenderer>();

        p2 = Instantiate(player2, new Vector3(x[3], y[1], -2), Quaternion.identity);
        p2controll = p2.GetComponent<playerControll>();

        p2controll.setXY(3, 1);
        sr2 = p2.GetComponent<SpriteRenderer>();
        sr2.transform.Rotate(new Vector3(0, 180, 0));
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject clone = Instantiate(field, new Vector3(x[j], y[i], -1), Quaternion.identity);
                list[i, j] = clone;
            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            p1controll.useSkill1();
            Debug.Log("player 1 xy" + p1.GetComponent<playerControll>().getX() + p1.GetComponent<playerControll>().getY());
        }
        if (Input.GetKeyDown("f"))
        {
            p2controll.useSkill1();
            // p2.GetComponent<playerControll>().useSkill1();
            Debug.Log("player 2 xy" + p2.GetComponent<playerControll>().getX() + p2.GetComponent<playerControll>().getY());
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            p1controll.moveLeft();
            p1.transform.position = new Vector3(x[p1controll.getX()], y[p1controll.getY()], -2);
            // p1.GetComponent<playerControll>().setXY(p1.GetComponent<playerControll>().getX() - 1, p1.GetComponent<playerControll>().getY());

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            p1controll.moveRight();
            p1.transform.position = new Vector3(x[p1controll.getX()], y[p1controll.getY()], -2);
            // p1.GetComponent<playerControll>().setXY(p1.GetComponent<playerControll>().getX() + 1, p1.GetComponent<playerControll>().getY());
            //         x++;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            p1controll.moveUp();
            p1.transform.position = new Vector3(x[p1controll.getX()], y[p1controll.getY()], -2);
            // p1.GetComponent<playerControll>().setXY(p1.GetComponent<playerControll>().getX(), p1.GetComponent<playerControll>().getY() - 1);
            //       y--;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            p1controll.moveDown();
            p1.transform.position = new Vector3(x[p1controll.getX()], y[p1controll.getY()], -2);
            // p1.GetComponent<playerControll>().setXY(p1.GetComponent<playerControll>().getX(), p1.GetComponent<playerControll>().getY() + 1);
            //     y++;
        }


        int p1x = p1controll.getX();
        int p2x = p2controll.getX();

        
    }
}
