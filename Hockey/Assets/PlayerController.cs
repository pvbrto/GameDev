using UnityEngine;

public class PlayerController : MonoBehaviour
{
     private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public float minX = -7f, maxX = 7f;  // Horizontal limits (adjust to match wall positions)
    public float minY = -4f, maxY = 4f;  // Vertical limits

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = transform.position;

        // Move the player to the mouse position
        pos.x = Mathf.Clamp(mousePos.x, minX, maxX);
        pos.y = Mathf.Clamp(mousePos.y, minY, maxY);

        // Apply the new position
        transform.position = pos;
    }
}
