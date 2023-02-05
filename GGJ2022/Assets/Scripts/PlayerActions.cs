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
    public Transform GrabPoint;
    public Transform GrabOffset;
    public Root root;
    public bool isPullingRoot;
    public bool lanzandoBola = false;
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
        if (Input.GetKeyDown(KeyCode.Q) && !isPullingRoot && GetComponent<PlayerController>().grounded && root != null && objGrabbed == null && !isAttacking)
        {
            isPullingRoot = true;
        }
    }

    private void Attack()
    {
        if(Input.GetKeyDown("e") && !isAttacking && objGrabbed == null && !isPullingRoot)
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
            
            IDamageable rival = enemy.gameObject.GetComponent<IDamageable>();
            rival.ReceiveDamage(new Damage(transform.position, slashList[slashNum].Damage, 0));
            hitEnemy = true;
        }
        anim.Play(slashName);
    }


    public bool isInGround()
    {
        if (Physics2D.OverlapBox(groundCheck.transform.position, new Vector2(0.49f,0.03f), 0, LayerMask.GetMask("Obstacles"))) //checks if set box overlaps with ground
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
            root.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(root == null) return;
        
        root.transform.GetChild(0).gameObject.SetActive(false);
        root = null;

    }



}