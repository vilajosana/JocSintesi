using UnityEngine;

public class Mole : MonoBehaviour 
{
    public float visibleYHeight = 6f;
    public float hiddenYHeight = 1.78f;
    private Vector3 myNewXYZPosition;
    public float speed = 4f;
    public float visibleDuration = 1.5f;
    private float currentTimer;
    private bool isHit = false; // Campo para rastrear si el topo ha sido golpeado

    private GameController gameController;

    private void Awake()
    {
        HideMole();
        transform.localPosition = myNewXYZPosition;
        gameController = FindObjectOfType<GameController>();
        currentTimer = visibleDuration;
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            myNewXYZPosition,
            Time.deltaTime * speed
        );

        currentTimer -= Time.deltaTime;
        if (currentTimer < 0)
        {
            HideMole();
            isHit = false; // Restablecer estado al esconderse
        }
    }

    public void HideMole()
    {
        myNewXYZPosition = new Vector3(
            transform.localPosition.x,
            hiddenYHeight,
            transform.localPosition.z
        );
        currentTimer = visibleDuration;
        isHit = false; // Restablecer estado al esconderse
    }

    public void ShowMole()
    {
        myNewXYZPosition = new Vector3(
            transform.localPosition.x,
            visibleYHeight,
            transform.localPosition.z
        );
        currentTimer = visibleDuration;
        isHit = false; // Restablecer estado al mostrarse
    }

    public void Hit()
    {
        if (isHit) return; // Ignorar si ya fue golpeado
        isHit = true;

        // Aquí puedes manejar lo que sucede cuando el topo es golpeado
        Debug.Log("Topo golpeado!");
        HideMole(); // Ejemplo de ocultar el topo
    }
}
