using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    Health playerHealth;

    void Awake()
    {
        playerHealth = GetComponentInParent<Health>();
    }

    public void Respawn()
    {
        playerHealth.Respawn();
    }
}
