using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm = null;

    // [SerializeField]
    // public static GameObject pi;
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
    
    
    void Awake()
    {
        if (gm != null)
        {
            Destroy (gameObject);
            return;
        }
        gm = this;
        DontDestroyOnLoad (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
