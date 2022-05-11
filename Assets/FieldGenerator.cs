using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject field;
    // Start is called before the first frame update
    GameObject [,] list = new GameObject[3,4];
    void Start()
    {
        float[] x = new float[] { -4.5f, -1.5f, 1.5f, 4.5f };
        float[] y = new float[] { 0.0f, -1.3f, -2.6f };

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject clone = Instantiate(field, new Vector3( x[j],y[i], -1), Quaternion.identity);
                list[i,j] = clone;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
