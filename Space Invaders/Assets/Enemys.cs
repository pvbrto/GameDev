using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemys : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Type1").Length == 0 && GameObject.FindGameObjectsWithTag("Type2").Length == 0 && GameObject.FindGameObjectsWithTag("Type3").Length == 0 && GameObject.FindGameObjectsWithTag("Type4").Length == 0)
        {
            SceneManager.LoadScene("Win");
        }


    }
}
