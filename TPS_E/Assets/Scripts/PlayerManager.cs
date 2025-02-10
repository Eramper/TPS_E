using TMPro;
using Unity.VisualScripting;
using System;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    float health = 100;
    [SerializeField] float dps = 10;
    [SerializeField] float cure = 25;
    [SerializeField] float point = 0;
    [SerializeField] GameObject finish;
    [SerializeField] TMP_Text Gasolina, primero;



    void Start()
    {
        healthBar.value = health;
        
        Gasolina.text = "Gasolina " + point + "/14";
    }

    // Update is called once per frame
    public void Update()
    {
        if (primero){
            Invoke("Desaparecer", 3);
        }
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
            other.gameObject.GetComponent<animControl>().Dead();
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag=="cure" && health < 100){
            health += cure;
            if (health > 100){ health = 100; }
            healthBar.value = health;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag =="point" && point < 14){
            point ++;
            Gasolina.text = "Gasolina " + point + "/14";
            Destroy(other.gameObject);
            if (point == 14){
                finish.SetActive(true);
            }
        }
        if (other.gameObject.tag == "Finish"){
            SceneManager.LoadScene("Creditos");
        }
    }
    void Desaparecer(){
        primero.gameObject.SetActive(false);
    }
    

}
