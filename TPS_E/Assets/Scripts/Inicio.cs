using UnityEngine;
//Hace falta esto para que funcione, recordar poner las escenas en el exportar de unity
using UnityEngine.SceneManagement;

// el nombre del documento sera el que busquemos cuando enlacemos botones, este caso "Inicio ()"
public class Inicio : MonoBehaviour
{
    //Se crea un editor con el "public" delante para que los botones lo puedan reconocer
    public void StartGame()
    {
        SceneManager.LoadScene("Nivel");
    }

    // Se pone nombre (lo amarillo, lo usaremos para enlazarlo) por cada boton que haya para enlazarlos en unity
    public void ExitGame()
    {
        print("Hasta luego");
        Application.Quit();
    }

    //El update lo mantego para añadir el salir del juego con scape
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
            //El print esta para comprobar que funciona
            print("Hasta luego");
        }
    }

    public void Credits(){
        SceneManager.LoadScene("Creditos");
    }
}
