using UnityEngine;

public class FireControl : MonoBehaviour
{

    [SerializeField] ParticleSystem fire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fire.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)){
            fire.Play();
        }
        if (Input.GetMouseButtonUp(1)){
            fire.Stop();
        }
    }
}
