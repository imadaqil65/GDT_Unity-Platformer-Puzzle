using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCollectible : MonoBehaviour
{
    [SerializeField] GameObject completeCanvas;
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            //End Level script
            Debug.Log("All puzzles solved! Level complete.");
            Destroy(gameObject);
            completeCanvas.SetActive(true);
            collision.GetComponent<Movement>().enabled = false;
            Time.timeScale = 0;
        }
        Debug.Log("Not all puzzles solved");
    }
}
