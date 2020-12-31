//using UnityEngine;

//public class Gun : MonoBehaviour
//{
//    public float damage = 10f;
//    public float range = 100f;

//    public Camera fpsCam;


//    void Update()
//    {
//        if (Input.GetButtonDown("Fire1"))// Left click
//        {
//            Shoot();
//        }
//    }

//    void Shoot()
//    {
//        RaycastHit hit;
//        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
//        {
//            Debug.Log(hit.transform.name);

//            Enemy target = hit.transform.GetComponent<Enemy>();

//            if (target != null) // If the component is an enemy 
//            {
//                target.TakeDamage(damage);
//            }
//        }

//    }
//}
