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

    public void RemoveCard(CardData cardData)
    {
        if (!cardsSelected.Contains(cardData))
        {
            Debug.LogError($"Card {cardData.name} not found");
            return;
        }

        cardsSelected.Remove(cardData);
    }

    public void ClearDeck()
    {
        cardsSelected.Clear();
    }
    public void Attack(UnitManager targetUnit)
    {
        Debug.Log($"Unit {gameObject.name} is Attacking");
    }

    public void Defend()
    {
        Debug.Log($"Unit {gameObject.name} is Defending");
    }

    public void Heal()
    {
        
    }
    
    public void Supreme()
    {
        
    }

    public bool actionExecuted;

}
