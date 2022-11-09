using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityController : MonoBehaviour
{
    public AbilityBase[] abilities;
    public Image[] abilityCooldownImg;
    public TextMeshProUGUI[] abilityText;
    public float[] abilityTextTimer;
    public AbilityBase[] allAbilities;
    public Animator[] abilityAnim;

    private void Start()
    {
        abilityText[0].text = "";
        abilityText[1].text = "";
        abilityText[2].text = "";
    }

    public void Update()
    {
        #region Ability Checks
        //Ability 1
        if (abilities[0].isOnCooldown)
        {
            abilityTextTimer[0] -= Time.deltaTime;
            abilityCooldownImg[0].fillAmount = 1;
            abilityText[0].text = abilityTextTimer[0].ToString("F0");
        }
        else
        {
            if(abilityText[0].text != "")
            {
                ResetAbility(0,abilityTextTimer[0], abilityText[0], abilityCooldownImg[0]);
            }
        }

        //Ability 2
        if (abilities[1].isOnCooldown)
        {
            abilityTextTimer[1] -= Time.deltaTime;
            abilityCooldownImg[1].fillAmount = 1;
            abilityText[1].text = abilityTextTimer[1].ToString("F0");
        }
        else
        {
            if (abilityText[1].text != "")
            {
                ResetAbility(1,abilityTextTimer[1], abilityText[1], abilityCooldownImg[1]);
            }
        }

        //Ability 3
        if (abilities[2].isOnCooldown)
        {
            abilityTextTimer[2] -= Time.deltaTime;
            abilityCooldownImg[2].fillAmount = 1;
            abilityText[2].text = abilityTextTimer[2].ToString("F0");
        }
        else
        {
            if (abilityText[2].text != "")
            {
                ResetAbility(2,abilityTextTimer[2], abilityText[2], abilityCooldownImg[2]);
            }
        }
        #endregion

        #region Ability Inputs
        //Ability One
        if (Input.GetKeyDown(KeyCode.Q) && !abilities[0].isOnCooldown)
        {
            abilities[0].UseAction();
            abilityTextTimer[0] = abilities[0].maxCooldown;
        }
        //Ability Two
        if (Input.GetKeyDown(KeyCode.E) && !abilities[1].isOnCooldown)
        {
            abilities[1].UseAction();
            abilityTextTimer[1] = abilities[1].maxCooldown;
        }
        //Ability Three
        if (Input.GetKeyDown(KeyCode.R) && !abilities[2].isOnCooldown)
        {
            abilities[2].UseAction();
            abilityTextTimer[2] = abilities[2].maxCooldown;
        }
        #endregion
    }

    public void ResetAbility(int index, float abilityTimer, TextMeshProUGUI abilityText, Image abilityImage)
    {
        abilityTimer = 0;
        abilityText.text = "";
        abilityImage.fillAmount = 0;
        abilityAnim[index].SetTrigger("AbilityAvaliable");
    }



}