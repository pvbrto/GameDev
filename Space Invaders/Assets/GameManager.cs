using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "Lose")
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "Win")
        {
            SceneManager.LoadScene("SampleScene");
        }
        
        
    }
}
