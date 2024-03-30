using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardDeckBehaviour : MonoBehaviour
{
    public List<CardBehaviour> cards = new List<CardBehaviour>();

    public void FadeSelectionOutlines(int amount)
    {
        foreach (var card in cards)
        {
            card.selectedCardOutline.DOFade(amount,.2f);
        }
    }
    
    public void OnSelectionEnter(CardBehaviour card)
    {
        
    }

    public void OnSelectionExit(CardBehaviour card)
    {
        
    }

    public void Select(CardBehaviour card)
    {
        
    }
}
