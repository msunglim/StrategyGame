using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject cell;

    //list is consisted of 'field' which is a cell.
    private GameObject[,] list = new GameObject[3, 4];

    private float[]

            x,
            y;

    // Start is called before the first frame update
    void Start()
    {
        x = new float[] { 2.3f, 3.8f, 5.3f, 6.8f };
        y = new float[] { -2.9f, -3.6f, -4.3f };

        GameObject p1MinProfile = GameMaster.p1c.getMinProfile();
        GameObject p1min = Instantiate(p1MinProfile,
            new Vector3(x[GameMaster.p1x] - 0.5f, y[GameMaster.p1y], -2),
            Quaternion.identity);


        GameObject p2MinProfile = GameMaster.p2c.getMinProfile();
        GameObject p2min = Instantiate(p2MinProfile,
            new Vector3(x[GameMaster.p2x] + 0.5f, y[GameMaster.p2y], -2),
            Quaternion.identity);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject clone =
                    Instantiate(cell,
                    new Vector3(x[j], y[i], -1),
                    Quaternion.identity);
                list[i, j] = clone;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
