using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBase : MonoBehaviour
{
    public float maxCooldwon;
    public float currentCooldown;
    public float useTime;
    public bool isUsing;

    public virtual void UseAction()
    {

    }

}
