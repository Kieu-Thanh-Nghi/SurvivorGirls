using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class WarningPanel : MonoBehaviour
{
    [SerializeField] internal Image bossImage;
    [SerializeField] float panelRevealTime;
    [SerializeField] float endDelay = 1;
    [SerializeField] float firstPosX;
    [SerializeField] float lastPosX;

    internal void SetBossImage(Sprite bossSprite)
    {
        bossImage.sprite = bossSprite;
    }

    internal void Reveal(UnityAction DoWhenDoneReveal)
    {
        if(transform is RectTransform rectTransf)
        {
            var beginPos = transform.localPosition;
            beginPos.x = firstPosX;
            transform.localPosition = beginPos;
            gameObject.SetActive(true);
            DOTween.Sequence()
                .SetUpdate(true)
                .Append(rectTransf.DOAnchorPosX(lastPosX, panelRevealTime).SetEase(Ease.OutBack))
                .AppendInterval(endDelay)
                .OnComplete(() => AfterReveal(DoWhenDoneReveal));
        }
    }

    void AfterReveal(UnityAction DoWhenDoneReveal)
    {
        gameObject.SetActive(false);
        DoWhenDoneReveal?.Invoke();
    }
}

