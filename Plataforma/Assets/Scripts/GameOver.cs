using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public static bool PlayerIsDead = false;
    public GameObject gameOverMenuUI;
    [SerializeField] private AudioClip ClickSFX;
    [SerializeField] private GameObject firstSelected;
    private bool firstSelectedCheck = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerIsDead)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PlayerIsDead = true;
        if(firstSelectedCheck == false)
        {
            EventSystem.current.SetSelectedGameObject(firstSelected);
            firstSelectedCheck = true;
        }
    }

    public void RestartGame()
    {
        SoundController.FindSoundController().PlaySound(ClickSFX);
        Time.timeScale = 1f;
        PlayerIsDead = false;
        //Restart the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SoundController.FindSoundController().PlaySound(ClickSFX);
        Time.timeScale = 1f;
        PlayerIsDead = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        SoundController.FindSoundController().PlaySound(ClickSFX);
        Debug.Log("Quit");
        Application.Quit();
    }
}
