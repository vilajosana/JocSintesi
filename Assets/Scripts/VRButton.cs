using UnityEngine;

public class VRButton : MonoBehaviour
{
    public GameController gameController; // Referencia al GameController
    private bool isPressed = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isPressed && collision.gameObject.CompareTag("Hammer"))
        {
            isPressed = true; // Evitar múltiples activaciones
            if (gameController != null)
            {
                gameController.OnPlay(); // Llamada a OnPlay
            }
            else
            {
                Debug.LogError("GameController no está asignado.");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer"))
        {
            isPressed = false; // Permitir reactivación al salir de la colisión
        }
    }
}
