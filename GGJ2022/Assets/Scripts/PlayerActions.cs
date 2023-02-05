using System.Collections;
using System.Collections.Generic;
using ProjectUtils.Attacking;

using UnityEngine;
using TMPro;
using System;

public class PlayerActions : MonoBehaviour
{
    [Header("Public Variables")]
    public Animator anim;
    public GameObject groundCheck;

    [Header("Combo Attacks")]
    public LayerMask enemyLayer;
    public Slash[] slashList;
    public bool isAttacking = false;
    public bool hitEnemy = false;

    [Header("Root Extractor")]
    public Root root;
    public bool isPullingRoot;
    public GameObject objGrabbed;
    public Trajectory trajectory;

    private void Start()
    {
        anim = GetComponent<Animator>();
        trajectory = GetComponent<Trajectory>();
    }

    private void Update()
    {
        Attack();
        ExtractRoot();
    }

    private void ExtractRoot()
    {
        if (Input.GetKeyDown("z") && !isPullingRoot && isInGround() && root != null && objGrabbed == null && !isAttacking)
        {
            isPullingRoot = true;
        }
    }

    private void Attack()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        if(Input.GetKeyDown("space") && !isAttacking && objGrabbed == null && !isPullingRoot)
=======
        if(Input.GetKeyDown("e") && !isAttacking && objGrabbed == null && !isPullingRoot)
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        if(Input.GetKeyDown("e") && !isAttacking && objGrabbed == null && !isPullingRoot)
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        if(Input.GetKeyDown("e") && !isAttacking && objGrabbed == null && !isPullingRoot)
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
        {
            isAttacking = true;
        }
    }

    public void Slash(int slashNum,string slashName)
    {
        slashNum -= 1;
        hitEnemy = false;
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(slashList[slashNum].AttackPoint.position, slashList[slashNum].AttackRange / 2, 0f, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            IDamageable rival = enemy.gameObject.GetComponent<IDamageable>();
            rival.ReceiveDamage(new Damage(transform.position, slashList[slashNum].Damage, 0));

=======
            
            IDamageable rival = enemy.gameObject.GetComponent<IDamageable>();
            rival.ReceiveDamage(new Damage(transform.position, slashList[slashNum].Damage, 0));
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
            
            IDamageable rival = enemy.gameObject.GetComponent<IDamageable>();
            rival.ReceiveDamage(new Damage(transform.position, slashList[slashNum].Damage, 0));
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
            
            IDamageable rival = enemy.gameObject.GetComponent<IDamageable>();
            rival.ReceiveDamage(new Damage(transform.position, slashList[slashNum].Damage, 0));
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
            hitEnemy = true;
        }
        anim.Play(slashName);
    }


    public bool isInGround()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        if (Physics2D.OverlapBox(groundCheck.transform.position, new Vector2(0.49f,0.03f), 0, LayerMask.GetMask("Ground"))) //checks if set box overlaps with ground
=======
        if (Physics2D.OverlapBox(groundCheck.transform.position, new Vector2(0.49f,0.03f), 0, LayerMask.GetMask("Obstacles"))) //checks if set box overlaps with ground
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        if (Physics2D.OverlapBox(groundCheck.transform.position, new Vector2(0.49f,0.03f), 0, LayerMask.GetMask("Obstacles"))) //checks if set box overlaps with ground
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
        if (Physics2D.OverlapBox(groundCheck.transform.position, new Vector2(0.49f,0.03f), 0, LayerMask.GetMask("Obstacles"))) //checks if set box overlaps with ground
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
        {
            return true;
        }
        return false;

    }

    private void OnDrawGizmosSelected()
    {
        if (slashList[0].AttackPoint == null) return;

        Gizmos.DrawWireCube(slashList[0].AttackPoint.position, slashList[0].AttackRange);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Root")
        {
            root = collision.gameObject.GetComponent<Root>();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
            Debug.Log("A");
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
            Debug.Log("A");
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
=======
            Debug.Log("A");
>>>>>>> 508a3ebf5ab3f635220f62675f44fd78b5fa40db
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        root = null;

    }



}
