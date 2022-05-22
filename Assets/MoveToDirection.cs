using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDirection : MonoBehaviour
{
    private int directionX, directionY; //vector direction

    // Start is called before the first frame update
    void Start()
    {
    }

    public void setDirection(int a, int b)
    {
        directionX = a;
        if (directionX < 0)
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
        directionY = b;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(directionX, directionY, 0) * 3 * Time.deltaTime;

    }
}
