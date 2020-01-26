using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
public class UnitSpawnerConverter : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public GameObject unitPrefab;
    public int NumOfUnitsX;
    public int NumOfUnitsZ;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Entity ent = conversionSystem.GetPrimaryEntity(unitPrefab);
        UnitSpawnerComponent spawnerComponent = new UnitSpawnerComponent
        {
            NumOfUnitsX = NumOfUnitsX,
            NumOfUnitsZ = NumOfUnitsZ,
            UnitEntity = ent,
        };
        dstManager.AddComponentData(entity, spawnerComponent);
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(unitPrefab);
    }

}
