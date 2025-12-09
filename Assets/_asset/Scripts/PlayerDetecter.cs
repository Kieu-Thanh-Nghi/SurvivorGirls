using UnityEngine;

public class PlayerDetecter : MonoBehaviour
{
    internal Transform PlayerPos;

    private void Start()
    {
        PlayerPos = GamePlayCtrler.Instance.Player;
    }
    public Vector3 DirectToPlayer()
    {
        return PlayerPos.position - transform.position;
    }
}
