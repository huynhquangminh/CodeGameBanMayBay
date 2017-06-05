using UnityEngine;
using System.Collections;

public class BGScorrling : MonoBehaviour {
    public float scroollSpeed;
	private Material mat;
    private Vector2 offset = Vector2.zero;
    void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }
	// Use this for initialization
	void Start () {
        offset = mat.GetTextureOffset("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
        offset.y += scroollSpeed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", offset);
	}
}
