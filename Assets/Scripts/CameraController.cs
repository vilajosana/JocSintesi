using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensibilidad del ratón
    public Transform playerBody;          // Referencia al cuerpo del jugador
    public float moveSpeed = 5f;          // Velocidad de movimiento del jugador

    private float xRotation = 0f;         // Rotación en el eje X

    void Start()
    {
        // Oculta el cursor y lo bloquea en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Llamamos a las funciones de rotación y movimiento
        RotateCamera();
        MovePlayer();
    }

    void RotateCamera()
    {
        // Captura el movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Ajusta la rotación en el eje X para limitar el ángulo vertical
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita el ángulo vertical para no girar demasiado

        // Aplica la rotación en los ejes X e Y
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void MovePlayer()
    {
        // Captura el input de movimiento
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calcula la dirección de movimiento relativa al cuerpo del jugador
        Vector3 moveDirection = playerBody.forward * moveZ + playerBody.right * moveX;

        // Mueve al jugador en la dirección calculada
        playerBody.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}