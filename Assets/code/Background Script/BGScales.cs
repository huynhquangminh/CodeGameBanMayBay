using UnityEngine;
using System.Collections;

public class BGScales : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        // 
        var height = Camera.main.orthographicSize * 2f;
        var witdh = height * Screen.width / Screen.height;
        transform.localScale = new Vector3(witdh, height, 0f);


	}
	
	
}
