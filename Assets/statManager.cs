using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statManager : MonoBehaviour
{
    [SerializeField]
    private int vector;
    [SerializeField]
    private float defaultX;
    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("player"+ player.transform.position.x + " scale "+player.transform.localScale .x);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = transform.position + new Vector3(vector, 0, 0) * 1;
        }
    }
}
