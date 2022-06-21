using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDestination : MonoBehaviour
{
    private float x, y;
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
                    new Vector3(x, y , transform.position.z),
                    Time.deltaTime * 15);
    }
    public void setDestination(float a, float b){
        x= a;
        y = b;
    }
    
}
