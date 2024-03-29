using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitManager : MonoBehaviour
{
    [SerializeField] 
    private UnitStatus unitStatus;
    
    public void SetUnitStatus(UnitStatus unitStatus)
    {
        this.unitStatus = unitStatus;
    }
    
    [SerializeField]
    public List<CardData> cardsSelected;

    public UnityEvent<CardData> OnCardAdded;
    
    public void AddCard(CardData cardData)
    {
        cardsSelected.Add(cardData);
        
        OnCardAdded?.Invoke(cardData);
    }

    public void ClearDeck()
    {
        cardsSelected.Clear();
    }
    public void Attack(UnitManager targetUnit)
    {
        
    }

    public void Defend()
    {
        
    }

    public void Heal()
    {
        
    }
    
    public void Supreme()
    {
        
    }

    public bool actionExecuted;

}
