using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    string enemyTag;

    private void Start()
    {
        enemyTag = GameID.enemyTag;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Transform colTransf = collision.transform;
        if (colTransf.CompareTag(enemyTag))
        {
            if(colTransf.TryGetComponent<ISetMovable>(out var SetMovable))
            {
                Debug.Log("ss");
                SetMovable.SetIsMove(false);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Transform colTransf = collision.transform;
        if (colTransf.CompareTag(enemyTag))
        {
            if (colTransf.TryGetComponent<ISetMovable>(out var SetMovable))
            {
                Debug.Log("out");
                SetMovable.SetIsMove(true);
            }
        }
    }
}

public interface ISetMovable
{
    void SetIsMove(bool isMove);
}

