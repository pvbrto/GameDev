using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Text healthText;


    public static int maxHealth;
    public static int currentHealth;
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
        healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }

}
