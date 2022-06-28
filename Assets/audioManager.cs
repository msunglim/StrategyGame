using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] bgmList;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public AudioClip[] getBgmList()
    {
        return bgmList;
    }

    public void playAudio(int index)
    {
        audioSource.clip = bgmList[index];
        audioSource.Play();
    }
}
