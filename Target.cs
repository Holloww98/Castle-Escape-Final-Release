
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public GameObject drop = null;//your sword

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }

    private void OnDestroy() //called, when enemy will be destroyed
    {
        Instantiate(drop, transform.position, drop.transform.rotation); //your dropped sword
    }


}
