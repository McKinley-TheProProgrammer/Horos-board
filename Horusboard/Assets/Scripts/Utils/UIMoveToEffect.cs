using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIMoveToEffect : MonoBehaviour
{
    [SerializeField]
    private RectTransform transformToMove;

    [SerializeField] 
    private Vector2 posToMove;

    [SerializeField] 
    private float duration = .25f;
    
    private Sequence scaleSequence = null;

    private Vector2 startPos;

    private void Start()
    {
        startPos = transformToMove.position;
    }

    public void Move()
    {
        if (scaleSequence != null && scaleSequence.IsActive())
        {
            return;
        }

        scaleSequence = DOTween.Sequence();

        scaleSequence.Append(transformToMove.DOAnchorPos(posToMove, duration)).SetUpdate(isIndependentUpdate:true);

        scaleSequence.Play().SetUpdate(true);
    }

    public void MoveBack()
    {
        if (scaleSequence != null && scaleSequence.IsActive())
        {
            return;
        }

        scaleSequence = DOTween.Sequence();

        scaleSequence.Append(transformToMove.DOAnchorPos(startPos,duration)).SetUpdate(isIndependentUpdate:true);

        scaleSequence.Play().SetUpdate(true);
    }
    
    public void MoveToCenter()
    {
        if (scaleSequence != null && scaleSequence.IsActive())
        {
            return;
        }

        scaleSequence = DOTween.Sequence();

        scaleSequence.Append(transformToMove.DOAnchorPos(Vector2.zero, duration)).SetUpdate(isIndependentUpdate:true);

        scaleSequence.Play().SetUpdate(true);
    }
}
