using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    float health = 100;
    [SerializeField] float dps = 10;
    [SerializeField] float cure = 25;
    [SerializeField] float point = 0;



    void Start()
    {
        healthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other){
        if (other.gameObject.tag == "lava"){
            health = health - dps * Time.deltaTime;
            healthBar.value = health;
        }
        if (other.gameObject.tag == "enemy"){
            health = health - dps * Time.deltaTime;
            healthBar.value = health;
        }

        if (health <= 0){
            //Muerto morio
        }

    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag=="cure" && health < 100){
            health += cure;
            if (health > 100){ health = 100; }
            healthBar.value = health;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag =="point"){
            point ++;
            Destroy(other.gameObject);
            print("point");
        }
    }
    

}
