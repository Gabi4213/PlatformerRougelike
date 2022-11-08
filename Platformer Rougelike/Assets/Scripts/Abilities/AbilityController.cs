using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour
{
    public AbilityBase abilityOne, abilityTwo, abilityThree;
    public Image aOneCooldownImg, aTwoCooldownImg, aThreeCooldownImg;
    public AbilityBase[] allAbilities;
    bool abilityOneUsed, abilityTwoUsed, abilityThreeUsed;


    public void Update()
    {
        if(aOneCooldownImg.fillAmount > 0 && abilityOneUsed)
        {
            aOneCooldownImg.fillAmount -= 1 / (abilityOne.maxCooldwon + abilityOne.useTime) * Time.deltaTime;
        }
        if (aTwoCooldownImg.fillAmount > 0 && abilityTwoUsed)
        {
            aTwoCooldownImg.fillAmount -= 1 / (abilityTwo.maxCooldwon + abilityTwo.useTime) * Time.deltaTime;
        }
        if (aThreeCooldownImg.fillAmount > 0 && abilityThreeUsed)
        {
            aThreeCooldownImg.fillAmount -= 1 / (abilityThree.maxCooldwon + abilityThree.useTime) * Time.deltaTime;
        }


        //Ability One
        if (Input.GetKeyDown(KeyCode.Q))
        {
            abilityOne.UseAction();
            aOneCooldownImg.fillAmount = 1;
            abilityOneUsed = true;
        }

        //Ability Two
        if (Input.GetKeyDown(KeyCode.E))
        {
            abilityTwo.UseAction();
            aTwoCooldownImg.fillAmount = 1;
            abilityOneUsed = true;
        }

        //Ability Three
        if (Input.GetMouseButtonDown(1))
        {
            abilityThree.UseAction();
            aThreeCooldownImg.fillAmount = 1;
            abilityOneUsed = true;
        }
    }
}
