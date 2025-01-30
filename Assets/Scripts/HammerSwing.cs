using UnityEngine;

public class HammerSwing : MonoBehaviour
{
    private Rigidbody rb;
    private GameController gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController = FindObjectOfType<GameController>(); // Encontrar GameController en la escena
    }

    void Update()
    {
        // Detectar si el martillo se está moviendo rápidamente
        if (rb.velocity.magnitude > 2.0f) 
        {
            Debug.Log("Swing detected!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detectar si el martillo golpea un topo
        if (collision.gameObject.CompareTag("Mole") || 
            collision.gameObject.CompareTag("RedMole") || 
            collision.gameObject.CompareTag("BlueMole"))
        {
            Debug.Log($"Golpeado topo de tipo: {collision.gameObject.tag}");
            
            Mole mole = collision.gameObject.GetComponent<Mole>();
            if (mole != null)
            {
                int points = 0;
                switch (collision.gameObject.tag)
                {
                    case "Mole":
                        points = 1;
                        break;
                    case "RedMole":
                        points = -1;
                        break;
                    case "BlueMole":
                        points = 2;
                        break;
                }

                mole.Hit();
                if (gameController != null)
                {
                    gameController.AddScore(points);
                }
            }
        }

        // Detectar si el martillo golpea el botón para iniciar el juego
        if (collision.gameObject.CompareTag("Button"))
        {
            Debug.Log("Botón golpeado. Iniciando el juego...");
            if (gameController != null)
            {
                gameController.OnPlay(); // Iniciar el juego
            }
        }
    }
}
