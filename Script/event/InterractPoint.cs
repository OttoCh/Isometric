using UnityEngine;
using System.Collections;

public class InterractPoint : MonoBehaviour {

    public TextAsset dialogText;
    public GameObject GameManager;
    public int startline;
    public int endline;
    private Player_Dialog PlayerDialog;

    void Start()
    {
        PlayerDialog = GameManager.GetComponent<Player_Dialog>();
    }

    //void OnCollisionEnter2D(Collision2D coll)
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            //Player_Interract PlayerInter = coll.gameObject.GetComponent<Player_Interract>(); 
            //PlayerInter.InterestTrigger();    //metode ini butuh fungsi disana berupa publik, sendmessage tidak perlu
            coll.gameObject.GetComponent<Player_Interract>().SendMessage("InterestTrigger");
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<Player_Interract>().SendMessage("UninterestTrigger");
        }
    }

    void Player_Interract()
    {
        //yg dipanggil player untuk interaksi dengan interract point
        //memanggil dialog, dialog dipanggil dengan variabel text, startline, dan endline berbeda
        //public void DialogTrigger(TextAsset GivenText, int startLine, int FinishLine)
        PlayerDialog.DialogTrigger(dialogText, startline, endline);
    }
}
