using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Attack : MonoBehaviour
{
    //this is an animator which allows us to animate our Game Object
    [SerializeField] private Animator animator;

    //attack vars
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int attackDamage = 15;

    [SerializeField] private float attackRate = 1.5f;
    float nextAttackTime = 0f;

    //this allows us to "tag" or define all game objects with our selected layer
    [SerializeField] private LayerMask PlayerLayers;

    // Update is called once per frame
    void Update()
    {
       
    }
    
    
    
    void OnTriggerEnter2D (Collider2D attackTrigger)
    {

        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }


    }

    void Attack ()
    {
        //play attack animation
        //this will be done later on


        //detect near by players
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, PlayerLayers);


        //damage them
        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<MeleeHealth>().TakeDamage(attackDamage);
        }
    
    
    }  

}
