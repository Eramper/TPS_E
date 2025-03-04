using UnityEngine;

public class ShotControl : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float shootCooldown = 1;
    float lastShoot = 0;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (Time.time - lastShoot > shootCooldown) && PlayerManager.amo > 0){
            lastShoot = Time.time;
            Instantiate(projectile, transform.position, transform.rotation);
            PlayerManager.amo --;
        }
    }
}
