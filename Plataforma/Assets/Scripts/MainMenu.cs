using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstSelected;
    [SerializeField] private AudioClip ClickSFX;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public void PlayGame()
    {
        SoundController.FindSoundController().PlaySound(ClickSFX);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        SoundController.FindSoundController().PlaySound(ClickSFX);
        Debug.Log("Quit");
        Application.Quit();
    }
}
