using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class animControl : MonoBehaviour
{
    Animator anim;
    [SerializeField] float jumpCooldown = 1;
    float lastJump = 0;
    [SerializeField] float shootCooldown = 1;
    float lastShoot = 0;
    public AudioSource disparo;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");
        if (movementX != 0 || movementZ != 0){
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && (Time.time - lastJump > jumpCooldown)){
            lastJump = Time.time;
            anim.SetTrigger("hasJumped");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            anim.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)){
            anim.SetBool("Run", false);
        }
        if (Input.GetMouseButtonDown(0) && (Time.time - lastShoot > shootCooldown)){
            lastShoot = Time.time;
            anim.SetBool("Shoot", true);
            disparo.Play();
        }
        if (Input.GetMouseButtonUp(0)){
            anim.SetBool("Shoot", false);
        }
    }
    public void Dead(){
        //PENSAR MECANICA EXTRA (posible munición)
        //AÑADIR MUERTE AL JUGADOR
        anim.SetBool("Dead", true);
    }
}
