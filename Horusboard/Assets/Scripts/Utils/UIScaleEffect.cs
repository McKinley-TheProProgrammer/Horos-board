using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIScaleEffect : MonoBehaviour
{
    [SerializeField]
    private RectTransform transformToScale;
    
    [SerializeField]
    private float scaleAmount = 1.1f, duration = .2f;

    public bool loopBack;
    
    private Sequence scaleSequence = null;

    public void Scale()
    {
        if (scaleSequence != null && scaleSequence.IsPlaying())
        {
            return;
        }

        scaleSequence = DOTween.Sequence();

        scaleSequence.Append(transformToScale.DOScale(scaleAmount, duration)).SetUpdate(isIndependentUpdate:true);
        if (loopBack)
            scaleSequence.SetLoops(2, LoopType.Yoyo);
        
        scaleSequence?.Play();
    }

    public void Scale(int amount)
    {
        if (scaleSequence != null && scaleSequence.IsPlaying())
        {
            return;
        }

        scaleSequence = DOTween.Sequence();

        scaleSequence.Append(transformToScale.DOScale(amount, duration)).SetUpdate(isIndependentUpdate:true);
        if (loopBack)
            scaleSequence.SetLoops(2, LoopType.Yoyo);
        
        scaleSequence?.Play();
    }
}
