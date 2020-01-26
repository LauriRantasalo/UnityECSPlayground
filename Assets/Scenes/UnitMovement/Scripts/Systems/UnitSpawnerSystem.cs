using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class UnitSpawnerSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, ref UnitSpawnerComponent spawner) => {
            for (int x = 0; x < spawner.NumOfUnitsX; x++)
            {
                for (int z = 0; z < spawner.NumOfUnitsZ; z++)
                {
                    Entity ent = EntityManager.Instantiate(spawner.UnitEntity);
                    EntityManager.SetComponentData(ent, new Translation { Value = new float3(x * 4, 2, z * 4) });
                }
            }
            EntityManager.DestroyEntity(entity);
        });
    }
}
