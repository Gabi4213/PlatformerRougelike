using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBase : MonoBehaviour
{
    public float maxCooldown;
    public float currentCooldown;
    public float useTime;
    public bool isUsing = false;
    public bool isOnCooldown = false;

    public virtual void UseAction()
    {

    }

}
