using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDestination : MonoBehaviour
{
    private float

            x,
            y;
    private bool destroyWhenReach;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            Vector3
                .MoveTowards(transform.position,
                new Vector3(x, y, transform.position.z),
                Time.deltaTime * 15);
        if ( destroyWhenReach && transform.position.x == x && transform.position.y == y)
        {
            Destroy (gameObject);
        }
    }

    public void setDestination(float a, float b, int directionX, bool tf)
    {   destroyWhenReach = tf; 
        x = a;
        y = b;
        if (directionX < 0)
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
      public void setDestinationWithRotation(float a, float b, int directionX, bool tf, int rotate)
    {   destroyWhenReach = tf; 
        x = a;
        y = b;
        if (directionX < 0)
        {
            transform.Rotate(new Vector3(0, 180, rotate));
        }else{
            transform.Rotate(new Vector3(0, 0, rotate));
        }
    }
}
