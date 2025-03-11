using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static int PlayerScore1 = 0; // Pontuação do player 1
public static int PlayerScore2 = 0; // Pontuação do player 2

public static void Score (string wallID) {
    if (wallID == "RightWall")
    {
        PlayerScore1++;
    } else
    {
        PlayerScore2++;
    }
}

// void OnGUI () {
//     GUI.skin = layout;
//     GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
//     GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

//     if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
//     {
//         PlayerScore1 = 0;
//         PlayerScore2 = 0;
//         theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
//     }
//     if (PlayerScore1 == 10)
//     {
//         GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
//         theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
//     } else if (PlayerScore2 == 10)
//     {
//         GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
//         theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
//     }
// }

 public string Cena2;


public GUISkin layout;              // Fonte do placar
GameObject theBall;

void ChangeScene()
    {
        // Verifica se o nome da próxima cena foi definido
        if (SceneManager.GetActiveScene().name == "Cena1")
        {
        if (!string.IsNullOrEmpty(Cena2))
        {
            SceneManager.LoadScene(Cena2);
        }
        }
        else if (SceneManager.GetActiveScene().name == "Cena2")
        {
        
            SceneManager.LoadScene("Win");
        
        }
        else
        {
            Debug.LogWarning("Nome da próxima cena não foi definido!");
        }
    }                 // Referência ao objeto bola

    void Start()
    {
        //theBall = GameObject.FindGameObjectWithTag("Ball"); // Busca a referência da bola
        //  if (SceneManager.GetActiveScene().name == "Start")
        // {
        //     // Invoke the scene change after 3 seconds
        //     Invoke("LoadNextScene", 3f);
        // }

    }

     void LoadNextScene()
    {
        SceneManager.LoadScene("Cena1");
    }

    void ResetScene()
    {
        SceneManager.LoadScene("Start");
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "Start" && Input.GetKeyDown(KeyCode.Space))
        {
    
            LoadNextScene();
        }

         if (GameObject.FindGameObjectsWithTag("Block").Length == 0)
        {
            ChangeScene();
        }

        if (SceneManager.GetActiveScene().name == "Win" && Input.GetKeyDown(KeyCode.Space))
        {
            ResetScene();
        }

        if (SceneManager.GetActiveScene().name == "Lose" && Input.GetKeyDown(KeyCode.Space))
        {
            ResetScene();
        }
        
    }
}
