using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAbility : AbilityBase
{
    public float HealthIncreaseAmount;
    public PlayerHealth PlayerHealth;

    private void Update()
    {
        if (currentCooldown >= 0)
        {
            currentCooldown -= Time.deltaTime;
            isOnCooldown = true;
        }
        else
        {
            isOnCooldown = false;
        }
    }

    public override void UseAction()
    {
        if (CanUse())
        {
            StartCoroutine(UseHeal());
        }
    }

    public bool CanUse()
    {
        return !isUsing && currentCooldown <= 0 && PlayerHealth.CurrentHealth < PlayerHealth.MaxHealth;
    }

    IEnumerator UseHeal()
    {
        isUsing = true;
        PlayerHealth.ChangeHealth(HealthIncreaseAmount);
        yield return new WaitForSeconds(useTime);
        currentCooldown = maxCooldown;
        isUsing = false;
    }
}
