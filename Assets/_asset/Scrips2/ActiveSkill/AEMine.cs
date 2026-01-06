using UnityEngine;
using Lean.Pool;

public class AEMine : MonoBehaviour
{
    [SerializeField] ParticleSystem ShockWave;
    [SerializeField] EMineColl eMineColl;

    public void SetElecPool(LeanGameObjectPool elecPool)
    {
        eMineColl.electricPool = elecPool;
    }
    public void SetShockWaveScale(Vector3 theScale)
    {
        ShockWave.transform.localScale = theScale;
    }
    public void ActiveShockWave()
    {
        //ShockWave.Play();
    }
}
