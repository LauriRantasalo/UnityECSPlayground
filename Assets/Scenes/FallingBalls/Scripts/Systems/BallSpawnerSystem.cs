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
        // Finds all of the Entities with component BallSpawnerData (there is only one).
        // Then spawns balls at random locations according to data from the BallSpawnerData component.
        Entities.ForEach((Entity entity, ref BallSpawnerData spawnerData) =>
        {
            for (int i = 0; i < spawnerData.NumOfBalls; i++)
            {
                // Sets a random position in a 100 * 100 * 100 cube.
                float3 pos = new float3(UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(0, 100));
                // Gets the entity from the BallSpawnerData component. The entity was made from a prefab within the BallSpawnerConverter class.
                Entity ballEntity = EntityManager.Instantiate(spawnerData.MovingBallEntity);

                // Sets the balls position to the position specified above.
                EntityManager.SetComponentData(ballEntity, new Translation { Value = pos });
                // Adds a BallTag component just so we can find all balls easily. The BallTag component does not hold any data.
                EntityManager.AddComponentData(ballEntity, new BallTag { });
            }
            // Destroys the spawner entity when a desired number of balls has spawned.
            EntityManager.DestroyEntity(entity);
        });
    }
}
