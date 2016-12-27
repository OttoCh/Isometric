using UnityEngine;
using System.Collections;

public class Level_ChangeScene : MonoBehaviour {

    public string LevelName;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Application.LoadLevel(LevelName);
        }
    }
}
