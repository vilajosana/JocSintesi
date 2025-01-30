using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject moleContainer;
    private Mole[] moles;
    public float showMoleTimer = 1.5f;
    public float minShowTime = 1f;
    public float maxShowTime = 2.5f;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public float gameTime = 70f;
    private float remainingTime;
    private bool isGameOver = false;
    private bool isGameStarted = false;

    void Start()
    {
        moles = moleContainer.GetComponentsInChildren<Mole>();
        remainingTime = gameTime;
        UpdateScoreText();
        UpdateTimerText();

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!isGameStarted || isGameOver) return;

        // Actualizar temporizador
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            GameOver();
            return;
        }

        // Mostrar topos aleatoriamente
        showMoleTimer -= Time.deltaTime;
        if (showMoleTimer < 0f)
        {
            Mole selectedMole = moles[Random.Range(0, moles.Length)];
            selectedMole.ShowMole();
            showMoleTimer = Random.Range(minShowTime, maxShowTime);
        }

        UpdateTimerText();
    }

    public void OnPlay() // Este método debe conectarse al botón
    {
        if (!isGameStarted && !isGameOver)
        {
            isGameStarted = true;
            isGameOver = false;
            remainingTime = gameTime; // Resetear tiempo cuando comienza el juego
            score = 0; // Reiniciar la puntuación al iniciar el juego
            UpdateScoreText();
            Debug.Log("Juego iniciado.");
        }
    }

    public void AddScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            UpdateScoreText();
            Debug.Log($"Puntuación actual: {score}");
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        remainingTime = 0;
        UpdateTimerText();

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        foreach (Mole mole in moles)
        {
            mole.HideMole();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = $"Time: {minutes:00}:{seconds:00}";
        }
    }
}
