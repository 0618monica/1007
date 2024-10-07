using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
public class PlayerHandler : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidbody2D;
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.velocity = new Vector2(-5, rigidbody2D.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            animator.SetBool("running", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.velocity = new Vector2(5, rigidbody2D.velocity.y);
            transform.localScale = new Vector2(1, 1);
            animator.SetBool("running", true);
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
            animator.SetBool("running", false);
        }
   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 10.0f);
        }
    }
}