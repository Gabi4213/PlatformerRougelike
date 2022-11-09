using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : AbilityBase
{
    public PlayerMovement playerMov;

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
            StartCoroutine(UseDash());
        }
    }

    public bool CanUse()
    {
        return !isUsing && currentCooldown <= 0 && playerMov.CanDash();
    }

    IEnumerator UseDash()
    {
        playerMov.OnDashInput();
        isUsing = true;
        yield return new WaitForSeconds(useTime);
        currentCooldown = maxCooldown;
        isUsing = false;
    }
}
