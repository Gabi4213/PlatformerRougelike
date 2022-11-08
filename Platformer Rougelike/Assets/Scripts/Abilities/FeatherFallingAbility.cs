using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherFallingAbility : AbilityBase
{
    public PlayerMovement playerMov;
    public PlayerData normalPlayerData, abilityPlayerData;

    private void Update()
    {
        if (currentCooldown >= 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    public override void UseAction()
    {
        if (CanUse())
        {
            StartCoroutine(UseShield());
        }
    }

    public bool CanUse()
    {
        return !isUsing && currentCooldown <= 0;
    }

    IEnumerator UseShield()
    {
        isUsing = true;
        playerMov.Data = abilityPlayerData;
        yield return new WaitForSeconds(useTime);
        currentCooldown = maxCooldwon;
        playerMov.Data = normalPlayerData;
        isUsing = false;
    }

}
