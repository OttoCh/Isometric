using UnityEngine;
using System.Collections;

public class Player_Interract : MonoBehaviour {

    public GameObject Exclamation;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    void InterestTrigger()
    {
        //A = Instantiate(Exclamation, Player_Pos_V3, Quaternion.identity) as GameObject;
        //A.transform.parent = Player_Pos.transform;    //masalah di delay merubah object menjadi child, gara gara ini tidak bisa mengikuti gerakan seharusnya player
        Exclamation.SetActive(true);
    }

    void UninterestTrigger()
    {
        //Destroy(A);
        Exclamation.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Interest")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                coll.gameObject.SendMessage("Player_Interract");
                UninterestTrigger();
            }
        }
    }
}
