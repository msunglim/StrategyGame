using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textColorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setTextAndColor(int damage, string text){
        byte red = (damage <= 0)? (byte)255:(byte)51;
        byte green = (damage <= 0)? (byte)51:(byte)255;
        byte blue = (damage <= 0)? (byte)51:(byte)255;
        GetComponent<TMPro.TextMeshPro>().color = new Color32(red, green, blue, 255);
         GetComponent<TMPro.TextMeshPro>().text = text + " \n" + damage;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
