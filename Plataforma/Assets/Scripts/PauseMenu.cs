using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] private AudioClip ClickSFX;
    [SerializeField] private GameObject firstSelected;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(firstSelected);
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        SoundController.FindSoundController().PlaySound(ClickSFX);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        SoundController.FindSoundController().PlaySound(ClickSFX);
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PauseGame()
    {
        SoundController.FindSoundController().PlaySound(ClickSFX);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        SoundController.FindSoundController().PlaySound(ClickSFX);
        Time.timeScale = 1f;
        GameIsPaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
