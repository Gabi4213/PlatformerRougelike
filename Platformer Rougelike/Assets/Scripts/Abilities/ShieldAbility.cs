using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbility : AbilityBase
{
    public float sheildRange;
    public GameObject ShieldItem;

    private void Update()
    {
        if(currentCooldown >= 0)
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
        ShieldItem.SetActive(true);
        ShieldItem.GetComponent<CircleCollider2D>().radius = sheildRange;
        yield return new WaitForSeconds(useTime);
        currentCooldown = maxCooldwon;
        ShieldItem.SetActive(false);
        ShieldItem.GetComponent<CircleCollider2D>().radius = 0.0f;
        isUsing = false;
    }
}
