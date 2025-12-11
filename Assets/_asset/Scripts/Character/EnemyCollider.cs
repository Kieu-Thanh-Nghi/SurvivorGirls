using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField] Enemy theSelf;
    internal bool isCheck;
    private void OnCollisionExit(Collision collision)
    {
        if (isCheck && (collision.transform.CompareTag("enemy") || collision.transform.CompareTag("Player")))
        {
            theSelf.isRayCheck = true;
            isCheck = false;
        }
    }
}