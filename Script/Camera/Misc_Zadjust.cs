using UnityEngine;
using System.Collections;

public class Misc_Zadjust : MonoBehaviour {

    public Camera_Zadjust AdjustLayer;

    void Awake()
    {
        AdjustLayer.AdjustZ(gameObject);
    }
}
