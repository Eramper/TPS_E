using UnityEngine;
using UnityEngine.SceneManagement;

public class creditos : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("Inicio");
        }
    }
}
