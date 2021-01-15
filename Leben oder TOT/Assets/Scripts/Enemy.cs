using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject door;

    public const float maxHealth = 100f;
    public PlayerVitals pv;
    public float health = 100f;
    [SerializeField] private AudioClip damageSound;
    public GameObject healthBarUI;
    public Slider slider;
    public ParticleSystem DieEffect = null;

    public void Start(){
        slider.value = maxHealth;
    }

 
    public void TakeDamage(float amount)
    {

        
        healthBarUI.SetActive(true);
        if (health <= 0f)
        {
            Die();
            pv.points += 100;
        }
        else if(gameObject.transform.tag != "Detect Area"){
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Camera.main.transform.position, -0.1f);
                DieEffect.Play() ;
        }
        health -= amount;
        AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position, 1000f);
        slider.value = health;
    }

    void Die()
    {
        Destroy(gameObject);
        Destroy(door);
        Destroy(healthBarUI);
        Destroy(slider);
    }
}
