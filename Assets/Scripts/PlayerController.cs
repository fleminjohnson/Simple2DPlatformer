using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 5.0f;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isFacingRight = true;
    private Vector3 dimention;

    // Start is called before the first frame update
    void Awake()
    {
        rb   = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dimention = transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis(Tags.Horizontal);
        rb.velocity = new Vector2(move*maxSpeed, rb.velocity.y);
        anim.SetFloat(Tags.Speed, Mathf.Abs(move));

        if (move > 0 & !isFacingRight) Flip();
        else if(move < 0 & isFacingRight) Flip();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        dimention.x *= -1;
        transform.localScale = dimention;
    }
}
