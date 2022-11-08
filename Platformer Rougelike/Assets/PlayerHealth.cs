using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float CurrentHealth, MaxHealth;
    public TextMeshProUGUI HealthText;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        HealthText.text = CurrentHealth.ToString();
    }

    public void ChangeHealth(float amount)
    {
        CurrentHealth += amount;
        HealthText.text = CurrentHealth.ToString();
    }
}
