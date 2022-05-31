using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm = null;

    public static int p1HP = 100;

    public static int p1EN = 100;

    public static int p2HP = 100;

    public static int p2EN = 100;

    public static int p1x = 0;

    public static int p1y = 1;

    public static int p2x = 1;

    public static int p2y = 1;

    public static playerControll p1c;

    public static playerControll p2c;

    public static GameObject p1;

    public static GameObject p2;

    [SerializeField]
    public GameObject

            p1Serialize,
            p2Serialize;

    void Awake()
    {
        if (gm != null)
        {
            Destroy (gameObject);
            return;
        }
        gm = this;

        p1 = p1Serialize;
        p2 = p2Serialize;
        p1c = p1Serialize.GetComponent<playerControll>();
        p2c = p2Serialize.GetComponent<playerControll>();
        DontDestroyOnLoad (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
