using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textGenerator : MonoBehaviour
{
    private string msg;

    // Start is called before the first frame update
    void Start()
    {
        msg = GetComponent<TMPro.TextMeshPro>().text;
        GetComponent<TMPro.TextMeshPro>().text = "";

        StartCoroutine(generate());
    }

    private IEnumerator generate()
    {
        for (int i = 0; i < msg.Length; i++)
        {
            yield return new WaitForSeconds(0.05f);
             GetComponent<TMPro.TextMeshPro>().text += msg[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
