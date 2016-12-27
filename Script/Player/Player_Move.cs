using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour
{
    public GameObject Skeleton;
    private Animator Move_Anim;
    public Rigidbody2D rb;
    public Vector2 pos;
    public float MoveSpeed;
    public bool EnableMove;
    public Camera_Zadjust AdjustLayer;
    public GameObject AttackColl;

    //Kode Integer gerakan 1-Kiri, 2-Atas, 3-Kanan, 4-Bawah
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = transform.position;
        Move_Anim = Skeleton.GetComponent<Animator>();
        Move_Anim.SetInteger("Move", 2);
    }

    // Update is called once per frame
    void Update()
    {
        //karena menggunakan rasio 16:9 maka gerakan ke arah x dan y tidak seharusnya menggunakan kecepatan yang sama, kecepatannya juga harus 16:9
        AdjustLayer.AdjustZ(gameObject);
        if (EnableMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Move_Anim.SetInteger("Move", 2);
                rb.velocity = new Vector2(rb.velocity.x, 0.9f * MoveSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Move_Anim.SetInteger("Move", 1);
                rb.velocity = new Vector2(-1.6f * MoveSpeed, rb.velocity.y);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Move_Anim.SetInteger("Move", 4);
                rb.velocity = new Vector2(rb.velocity.x, -0.9f * MoveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Move_Anim.SetInteger("Move", 3);
                rb.velocity = new Vector2(1.6f * MoveSpeed, rb.velocity.y);
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            //ATTACK
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Player_Attack();
            }
        }
    }

    void Player_Attack()
    {
        float rad = 0.1f;
        Vector2 Pos = new Vector2(AttackColl.transform.position.x, AttackColl.transform.position.y);
        Collider2D[] hitCollider = Physics2D.OverlapCircleAll(Pos,rad);
        Debug.Log(hitCollider[0]);
        float dmg = 1.0f;
        for(int i=0; i<=hitCollider.Length; i++)
        {
            Debug.Log(hitCollider.Length);
            if (hitCollider[i].gameObject.tag == "Enemy") hitCollider[i].SendMessage("DecreaseHP", dmg);
        }
    }

    public void disable_Move()
    {
        EnableMove = false;
    }

    public void enable_Move()
    {
        EnableMove = true;
    }
}
