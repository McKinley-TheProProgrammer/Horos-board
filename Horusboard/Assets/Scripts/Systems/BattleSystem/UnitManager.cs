using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private UnitStatus unitStatus;

    public void SetUnitStatus(UnitStatus unitStatus)
    {
        this.unitStatus = unitStatus;
        currentHP.Value = unitStatus.maxHP;
        currentDamage = unitStatus.damage;
        currentDefense = unitStatus.defense;
    }

    [SerializeField] public List<CardData> cardsSelected;

    public UnityEvent<int> OnDamageTaken;

    public UnityEvent<UnitManager> OnAttack, OnDefense;

    public UnityEvent<CardData> OnCardAdded;

    [SerializeField] private IntVariable currentHP;
    private int currentDamage;
    private float currentDefense;

    public BoolReference isDead;

    private void Start()
    {
        SetUnitStatus(unitStatus);
    }

    public void AddCard(CardData cardData)
    {
        if (cardsSelected.Contains(cardData))
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

        float damageAmount = currentDamage;
        float enemyDamageLoss = targetUnit.unitStatus.damage;
        //buffing the defense
        foreach (var cardData in cardsSelected)
        {
            if (cardData.useBuff)
            {
                damageAmount += cardData.damageBuff;
            }
            else if (cardData.useDebuff)
            {
                enemyDamageLoss -= cardData.damageDebuff;
            }
            else
            {
                damageAmount *= 2;
                enemyDamageLoss *= 2;
            }
        }

        currentDamage = (int)damageAmount;

        targetUnit.TakeDamage(Mathf.RoundToInt(damageAmount));

        targetUnit.LoseDamage(Mathf.RoundToInt(enemyDamageLoss));

        OnAttack?.Invoke(targetUnit);
    }

    public void Defend(UnitManager defendingFrom)
    {
        Debug.Log($"Unit {gameObject.name} is Defending");

        float defenseAmount = currentDefense;
        float defenseLost = defendingFrom.unitStatus.defense;

        foreach (var cardData in cardsSelected)
        {
            if (cardData.useBuff)
            {
                defenseAmount += cardData.damageBuff;
            }
            else if (cardData.useDebuff)
            {
                defenseLost -= cardData.damageDebuff;
            }
            else
            {
                defenseAmount += cardData.supremeBuff;
                defenseLost -= cardData.supremeDebuff;
            }
        }

        currentDefense += defenseAmount;
        
        defendingFrom.LoseDefense(Mathf.RoundToInt(defenseLost));
        
        OnDefense?.Invoke(this);
    }

    public void Heal()
    {

    }

    public void Supreme()
    {

    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHP.Value <= 0)
        {
            return;
        }

        currentHP.Value -= damageAmount;

        if (currentHP.Value <= 0)
        {
            Debug.Log($"{gameObject.name} is DEAD");
            isDead.Value = true;
        }

        OnDamageTaken?.Invoke(damageAmount);
    }

    public void AddDamage(int damage)
    {
        if(currentDamage >= 10)
            return;
        
        currentDamage += damage;
    }

    public void AddDefense(int defense)
    {
        if (currentDefense >= 10)
        {
            return;
        }

        currentDefense += defense;
    }
    public void LoseDamage(int damageAmount)
    {
        if (currentDamage <= 2)
        {
            return;
        }

        currentDamage -= damageAmount;
    }

    public void LoseDefense(int defenseAmount)
    {
        if (currentDefense <= 2)
        {
            return;
        }

        currentDefense -= defenseAmount;
    }

    public void RegainAttack()
    {
        currentDamage = unitStatus.damage;
    }
    public void RegainDefense()
    {
        currentDefense = unitStatus.defense;
    }

}
