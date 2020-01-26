using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
public class UnitSelectorSpawnerConverter : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public GameObject prefab;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Entity selectorEntity = conversionSystem.GetPrimaryEntity(prefab);

        UnitSelectorTag selectorTag = new UnitSelectorTag { };
        dstManager.AddComponentData(selectorEntity, selectorTag);
        UnitSelectorSpawnerComponent spawnerComponent = new UnitSelectorSpawnerComponent { UnitSelectorPrefabEntity = selectorEntity};

        dstManager.AddComponentData(entity, spawnerComponent);
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(prefab);
    }
}
