using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerMovement mov;
    private Animator anim;
    private SpriteRenderer spriteRend;

    [Header("Particle FX")]
    [SerializeField] private GameObject jumpFX;
    [SerializeField] private GameObject landFX;

    public bool startedJumping {  private get; set; }
    public bool justLanded { private get; set; }
    public bool justAttacked;

    public float currentVelY;

    private void Start()
    {
        mov = GetComponent<PlayerMovement>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        anim = spriteRend.GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        CheckAnimationState();
    }

    public void Update()
    {
        float speed = GetComponent<Rigidbody2D>().velocity.magnitude /10;
        anim.SetFloat("Speed", speed);
        anim.SetBool("Landed", mov.IsGrounded());
    }

    private void CheckAnimationState()
    {
        if (startedJumping)
        {
            anim.SetTrigger("Jump");
            Instantiate(jumpFX, transform.position - (Vector3.up * transform.localScale.y / 11.0f), Quaternion.identity);
            startedJumping = false;
            return;
        }

        if (justLanded)
        {
            anim.SetTrigger("Land");
            Instantiate(landFX, transform.position - (Vector3.up * transform.localScale.y / 2.6f), Quaternion.identity);
            justLanded = false;
            return;
        }

        if (justAttacked)
        {
            anim.SetTrigger("Attack");
            justAttacked = false;
            return;
        }

        anim.SetFloat("Vel Y", mov.RB.velocity.y);
    }
}
