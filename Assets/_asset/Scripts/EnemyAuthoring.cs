using UnityEngine;
using Unity.Entities;

public class EnemyAuthoring : MonoBehaviour
{
    
}

class EnemyBaker : Baker<EnemyAuthoring>
{
    public override void Bake(EnemyAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity, new EnemyComponent { });
    }
}

public struct EnemyComponent : IComponentData
{

}
