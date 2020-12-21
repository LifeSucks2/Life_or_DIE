using UnityEngine;


public class Enemy : MonoBehaviour
{
    public PlayerVitals pv;
    public float health = 50f;
    [SerializeField] private AudioClip damageSound;
    public void TakeDamage(float amount)
    {
        health -= amount;
        AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position, 1000f);
        if(gameObject.transform.tag != "Detect Area"){
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Camera.main.transform.position, -6f);
        }
        
        if (health <= 0f)
        {
            Die();
            pv.points += 100;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
