using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHP : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    [Header("Health Bar")]
    public gameOverScreen GameOverScreen;
    private float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image FrontHP;
    public Image BackHP;
    [Header("Damage Overlay")]
    public Image overlay; // damage overlay object
    public float duration; // duration of the overlay
    public float fadeSpeed; // how quickly the image will fade

    private float durationTimer; // timer to check the duration
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);

    }
    public void GameOver()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if(overlay.color.a > 0)
        {
            if (health <= 0)
                SceneManager.LoadScene("GameOver");
            if (health < 30)
                return;
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                // fade the overlay
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }
    public void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillF = FrontHP.fillAmount;
        float fillB = BackHP.fillAmount;
        float hFraction = health / maxHealth;
        if(fillB > hFraction)
        {
            FrontHP.fillAmount = hFraction;
            BackHP.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            BackHP.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if(fillF < hFraction)
        {
            BackHP.color = Color.green;
            BackHP.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            FrontHP.fillAmount = Mathf.Lerp(fillF, BackHP.fillAmount, percentComplete);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }
}
