using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Health : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private Collider2D Collider2DTrigger;

    [SerializeField] private int maxHealth = 30;
    int currentHealth;

    //start is called at the beginning
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }else
        {
            animator.SetBool("IsDead", false);
        }
    }


    void Die()
    {


        //play die animation
        animator.SetBool("IsDead", true);

        //disable the enemy
        GetComponent<Snake_Attack>().enabled = false;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Collider2DTrigger.enabled = false;
        this.enabled = false;


        StartCoroutine(Death());

    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
