using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float speedenemy ;
    private Rigidbody2D myBody;
   
    [SerializeField]
    private GameObject builet, builet2, builet3;
    [SerializeField]
    private GameObject planeanimation;
   
   


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
  
    // Use this for initialization
    void Start () {
       
        if (GameControlPlay.instance.score > 200)
        {
            StartCoroutine(shoot3());
        }else
        {
            if(GameControlPlay.instance.score > 50)
            {
                StartCoroutine(shoot2());
            }
            else
            {
                StartCoroutine(shoot());
            }
           
        }

       
    } 

    IEnumerator shoot()
    {
        Vector3 temp = transform.position;
        temp.y -= 0.5f;
        //truyen vào vật cần xuất ra, vị trí, và không cho vật đó xoay
        Instantiate(builet, temp, Quaternion.identity); // sinh ra ven dan
        yield return new WaitForSeconds(Random.Range(1f, 3f));
      
        StartCoroutine(shoot());
       
    }
    IEnumerator shoot2()
    {
        Vector3 temp = transform.position;
        temp.x += 0.5f;
        Vector3 temp2 = transform.position;
        temp2.x -= 0.5f;
        //truyen vào vật cần xuất ra, vị trí, và không cho vật đó xoay
        Instantiate(builet, temp, Quaternion.identity); // sinh ra ven dan
        Instantiate(builet2, temp2, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1f, 2f));

        StartCoroutine(shoot2());

    }
    IEnumerator shoot3()
    {
        Vector3 temp = transform.position;
        temp.x += 0.5f;
        Vector3 temp3 = transform.position;
        temp3.y -= 0.5f;
        Vector3 temp2 = transform.position;
        temp2.x -= 0.5f;
        //truyen vào vật cần xuất ra, vị trí, và không cho vật đó xoay
        Instantiate(builet, temp, Quaternion.identity); // sinh ra ven dan
        Instantiate(builet2, temp2, Quaternion.identity);
        Instantiate(builet3, temp3, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1f, 2f));

        StartCoroutine(shoot2());

    }
    // Update is called once per frame
    void FixedUpdate () {
      
        if (GameControlPlay.instance.score > 15)
        {
            speedenemy = 4;
        }
        if (GameControlPlay.instance.score > 35)
        {
            speedenemy = 6;
        }
        myBody.velocity = new Vector2(0f, -speedenemy);
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
                Instantiate(planeanimation, target.transform.position, Quaternion.identity); // thuc hinh animation die
                Destroy(target.gameObject);
                GameControlPlay.instance.planeDied(); // ke thua lop gamecontrolplay
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
