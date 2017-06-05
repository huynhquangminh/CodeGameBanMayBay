using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControlPlay : MonoBehaviour {
    public static GameControlPlay instance;
    public int score, live;
   
    void Awake()
    {

        score = 0;
        live = 0;
        MakeInstance();
       // audio.GetComponent<AudioSource>();
    }

    void MakeInstance()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    [SerializeField]
    private Text varpoint, pointer, scorewin, liveplay;
    [SerializeField]
    private GameObject pausepanel, gameover, youwin, loadlever;
    [SerializeField]
    private AudioClip music;
    [SerializeField]
    private AudioSource audio;
    public void setpointer(int point)
    {
        score = score + point;
        varpoint.text = "" + score;
        pointer.text = varpoint.text;
        
        //scorewin.text = varpoint.text;
    }
    public void setlive(int point)
    {

        live = live + point;
        if (live < 5 && live >= 0)
        {
            liveplay.text = live.ToString();
        }
        else
        {
            live--;
        }
        
        
    }
    public void puasegame ()
    {
        audio.PlayOneShot(music);
        pausepanel.SetActive(true);
        
        Time.timeScale = 0f; // dong bang toan bo game
     
    }
  
   
    public void resumegame()
    {
        audio.PlayOneShot(music);
        pausepanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void restart()
    {
        audio.PlayOneShot(music);
        gameover.SetActive(false);
        Application.LoadLevel("GamePlay");
        Time.timeScale = 1f;
      
    }
    public void options()
    {
        audio.PlayOneShot(music);
        Application.LoadLevel("Menu");
        Time.timeScale = 1f;
    }
    public void planeDied()
    {
       
        gameover.SetActive(true);
        Time.timeScale = 0f;
       

    }
    public void restart2()
    {
        audio.PlayOneShot(music);
        Application.LoadLevel("GamePlay2");
    }
    public void loadlever2()
    {
        loadlever.SetActive(true);
        
    }
    public void btnloadlever2()
    {
        Application.LoadLevel("GamePlay2");
        loadlever.SetActive(false);
    }
    public void Youwingame ()
    {
        youwin.SetActive(true);
       
    }
   
}
