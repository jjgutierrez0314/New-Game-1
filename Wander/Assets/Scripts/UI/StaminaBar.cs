using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxStamina(int stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
    }

    public void SetStamina(int stamina)
    {
        slider.value = stamina;
    }

    // public IEnumerator RegenStamina(int currentStamina, int maxStamina)
    // {
    //     int newStam = currentStamina;

    //     yield return new WaitForSeconds(2);

    //     while (currentStamina < maxStamina)
    //     {
    //         currentStamina += maxStamina / 400;
    //         slider.value = currentStamina;
    //         yield return regenTick;
    //     }
    // }
}