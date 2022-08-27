using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazelAnim: MonoBehaviour
{
    public GameManager manager;
    private int idleRand;
    private int shootRand;

    public Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Greenlight", false);
        animator.SetBool("Redlight", false);

        animator.SetBool("Shoot", false);
        animator.SetBool("Boogies", false);
    }

    void Update()
    {
        idleRand = Random.Range(1, 5);
        animator.SetInteger("IdleNum", idleRand);

        shootRand = Random.Range(1, 3);
        animator.SetFloat("ShootNum", shootRand);

    }

    public void Idle()
    {
        animator.SetBool("Idle", true);
        

        animator.SetBool("Greenlight", false);
        animator.SetBool("Redlight", false);

        animator.SetBool("Shoot", false);
        animator.SetBool("Boogies", false);
    }

    public void Greenlight()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Greenlight", true);
        animator.SetBool("Redlight", false);
        animator.SetBool("Shoot", false);
    }

    public void Redlight()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Greenlight", false);
        animator.SetBool("Redlight", true);
        
    }

    public void Shoot()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Greenlight", false);

        animator.SetBool("Shoot", true);
        
    }

    public void Boogies()
    {
        animator.SetBool("Boogies", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Greenlight", false);
        animator.SetBool("Redlight", false);
        animator.SetBool("Shoot", false);
    }
}
