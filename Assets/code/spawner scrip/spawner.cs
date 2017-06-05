using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

    public float timeout, timeout2;
    [SerializeField]
    private GameObject enemy, enemy2, enemy3, enemy4, live;
    private BoxCollider2D box;

	// Use this for initialization
	void Awake () {
        box = GetComponent<BoxCollider2D>();
        timeout = 3f;
        timeout2 = 4f;
	}
	void Start()
    {


            StartCoroutine(spawnerenemy());
            StartCoroutine(spawnerenemy2());
            StartCoroutine(spawnerenemy3());
            StartCoroutine(spawnerenemy4());

             StartCoroutine(spawnerlive());


    }
	// Update is called once per frame
	void Update () {
       
        if ( GameControlPlay.instance.score > 50 )
        {
            timeout = 2f;
            timeout2 = 3f;
        }
	
	}
    IEnumerator spawnerenemy ()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;
        Vector3 temp = transform.position;
        temp.x = Random.Range(minX, maxX);
        Instantiate(enemy, temp, Quaternion.identity);
        StartCoroutine(spawnerenemy());
    }
    IEnumerator spawnerenemy2()
    {
        yield return new WaitForSeconds(Random.Range(1f, timeout));
        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;
        Vector3 temp2 = transform.position;
        temp2.x = Random.Range(minX, maxX);
        Instantiate(enemy2, temp2, Quaternion.identity);

        StartCoroutine(spawnerenemy2());
    }
    IEnumerator spawnerenemy3()
    {
        yield return new WaitForSeconds(Random.Range(1f, timeout));
        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;
        Vector3 temp3 = transform.position;
        temp3.x = Random.Range(minX, maxX);
        Instantiate(enemy3, temp3, Quaternion.identity);

        StartCoroutine(spawnerenemy3());
    }
    IEnumerator spawnerenemy4()
    {
            yield return new WaitForSeconds(Random.Range(1f, timeout2));
            float minX = -box.bounds.size.x / 2f;
            float maxX = box.bounds.size.x / 2f;
            Vector3 temp4 = transform.position;
            temp4.x = Random.Range(minX, maxX);
            Instantiate(enemy4, temp4, Quaternion.identity);
            StartCoroutine(spawnerenemy4());
        
       
    }
    IEnumerator spawnerlive()
    {
        yield return new WaitForSeconds(9f);
        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;
        Vector3 temp4 = transform.position;
        temp4.x = Random.Range(minX, maxX);
        Instantiate(live, temp4, Quaternion.identity);
        StartCoroutine(spawnerlive());
    }
}
