using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat2D : MonoBehaviour
{
    //animator of the player, chooses what animation he plays
    [SerializeField] private Animator animator;
    [Space]
    
    /*
     *the 1st variable is the point that you damage/attack the enemy
     *the second variable is the range of your attack
     *and the third variable is who you will attack, assgined by layers. 
     */

    [Header("Attack Variables")]
    [SerializeField] private Transform attackPoint; //1st
    [SerializeField] private float attackRange = 0.3f;//2nd
    [SerializeField] private LayerMask EnemiesToAttack;//3rd

    //this is the damage the player does to a an enemy or other player
    [SerializeField] private int attackdamage = 15;

    //this is the cooldown for the players attack so that he does not get all OP up in here
    [SerializeField] private float attackCoolDown = 1.5f;
    
    //the time the player can attack next
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextAttackTime)
        {

        //If the left mouse button is pressed, preform the attack command.
           if (Input.GetMouseButton(0))
           {
                Attack();
                nextAttackTime = Time.time + 1f / attackCoolDown;
           } 

        }
    
       //this is the attack command which will play the attack animation, hurt the enemy, and hurt other players.
       void Attack ()
       {
            //play attack animation
            animator.SetTrigger("Attack");

            //detect enemys or other players in range of the attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemiesToAttack);


            //damage the enemeys
            //this line is to desypher each enemy from the hitEnemies variable
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Snake_Health>().TakeDamage(attackdamage);
            }
       }
      
       void OnDrawGizmosSelected ()
       {
            if (attackPoint == null)
                return;

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
       }





    }
}
