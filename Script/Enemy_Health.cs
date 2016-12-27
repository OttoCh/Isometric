using UnityEngine;
using System.Collections;

public class Enemy_Health : MonoBehaviour {

    public float Health;
    private Animator Enemy_Anim;

	// Use this for initialization
	void Start () {
        Enemy_Anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void DecreaseHP(float dmg)
    {
        Health -= dmg;
        if(Health <= 0)
        {
            DeathAnim();
        }
    }

    void DeathAnim()
    {
        Debug.Log("Death");
        Enemy_Anim.SetBool("Death", true);
    }
}
