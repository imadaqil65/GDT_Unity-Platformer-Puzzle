using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stomp : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    [SerializeField] private Rigidbody2D playerRb;

    void Start()
    {
        playerRb = GetComponentInParent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemy = collision.gameObject;
        if(enemy.tag == "Weakpoint"){
            enemy.transform.parent.gameObject.SetActive(false);
            playerRb.velocity = new Vector2(playerRb.velocity.x, bounceForce);
        }
    }
}
