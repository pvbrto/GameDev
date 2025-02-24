using UnityEngine;

public class BallControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb2d;
    private AudioSource audioSource;

    public AudioClip collisionSound; // Assign this in the Inspector

    public float forceMultiplier = 5f;
    public float drag = 0.6f;
    public float speedBoostFactor = 1f;
    public float maxSpeed = 15f;

    private Vector2 currentVelocity;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component

        if (audioSource == null)
        {
            Debug.LogWarning("No AudioSource found! Please add one to the GameObject.");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 collisionNormal = coll.contacts[0].normal;

        if (coll.collider.CompareTag("Player") || coll.collider.CompareTag("Wall"))
        {
            PlayCollisionSound();

            if (coll.collider.CompareTag("Player"))
            {
                Vector2 relativeVelocity = coll.relativeVelocity;
                float impactStrength = relativeVelocity.magnitude;

                float finalForce = forceMultiplier + impactStrength;
                if (finalForce > maxSpeed)
                {
                    finalForce = maxSpeed;
                }

                Vector2 force = -collisionNormal * finalForce;
                rb2d.AddForce(force, ForceMode2D.Impulse);
                currentVelocity = -rb2d.linearVelocity;
            }
            else if (coll.collider.CompareTag("Wall"))
            {
                currentVelocity = rb2d.linearVelocity;
            }
        }
    }

    void PlayCollisionSound()
    {
        if (audioSource != null && collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }


    void FixedUpdate() {
        if (rb2d.linearVelocity.magnitude > 0.1f) { // Evita que o objeto oscile ao redor de 0
            currentVelocity *= (1 - drag * Time.fixedDeltaTime);
            rb2d.linearVelocity = currentVelocity;
        } else {
            rb2d.linearVelocity = Vector2.zero; // Para completamente se a velocidade for muito baixa
        }
    }

    void ResetBall(){
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetBall();
        //Invoke("GoBall", 1);
    }

      // Define o corpo rigido 2D que representa a bola

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
