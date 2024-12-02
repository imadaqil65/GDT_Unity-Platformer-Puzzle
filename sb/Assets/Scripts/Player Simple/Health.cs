using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] float startingHealth;
    public float currentHealth {get; private set;}
    public float fullHealth {
        get { return startingHealth; }
        private set { startingHealth = value; }
        }
    [SerializeField] Animator animator;
    bool dead;

    [Header("IFrames")]
    [SerializeField] float iFramesDuration;
    [SerializeField] int flashNumber;
    [SerializeField] SpriteRenderer spriteRenderer;

    void Awake(){
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0){
            StartCoroutine(Invulnerability());
        }else if(!dead){
            animator.SetTrigger("die");
            dead = true;
            GetComponent<Movement>().enabled = false;
        }
        
    }

    public void AddHealth(float _value){
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    IEnumerator Invulnerability(){
        Physics2D.IgnoreLayerCollision(6, 8, true);
        Physics2D.IgnoreLayerCollision(6, 9, true);
        for (int i = 0; i < flashNumber; i++)
        {
            spriteRenderer.color = new Color(0.7f,0,0,0.5f);
            yield return new WaitForSeconds(iFramesDuration / (flashNumber * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (flashNumber * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 8, false);
        Physics2D.IgnoreLayerCollision(6, 9, false);
    }
}
