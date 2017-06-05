using UnityEngine;
using System.Collections;
public class plane : MonoBehaviour {

   
    private Rigidbody2D myBody;
    [SerializeField]
    private GameObject builet;
    [SerializeField]
    private GameObject builet2;
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip builetclip;
    private bool canshoot = true;

    public float planeSpeed;
    private Vector2 leftFingerPos  = Vector2.zero;
    private Vector2 leftFingerLastPos  = Vector2.zero;
    private Vector2 leftFingerMovedBy  = Vector2.zero;
 
    public float slideMagnitudeX  = 0.0f;
    public float slideMagnitudeY = 0.0f;
    

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    void PlaneMove()
    {  
        float x, y;
        x = Input.GetAxisRaw("Horizontal")*planeSpeed;
        Debug.Log("x = " + x);
        y = Input.GetAxisRaw("Vertical")*planeSpeed;
        Debug.Log("y = " + y);
        myBody.velocity = new Vector2(x, y);
        
    }
    void planemovefortouch()
    {
        if (Input.touchCount >= 1)
        {

            Touch touch = Input.GetTouch(0); // GetTouch() trả về Touch struct 

            if (canshoot == true)    // bắn đạn
            {
                if (GameControlPlay.instance.score >= 15)
                {
                    audio.PlayOneShot(builetclip);
                    StartCoroutine(shoot2());
                }
                else
                {
                    audio.PlayOneShot(builetclip);
                    StartCoroutine(shoot());
                }

            }
            if (touch.phase == TouchPhase.Began) // Touch struct trả về có ngón tay chạm màn hình
            {
                leftFingerPos = Vector2.zero;
                leftFingerMovedBy = Vector2.zero;

                slideMagnitudeX = 0.0f;
                slideMagnitudeY = 0.0f;

                // lưu vị trí bắt đầu của chỗ chạm
                leftFingerPos = touch.position;

            }

            else if (touch.phase == TouchPhase.Moved) // Touch struc trả về ngón tay di chuyển 
            {
                leftFingerMovedBy = touch.position - leftFingerPos; // vị trí chạm hiện tại trừ vị trí chạm lúc nãy lưu ở trên, ra giá trị thay đổi

                leftFingerPos = touch.position; // vị trí chạm hiện tại

                // kéo ngang
                slideMagnitudeX = leftFingerMovedBy.x / Screen.width;

                // kéo dọc
                slideMagnitudeY = leftFingerMovedBy.y / Screen.height;

            }

            else if (touch.phase == TouchPhase.Stationary) // Touch struct trả về ngón tay đứng yên
            {
                leftFingerPos = touch.position; // vị trí chạm hiện tại

                slideMagnitudeX = 0.0f;
                slideMagnitudeY = 0.0f;

            }

            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) // Touch struct trả về khi hệ thống không track
                                                                                            // được bất cứ ngón nào trên màn hình
            {
                slideMagnitudeX = 0.0f;
                slideMagnitudeY = 0.0f;
            }
        }
        myBody.velocity = new Vector2(slideMagnitudeX * 300, slideMagnitudeY * 300) * planeSpeed;
    }
    void Start () {}

    // Update is called once per frame
    void FixedUpdate()
    {
        //plane move by key 
        PlaneMove();
        // plane move by touch 
       // planemovefortouch();
    }
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
            {
                if (canshoot == true)
                {
                if (GameControlPlay.instance.score >= 20)
                {
                    audio.PlayOneShot(builetclip);
                    StartCoroutine(shoot2());
                }
                else
                {
                    audio.PlayOneShot(builetclip);
                    StartCoroutine(shoot());
                }
                
            }
        }
    }
    // thuc hien lai mot hanh dong thi dung ham IE
    IEnumerator shoot()
    {
        canshoot = false;
        // lấy vị trí của máy bay sau đó cộng lên rồi cho viên đạn bắn tại vị tí
        // đó

        Vector3 temp = transform.position;
        temp.y += 0.5f;
       
        //truyen vào vật cần xuất ra, vị trí, và không cho vật đó xoay
        Instantiate(builet, temp, Quaternion.identity); // sinh ra ven dan
      
        yield return new WaitForSeconds(0.3f); // 0.3s thi ban ra vien dan
        canshoot = true;
    }
    IEnumerator shoot2()
    {
        canshoot = false;
        // lấy vị trí của máy bay sau đó cộng lên rồi cho viên đạn bắn tại vị tí
        // đó

        Vector3 temp = transform.position;
        temp.x += 0.5f;
        Vector3 temp2 = transform.position;
        temp2.x -= 0.5f;
        //truyen vào vật cần xuất ra, vị trí, và không cho vật đó xoay
        Instantiate(builet, temp, Quaternion.identity); // sinh ra ven dan
        Instantiate(builet2, temp2, Quaternion.identity);
        yield return new WaitForSeconds(0.5f); // 0.3s thi ban ra vien dan
        canshoot = true;
    }
  
    void OnTriggerEnter2D(Collider2D target)
    {
       
        if (target.tag == "border")
        {
            Destroy(gameObject);
        }
    }
   
}
