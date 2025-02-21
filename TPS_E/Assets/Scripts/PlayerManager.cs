using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using Unity.Multiplayer.Center.Common.Analytics;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    public static float health = 100;
    public static float amo = 100;
    public float bullets = 100;
    [SerializeField] float dps = 10;
    [SerializeField] float cure = 25;
    [SerializeField] float point = 0;
    [SerializeField] GameObject finish;
    [SerializeField] TMP_Text Gasolina, primero, ganar, perder, municion;
    [SerializeField] AudioSource mori;
    int dialogo = 1;



    void Start()
    {
        health = 100;
        amo = bullets;
        healthBar.value = health;
        
        Gasolina.text = "Gasolina " + point + "/14";
        municion.text = "Munición " + amo;
    }

    // Update is called once per frame
    public void Update()
    {
        bullets = amo;
        if (primero){
            Invoke("Desaparecer", 3);
        }
        municion.text = "Munición " + amo;
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
            mori.Play();
            perder.gameObject.SetActive(true);
            Invoke("Desaparecer3", 3);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag=="cure" && health < 100){
            health += cure;
            if (health > 100){ health = 100; }
            healthBar.value = health;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag=="amo" && amo < 100){
            amo += cure;
            if (amo > 100){ amo = 100; }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag =="point" && point < 14){
            point ++;
            Gasolina.text = "Gasolina " + point + "/14";
            Destroy(other.gameObject);
            if (point >= 14){
                finish.SetActive(true);
                ganar.gameObject.SetActive(true);
                Invoke("Desaparecer2", 3);
            }
        }
        if (other.gameObject.tag == "Finish"){
            SceneManager.LoadScene("Creditos");
        }

    }
    void Desaparecer(){
        primero.gameObject.SetActive(false);

    }
    void Desaparecer2(){
        ganar.gameObject.SetActive(false);
    }
    void Desaparecer3(){
        perder.gameObject.SetActive(false);
        SceneManager.LoadScene("Inicio");
    }
    

}
