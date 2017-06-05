using UnityEngine;
using System.Collections;

public class builetenemy : MonoBehaviour {

    public float speedbuilet;
    private Rigidbody2D myBody;
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip music, music2;
    [SerializeField]
    private GameObject planeanimation;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameControlPlay.instance.score > 15)
        {
            speedbuilet = 6;
        }
        if (GameControlPlay.instance.score > 40)
        {
            speedbuilet = 10;
        }
        myBody.velocity = new Vector2(0f, -speedbuilet);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {

            if (GameControlPlay.instance != null)
            {
                GameControlPlay.instance.setlive(-1);
            }
            if (GameControlPlay.instance.live < 0)
            {
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
        if (GameControlPlay.instance.score >= 600)
        {
           
            Destroy(gameObject);
        }
        if (target.tag == "border")
        {
            Destroy(gameObject);
        }
    }
}
