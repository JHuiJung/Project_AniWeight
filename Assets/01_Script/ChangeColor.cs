using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangeColor : MonoBehaviour
{
    
    public List<SpriteRenderer> renderers;

    public void ChangeAlpha(float amount)
    {
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.DOFade(amount, 0.1f);
        }
    }
}
