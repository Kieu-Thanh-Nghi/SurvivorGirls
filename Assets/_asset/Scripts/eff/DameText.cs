using UnityEngine;
using TMPro;
using DG.Tweening;
using Lean.Pool;
public class DameText : MonoBehaviour
{
    [SerializeField] LeanGameObjectPool pool;
    [SerializeField] TMP_Text theText;
    Sequence effSequence;

    private void OnEnable()
    {
        DOTween.Sequence().Append(transform.DOScale(0.85f, 0.1f).SetLoops(2, LoopType.Yoyo))
            .Append(transform.DOLocalMoveY(transform.localPosition.y + 0.6f, 0.15f))
            .OnComplete(() => pool.Despawn(gameObject));
    }
    internal void SetPosition(Vector3 Pos)
    {
        transform.position = Pos;
    }

    internal void SetText(string DameNumber)
    {
        theText.text = DameNumber;
    }
    internal void SetColor(Color theColor)
    {
        theText.color = theColor;
    }

    private void OnDestroy()
    {
        effSequence.Kill();
    }
}