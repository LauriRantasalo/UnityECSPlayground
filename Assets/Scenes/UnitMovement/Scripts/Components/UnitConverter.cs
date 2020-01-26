using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class UnitConverter : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        PlayerInputComponent inputComponent = new PlayerInputComponent { };
        NavAgentComponent navAgentComponent = new NavAgentComponent { };
        dstManager.AddComponentData(entity, inputComponent);
        dstManager.AddComponentData(entity, navAgentComponent);
    }

}
