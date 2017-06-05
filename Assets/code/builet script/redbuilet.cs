using UnityEngine;
using System.Collections;

public class redbuilet : MonoBehaviour {

    public float speedbuilet;
    private Rigidbody2D myBody;
    public int point;
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip audioenemy;
    [SerializeField]
    private GameObject anim;
    void Awake()
    {
        point = 0;
        myBody = GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame

    void FixedUpdate()
    {
        myBody.velocity = new Vector2(0f, speedbuilet);


    }
    public void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Enemy")
        {

            audio.PlayOneShot(audioenemy);
            point++;
            if (GameControlPlay.instance != null)
            {
                GameControlPlay.instance.setpointer(point);
            }
            // lay vi tri 

            Destroy(target.gameObject); // huy may bay
            Destroy(gameObject, 0.15f); // huy vien dan
            Instantiate(anim, target.transform.position, Quaternion.identity);
        }

        if (target.tag == "boder2")
        {
            Destroy(gameObject);
        }
        if (GameControlPlay.instance.score >= 600)
        {
            GameControlPlay.instance.Youwingame();
        }

    }
}
