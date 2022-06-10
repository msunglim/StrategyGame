using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNameSetting : MonoBehaviour
{
    [SerializeField]
    private int playerCode;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMPro.TextMeshPro>().text =
            (playerCode == 0)
                ? ""+ GameMaster
                    .p1
                    .GetComponent<playerControll>()
                    .getCharacter()
                    .GetComponent<characterSetting>()
                    .getCharacterName()
                :""+ GameMaster
                    .p2
                    .GetComponent<playerControll>()
                    .getCharacter()
                    .GetComponent<characterSetting>()
                    .getCharacterName();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
