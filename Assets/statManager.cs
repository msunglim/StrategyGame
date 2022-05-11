using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statManager : MonoBehaviour
{
    [SerializeField]
    private float vector; //player -1: 1, 2: 1

    private float defaultSize;
    private float startingX;

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        defaultSize = 4.5f;
        startingX = player.transform.position.x + vector*player.GetComponent<SpriteRenderer>().bounds.size.x/2 ;
        transform.position= new Vector2(startingX +vector*(defaultSize/2) , transform.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            defaultSize -= 0.5f;
            player.GetComponent<characterInfo>().setHP(player.GetComponent<characterInfo>().getHP() - 10);
            transform.localScale = new Vector2(defaultSize, transform.localScale.y);
            transform.position = new Vector2(startingX + vector*(defaultSize/2),transform.position.y); 
        
            Debug.Log("hp"+ player.GetComponent<characterInfo>().getHP());
        }
    }
}
