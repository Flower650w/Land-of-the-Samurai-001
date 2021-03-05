using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_agro : MonoBehaviour
{
    //this is the player
    [SerializeField] private Transform player;

    //this is how close the player has to be, to be followed
    [SerializeField] private float maxRange;

    [SerializeField] private float minimumRange;

    //this is the speed of the enemy (us)
    [SerializeField] private float Speed = 5;
    
    //the rigidbody, a.k.a. the physics controller
    [SerializeField] private Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        //find the distance to the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        

        if (distanceToPlayer < maxRange)
        {
            //follow the player
            followPlayer();
        }
        else
        {
            //stop following the player
            StopFollowingPlayer();
        }

        if (distanceToPlayer < minimumRange)
        {
            //follow the player
            StopFollowingPlayer();
        }

    }

    void followPlayer ()
    {
        //we are on the left of the player, so move right
        if (transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(Speed, 0);

            //flip right
            transform.localScale = new Vector2(0.7f, 0.7f);

        }
        //we are on the right of the player, so move left
        else if (transform.position.x > player.position.x)
        {
            rb.velocity = new Vector2(-Speed, 0);

            //flip left
            transform.localScale = new Vector2(-0.7f, 0.7f);

        }
    }

    void StopFollowingPlayer()
    {
        rb.velocity = new Vector2(0, 0);
    }





}

