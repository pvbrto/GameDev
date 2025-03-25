using UnityEngine;
using UnityEngine.SceneManagement;

public class Parallax : MonoBehaviour
{
    private float length;
    public float parallaxEffect;
    private ScoreManager scoreManager;



    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        // Automatically assign ScoreManager if it's null
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in scene!");
        }
    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * parallaxEffect;
        if (transform.position.x < -length)
        {
            transform.position = new Vector3(length, transform.position.y, transform.position.z);
        }


        if (scoreManager != null && scoreManager.GetScore() >= 200)
        {
            SceneManager.LoadScene("Win");
        }


        if (scoreManager != null && scoreManager.GetScore() >= 150)
        {
            SetParallaxEffect("Farback01_0", 1f);
            SetParallaxEffect("Farback02_0", 1f);
            SetParallaxEffect("Stars (1)", 0.5f);
            SetParallaxEffect("Stars (2)", 0.5f);
            SetEnemySpeed(5.0f);
            SetMissileSpeed(6.0f);
            return;
        }
        


        if (scoreManager != null && scoreManager.GetScore() >= 100)
        {
           
            SetParallaxEffect("Farback01_0", 0.5f);
            SetParallaxEffect("Farback02_0", 0.5f);
            SetParallaxEffect("Stars (1)", 0.25f);
            SetParallaxEffect("Stars (2)", 0.25f);
            SetEnemySpeed(2.0f);
            SetMissileSpeed(3.0f);
        }
    }

    void SetParallaxEffect(string objectName, float value)
    {
        GameObject obj = GameObject.Find(objectName);
        if (obj == null)
        {
           
            return;
        }

        Parallax parallax = obj.GetComponent<Parallax>();
        if (parallax != null)
        {
            parallax.parallaxEffect = value;
            
        }
        else
        {
            Debug.LogError("Parallax script not found on object: " + objectName);
        }
    }

    void SetEnemySpeed(float value)
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            enemy.speed = value;
        }
    }

    void SetMissileSpeed(float value)
    {
        Missile[] missiles = FindObjectsOfType<Missile>();  

        foreach (Missile missile in missiles)
        {
            missile.speed = value;
        }
    }
}