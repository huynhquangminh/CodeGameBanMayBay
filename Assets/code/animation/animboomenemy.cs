using UnityEngine;
using System.Collections;

public class animboomenemy : MonoBehaviour {

    [SerializeField]
    private float playtime;

	void Start () {
        Destroy(gameObject,playtime);
	}
	
	
}
