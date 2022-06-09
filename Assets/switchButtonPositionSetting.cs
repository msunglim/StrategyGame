using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchButtonPositionSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RectTransform>().localPosition = new Vector3 (0, -150, -2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
