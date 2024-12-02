using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomlessPit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            Health health = collision.GetComponent<Health>();
            health.TakeDamage(health.fullHealth);
        }
    }
}
