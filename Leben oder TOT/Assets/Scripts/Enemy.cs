using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject door;
    public PlayerVitals pv;
    public float health = 50f;
    [SerializeField] private AudioClip damageSound;
    public void TakeDamage(float amount)
    {
        if (health <= 0f)
        {
            Die();
            pv.points += 100;
        }
        else if(gameObject.transform.tag != "Detect Area"){
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Camera.main.transform.position, -0.1f);
        }
        health -= amount;
        AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position, 1000f);  
    }

    void Die()
    {
        Destroy(gameObject);
        Destroy(door);
    }
}
