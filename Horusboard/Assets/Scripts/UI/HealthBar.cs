using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Used to display HealthBars*/
public class HealthBar : MonoBehaviour
{
    [SerializeField] 
    private UnitStatus status;
    
    [SerializeField] 
    private Image healthBar;

    public void UpdateHealthBar(int amount)
    {
        healthBar.fillAmount = 1.0f * amount / status.maxHP.Value;
    }

}
