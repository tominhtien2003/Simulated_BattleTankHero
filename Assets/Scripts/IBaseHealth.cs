using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class IBaseHealth : MonoBehaviour
{
    public event EventHandler OnDeath;

    public float totalHealth;
    public Image healthBar;


    private float currentHealth;
    private void Start()
    {
        currentHealth = totalHealth;
    }
    public void TakeDamage(float damage)
    {
        if (currentHealth > damage)
        {
            currentHealth -= damage;

            healthBar.fillAmount -= damage / totalHealth;
        }
        else
        {
            healthBar.fillAmount = 0;

            currentHealth = 0;

            Death();
        }
    }
    private void Death()
    {
        OnDeath?.Invoke(this, EventArgs.Empty);

        Destroy(gameObject);
    }
    private void LateUpdate()
    {
        healthBar.transform.forward = -Camera.main.transform.forward;
    }
}
