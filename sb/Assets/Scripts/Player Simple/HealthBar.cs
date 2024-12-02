using UnityEngine;
using Image = UnityEngine.UI.Image;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] Image totalHealthBar;
    [SerializeField] Image currentHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        totalHealthBar.fillAmount = playerHealth.currentHealth / playerHealth.fullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / playerHealth.fullHealth;
    }
}
