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

        cardNameDisplay.text = cardData.cardName;
        cardMiniDescriptionDisplay.text = cardData.miniDescription;
        cardFullDescriptionDisplay.text = cardData.cardDescription;
        
        /*Color bgColor = Color.gray;
        
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

        cardBG.color = bgColor;*/
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
    private RectTransform cardTextBG;
    private Vector2 cardTextBG_sizeDelta;
    
    [SerializeField] 
    private RectTransform cardMiniDescriptionBox;
    
    [SerializeField] 
    private TextMeshProUGUI cardNameDisplay;
    [SerializeField] 
    private TextMeshProUGUI cardMiniDescriptionDisplay;
    [SerializeField] 
    private TextMeshProUGUI cardFullDescriptionDisplay;
    
    private Vector2 cardDescBox_Pos;

    [SerializeField] 
    public Image selectedCardOutline;
    
    public bool selected;

    [SerializeField] 
    private Sound[] selectedSoundSFXs, unselectedSFXs;
    
    private UnitManager playerUnit;
    void Start()
    {
        playerUnit = GameObject.FindWithTag("Player").GetComponent<UnitManager>();
        
        if (cardTransform == null)
            cardTransform = GetComponent<RectTransform>();

        cardDescBox_Pos = cardFullDescriptionBox.anchoredPosition;
        cardTextBG = cardFullDescriptionBox.GetChild(0).GetComponent<RectTransform>();
        cardTextBG_sizeDelta = cardTextBG.sizeDelta;
        
        SetCardData(cardData);
    }

    public void ReturnCardBGToPosition()
    {
        cardFullDescriptionBox.DOAnchorPos(cardDescBox_Pos, .2f);
        cardTextBG.DOSizeDelta(cardTextBG_sizeDelta, .2f);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        selected = !selected;

        float xPositionToGo = cardTextBG.sizeDelta.x + 48f;
        if (selected)
        {
            cardFullDescriptionBox.DOAnchorPosX(-(200 + xPositionToGo), .2f).SetRelative(true);
            cardTextBG.DOSizeDelta(new Vector2(xPositionToGo, cardTextBG.sizeDelta.y), .2f);

            cardFullDescriptionDisplay.DOFade(1f, .2f);
            
            selectedCardOutline.DOFade(1, .2f);
            playerUnit.AddCard(cardData);
            
            foreach (var sound in selectedSoundSFXs)
            {
                AudioManager.Instance.Play(sound);
            }
        }
        else
        {
            ReturnCardBGToPosition();

            cardFullDescriptionDisplay.DOFade(0f, .2f);
            
            selectedCardOutline.DOFade(0, .2f);
            playerUnit.RemoveCard(cardData);
            
            foreach (var sound in unselectedSFXs)
            {
                AudioManager.Instance.Play(sound);
            }
            
        }

        
    }
    
}
