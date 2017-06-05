using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private AudioClip music;
    [SerializeField]
    private AudioSource audio;

    
 
  
    public void PlayGameButton()
    {
        audio.PlayOneShot(music);
        Application.LoadLevel("GamePlay");
    }
    public void  QuitGameButton()
    {
        audio.PlayOneShot(music);
        Application.Quit();
    }
   
}
  