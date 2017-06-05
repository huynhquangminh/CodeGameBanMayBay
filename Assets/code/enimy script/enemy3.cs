using UnityEngine;
using System.Collections;

public class enemy3 : MonoBehaviour {

    public float seepenemy;
    private Rigidbody2D mybody;
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip music,music2;
    [SerializeField]
    private GameObject planeanimation;
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameControlPlay.instance.score > 15 )
        {
            seepenemy = 5;
        }
        if (GameControlPlay.instance.score > 35)
        {
            seepenemy =8;
        }
        mybody.velocity = new Vector2(0f, -seepenemy);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
         
            if (GameControlPlay.instance != null)
            {
                GameControlPlay.instance.setlive(-1);
            }
            if (GameControlPlay.instance.live <0)            {
                audio.PlayOneShot(music);
                Instantiate(planeanimation, target.transform.position, Quaternion.identity); // thuc hinh animation die
                Destroy(target.gameObject);
                GameControlPlay.instance.planeDied(); // ke thua lop gamecontrolplay
            }
            else
            {
                audio.PlayOneShot(music2);
            }
        }
        if (target.tag == "border")
        {
            Destroy(gameObject);
        }
        if (GameControlPlay.instance.score >= 600)
        {
            Destroy(gameObject);
        }
    }
}
