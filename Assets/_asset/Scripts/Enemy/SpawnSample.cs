using UnityEngine;
using UnityEditor;

public class SpawnSample : ChangePosSpawnSample
{
    [SerializeField] float SpawnSampleRadius = 10;
    [SerializeField] float bonusRudius = 5;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1);
        Handles.color = new Color(0, 0, 1, 0.1f);
        Handles.DrawSolidDisc(transform.position, transform.up, SpawnSampleRadius);
    }
#endif

    protected override Quaternion GetSampleRotation(Vector3 SampleFinalPos)
    {
        Vector3 SampleLookToPos = transform.position;
        Vector3 sampleForward =SampleLookToPos - SampleFinalPos;
        sampleForward.y = 0;
        return Quaternion.LookRotation(sampleForward);
    }

    protected override Vector3 GetSpawnSamplePosition()
    {
        float x = transform.forward.x;
        float z = transform.forward.z;
        float finalRadius = SpawnSampleRadius + UnityEngine.Random.Range(0, bonusRudius + 1);
        Vector3 finalPos = new Vector3(x * finalRadius, -1, z * finalRadius) + transform.position;

        return finalPos;
    }
}
