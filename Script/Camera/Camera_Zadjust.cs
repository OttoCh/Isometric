using UnityEngine;
using System.Collections;

public class Camera_Zadjust : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        AdjustZ(gameObject);
	}

    public void AdjustZ(GameObject Target)
    {
        float x_val = Target.transform.position.x;
        float y_val = Target.transform.position.y;
        Target.transform.position = new Vector3(x_val, y_val, -(x_val-8.0f-y_val)); //koreksi titik terjauh (-0.8f)
        return;
    }
}
