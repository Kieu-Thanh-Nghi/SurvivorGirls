using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ExpDetecter : MonoBehaviour
{
    [SerializeField] ParticleSystem[] expAttracter;
    EmitParams emitParams = new EmitParams();
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IExpType>(out var expType)){
            //other.gameObject.SetActive(false);
            int type = expType.GetType();
            emitParams.position = expAttracter[type].transform.InverseTransformPoint(other.transform.position);
            expAttracter[type].Emit(emitParams, 1);
        }
    }
}
