using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class RotatingCubeSpawnerConverter : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    [SerializeField] private int NumXCubes;
    [SerializeField] private int NumZCubes;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private GameObject RotatingCubePrefab;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Entity rotatingCubePrefabEntity = conversionSystem.GetPrimaryEntity(RotatingCubePrefab);

        var cubeSpawnerData = new RotatingCubeSpawnerData
        {
            NumXCubes = NumXCubes,
            NumZCubes = NumZCubes,
            RotationSpeed = math.radians(RotationSpeed),
            RotatingCubePrefabEntity = rotatingCubePrefabEntity,
        };
        dstManager.AddComponentData(entity, cubeSpawnerData);
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(RotatingCubePrefab);
    }
}
