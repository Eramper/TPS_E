using UnityEngine;

public class ShotControl : MonoBehaviour
{
    [SerializeField] GameObject projectile;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }
}
