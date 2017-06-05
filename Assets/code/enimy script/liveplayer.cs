 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class liveplayer : MonoBehaviour {

    public float speedlive;
    public int  liveplay;
    private Rigidbody2D mybody;
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip music;
    
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        liveplay = 0;

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        mybody.velocity = new Vector2(0f, -speedlive);
        transform.Rotate(0, 3, 0);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            liveplay++;
            if (GameControlPlay.instance != null)
            {
                GameControlPlay.instance.setlive(liveplay);
            }
            Destroy(gameObject,0.1f);
            audio.PlayOneShot(music);
        }
        if (target.tag == "border")
        {
            Destroy(gameObject);
        }
       
    }
}
