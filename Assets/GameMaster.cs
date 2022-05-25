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

    void Awake()
    {
        if (gm != null)
        {
            Destroy (gameObject);
            return;
        }
        Debug.Log("ㅋㅋㅋㅋ");
        gm = this;
        DontDestroyOnLoad (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
