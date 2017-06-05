using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class itemsbuilet : MonoBehaviour
{

    public float speeditems;
    public int items;
    private Rigidbody2D mybody;
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip music;

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

        mybody.velocity = new Vector2(0f, -speeditems);
        transform.Rotate(0, 4, 0);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            items = 1;
            Destroy(gameObject, 0.1f);
            audio.PlayOneShot(music);
        }
        if (target.tag == "border")
        {
            Destroy(gameObject);
        }

    }
}
