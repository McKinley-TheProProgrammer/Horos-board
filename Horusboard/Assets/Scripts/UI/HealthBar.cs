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

    public void UpdateHealthBar(int health)
    {
        healthBar.fillAmount = 1.0f * health / status.maxHP.Value;
    }

}
