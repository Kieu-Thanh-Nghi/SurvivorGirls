using UnityEngine;

public class AEMine : MonoBehaviour
{
    [SerializeField] ParticleSystem ShockWave;

    public void SetShockWaveScale(Vector3 theScale)
    {
        ShockWave.transform.localScale = theScale;
    }
    public void ActiveShockWave()
    {
        //ShockWave.Play();
    }
}
