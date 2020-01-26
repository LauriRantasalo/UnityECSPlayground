using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class BallSpawnerSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, ref BallSpawnerData spawnerData) =>
        {
            for (int i = 0; i < spawnerData.NumOfBalls; i++)
            {
                float3 pos = new float3(UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(0, 100));
                float3 dir = new float3(UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(0, 100));
                Entity ballEntity = EntityManager.Instantiate(spawnerData.MovingBallEntity);

                EntityManager.SetComponentData(ballEntity, new Translation { Value = pos });
                EntityManager.AddComponentData(ballEntity, new BallTag { });
            }
            EntityManager.DestroyEntity(entity);
        });
    }
}
