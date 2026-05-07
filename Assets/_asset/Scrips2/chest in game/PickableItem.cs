using UnityEngine;
using UnityEngine.Events;

public class PickableItem : MonoBehaviour
{
    [SerializeField] UnityEvent<Collider> OnPickedUp;
    public void SpawnThisOut()
    {
        var theLand = GamePlayCtrler.Instance.mapManager.GetSquareOfAPosion(transform.position);
        var clone = Instantiate(gameObject, theLand, true);
        clone.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        OnPickedUp?.Invoke(other);
        Destroy(gameObject);
    }
}
