using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

public class UnitManager : MonoBehaviour
{
    [SerializeField] 
    private UnitStatus unitStatus;

    public void SetUnitStatus(UnitStatus unitStatus)
    {
        this.unitStatus = unitStatus;
        currentHP = unitStatus.maxHP;
    }
    
    [SerializeField]
    public List<CardData> cardsSelected;

    public UnityEvent OnAttack, OnDefense;
    
    public UnityEvent<CardData> OnCardAdded;
    
    private int currentHP;

    public BoolReference isDead;
    private void Start()
    {
        currentHP = unitStatus.maxHP.Value;
    }

    public void AddCard(CardData cardData)
    {
        if(cardsSelected.Contains(cardData))
            return;
        
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
        
        targetUnit.TakeDamage(unitStatus.damage);
        //Will be removed
        targetUnit.transform.DOPunchScale(Vector3.one * 1.1f, .4f);
        
        OnAttack?.Invoke();
    }

    public void Defend()
    {
        Debug.Log($"Unit {gameObject.name} is Defending");
        OnDefense?.Invoke();
    }

    public void Heal()
    {
        
    }
    
    public void Supreme()
    {
        
    }
    
    public void TakeDamage(int damageAmount)
    {
        if (currentHP <= 0)
        {
            return;
        }
        
        currentHP -= damageAmount;
        if (currentHP <= 0)
        {
            Debug.Log($"{gameObject.name} is DEAD");
            isDead.Value = true;
        }
    }

}
