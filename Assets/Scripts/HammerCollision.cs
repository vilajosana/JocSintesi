using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    public GameController gameController; // Referencia al GameController

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Button")) // Asegúrate de que el botón tenga la etiqueta 'Button'
        {
            // Llamamos a OnPlay() para comenzar el contador del tiempo cuando golpea el botón
            gameController.OnPlay();
        }
    }
}
