using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private float damage;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
