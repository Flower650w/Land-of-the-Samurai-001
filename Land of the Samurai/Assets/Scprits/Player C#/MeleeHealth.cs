using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHealth : MonoBehaviour
{
    [SerializeField] 
    private Animator animator;

    [SerializeField] 
    private GameObject snakeEnemy;

    [SerializeField]
    private GameObject SnakePrefab;

    [SerializeField] 
    private int maxHealth = 100;

    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // play hurt animation
        animator.SetTrigger("Hurt");


        // you shall DIE
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // die animation
        animator.SetBool("IsDead", true);

        // disable the player 
        GetComponent<PlayerMovement2D>().enabled = false;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
    }



}
