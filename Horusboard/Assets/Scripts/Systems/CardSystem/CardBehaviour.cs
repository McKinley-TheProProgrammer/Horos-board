using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] 
    private CardData cardData;
    public void SetCardData(CardData cardData)
    {
        this.cardData = cardData;

        cardBG.sprite = cardData.cardBackground;
        cardIcon.sprite = cardData.cardIcon;
        cardMiniDescriptionDisplay.text = cardData.miniDescription;
        cardFullDescriptionDisplay.text = cardData.cardDescription;
        
        Color bgColor = Color.gray;
        
        switch (cardData.cardType)
        {
            case CardType.WATER:
                bgColor = Color.blue;
                break;
            case CardType.EARTH:
                bgColor = new Color(1f, .6f, 0f);
                break;
            case CardType.FIRE:
                bgColor = Color.red;
                break;
            case CardType.AIR:
                bgColor = Color.cyan;
                break;
        }

        cardBG.color = bgColor;
    }
    
    [SerializeField]
    private RectTransform cardTransform;
    
    [Header("Card Image Displays")]
    [SerializeField] 
    private Image cardBG;
    [SerializeField]
    private Image cardIcon;
    
    
    [Header("Card Text Displays")]
    [SerializeField] 
    private RectTransform cardFullDescriptionBox;
    [SerializeField] 
    private RectTransform cardMiniDescriptionBox;
    
    [SerializeField] 
    private TextMeshProUGUI cardMiniDescriptionDisplay;
    [SerializeField] 
    private TextMeshProUGUI cardFullDescriptionDisplay;
    
    private Vector2 cardDescBox_Pos;
    
    public bool selected;
    
    
    void Start()
    {
        if (cardTransform == null)
            cardTransform = GetComponent<RectTransform>();

        cardDescBox_Pos = cardFullDescriptionBox.anchoredPosition;
        
        SetCardData(cardData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selected = !selected;

        if(selected)
            cardFullDescriptionBox.DOAnchorPosX(-cardTransform.sizeDelta.x, .2f).SetRelative(true);
        else
            cardFullDescriptionBox.DOAnchorPos(cardDescBox_Pos, .2f);
    }

    // Uses the Card
    public void Use()
    {
        
    }
    
    
}