using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterInfo : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField] private Sprite sp;

    // Start is called before the first frame update
    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = sp;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
