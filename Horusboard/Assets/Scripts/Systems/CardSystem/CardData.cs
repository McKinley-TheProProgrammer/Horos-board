using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public enum CardType
{
    WATER,
    EARTH,
    FIRE,
    AIR
}

public enum SignType
{
    
}
[CreateAssetMenu(menuName = "Card")]
public class CardData : ScriptableObject
{
    public string cardName;
    
    public Sprite cardIcon;
    public Sprite cardBackground;

    public string miniDescription;
    [TextArea]
    public string cardDescription;
    
    [Header("Damage Properties")] 
    public int damageBuff; // Buffs user's Attack (Prioritizes User)
    public int damageDebuff;
    
    [Header("Defense Properties")]
    public int defenseBuff; // Buffs user's Defense (Prioritizes User)
    public int defenseDebuff; // Lowers Defense

    [Header("Healing Properties")] 
    public int cureBuff;
    public int cureDebuff;

    [Header("Supreme Gauge Properties")]
    public int supremeBuff;
    public int supremeDebuff;

    [SerializeField] 
    public bool useBuff;
    [SerializeField] 
    public bool useDebuff;
    
    [SerializeField] 
    public CardType cardType;

    //[SerializeField]
    //public SignType signType;

}
