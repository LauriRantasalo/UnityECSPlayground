using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class RotatingCubeSpawner : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, ref RotatingCubeSpawnerData spawnerData) =>
        {
            for (int x = 0; x < spawnerData.NumXCubes; x++)
            {
                float posX = x - (spawnerData.NumXCubes / 2);
                for (int z = 0; z < spawnerData.NumZCubes; z++)
                {
                    float posZ = z - (spawnerData.NumZCubes / 2);
                    var rotatingCubeEntity = EntityManager.Instantiate(spawnerData.RotatingCubePrefabEntity);

                    EntityManager.SetComponentData(rotatingCubeEntity, new Translation { Value = new float3(posX, 0, posZ) });
                    EntityManager.AddComponentData(rotatingCubeEntity, new RotationSpeed { Value = spawnerData.RotationSpeed });
                }
            }
            EntityManager.DestroyEntity(entity);
        });
    }
}
