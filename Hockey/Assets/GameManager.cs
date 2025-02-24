using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static int PlayerScore1 = 0; // Pontuação do player 1
public static int PlayerScore2 = 0; // Pontuação do player 2

public static void Score (string wallID) {
    if (wallID == "TopTrigger")
    {
        PlayerScore1++;
    } else
    {
        PlayerScore2++;
    }
}

void OnGUI () {
    GUI.color = Color.black; // Define a cor do texto como preto
    GUI.skin = layout;
    
    GUI.Label(new Rect(Screen.width / 2 - 150 - 15, 20, 100, 100), "" + PlayerScore1);
    GUI.Label(new Rect(Screen.width / 2 + 150 - 15, 20, 100, 100), "" + PlayerScore2);

    if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
    {
        PlayerScore1 = 0;
        PlayerScore2 = 0;
        theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
    }

    if (PlayerScore1 == 10)
    {
        GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER WIN");
        theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
    }
    else if (PlayerScore2 == 10)
    {
        GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "BOT WIN");
        theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
    }
}


public GUISkin layout;              // Fonte do placar
GameObject theBall;                 // Referência ao objeto bola

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball"); // Busca a referência da bola

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
