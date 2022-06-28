using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMaster : MonoBehaviour
{
    public static AudioMaster am = null;
    // Start is called before the first frame update
    
    private static AudioSource audioSource;
    
    private static AudioClip [] audioList;

     void Awake()
    {
         if (am != null)
        {
            Destroy (gameObject);
            return;
        }
        am = this;
        audioSource = GetComponent<AudioSource>();
        audioList = GetComponent<audioManager>().getBgmList();
        playMainAudio();
        DontDestroyOnLoad (gameObject);
    }

    public static void playMainAudio(){
   
        audioSource.clip = audioList[0];
        audioSource.Play(); 
    }
    public static void playCombatPlannerAudio(){
      
        audioSource.clip = audioList[1];
        audioSource.Play(); 
    }
    public static void playBattleFieldAudio(int index){
      
        audioSource.clip = audioList[index];
        audioSource.Play(); 
    }
}
