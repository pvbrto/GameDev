using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb2d;         
    
    void GoBall(){                      
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(15, -20));
        } else {
            rb2d.AddForce(new Vector2(-15, -20));
        }
    }

    void OnCollisionEnter2D (Collision2D coll) {
        
        Vector2 vel;
            vel.x = rb2d.linearVelocity.x;
            vel.y = rb2d.linearVelocity.y;
            rb2d.linearVelocity = vel;
        
        if(coll.collider.CompareTag("Player")){
            
            
        }
        else if(coll.collider.CompareTag("Block")){  
            Destroy(coll.gameObject);
    
        }
        else if(coll.collider.CompareTag("Lose")){
            SceneManager.LoadScene("Lose");
        }
    }


    void ResetBall(){
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetBall();
        Invoke("GoBall", 1);
    }

      // Define o corpo rigido 2D que representa a bola

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        Invoke("GoBall", 1);    // Chama a função GoBall após 2 segundos

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
