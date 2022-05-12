using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDirection : MonoBehaviour
{
    private int directionX, directionY;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void setDirection(int a, int b)
    {
        directionX = a;
        directionY = b;
        Debug.Log(directionX + "set drecas," + directionY);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(directionX + "," + directionY);
        transform.position += new Vector3(directionX, directionY, 0) * 3 * Time.deltaTime;
    }
}
