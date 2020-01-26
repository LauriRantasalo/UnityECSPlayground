using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class BallSpawnerConverter : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    [SerializeField] private int NumOfBalls;
    [SerializeField] private float BallMovementSpeed;
    [SerializeField] private GameObject MovinBallPrefab;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Entity ballEntity = conversionSystem.GetPrimaryEntity(MovinBallPrefab);

        BallSpawnerData ballSpawnerData = new BallSpawnerData
        {
            NumOfBalls = NumOfBalls,
            SpeedOfBalls = BallMovementSpeed,
            MovingBallEntity = ballEntity,
        };
        dstManager.AddComponentData(entity, ballSpawnerData);
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(MovinBallPrefab);
    }
}
