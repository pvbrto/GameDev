using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton para fácil acesso
    public Text scoreText; // Referência para o texto da UI
    private int score = 0; // Pontuação inicial

    void Awake()
    {
        // Garantir que só exista um ScoreManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        //UpdateScoreUI();
    }

    public void AddPoints(int points)
    {
        score += points;
        //UpdateScoreUI();
    }

    public int GetScore()
    {
        return score;
    }

    void OnGUI()
{
    GUI.Label(new Rect(10, 10, 200, 60), "Score: " + score);
    GUI.Label(new Rect(10, Screen.height - 40, 200, 60), "Vidas: " + Player.Instance.health);
}
    // void UpdateScoreUI()
    // {
    //     if (scoreText != null)
    //     {
    //         scoreText.text = "Score: " + score;
    //     }
    // }
}