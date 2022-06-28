using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip [] bgmList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public AudioClip [] getBgmList(){
        return bgmList;
    }
}
