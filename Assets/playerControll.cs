using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControll : MonoBehaviour
{
    private Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            anime.SetInteger("useSkill", 1);
        }
    }
    public void actionComplete()
    {
        anime.SetInteger("useSkill", 0);
    }
}
