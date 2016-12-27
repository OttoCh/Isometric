using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        RectTransform trans;
        trans = gameObject.GetComponent < RectTransform > ();
        Debug.Log(trans.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
