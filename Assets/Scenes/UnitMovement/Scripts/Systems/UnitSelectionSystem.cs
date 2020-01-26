using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class UnitSelectionSystem : ComponentSystem
{


    
    private float3 startPos = new float3();
    protected override void OnUpdate()
    {
        EntityQuery m_Group = GetEntityQuery(ComponentType.ReadOnly<UnitSelectorSpawnerComponent>());
        NativeArray<Entity> unitSelectorSpawner = m_Group.ToEntityArray(Allocator.TempJob);
        var prefabEntity = EntityManager.GetComponentData<UnitSelectorSpawnerComponent>(unitSelectorSpawner[0]).UnitSelectorPrefabEntity;
        unitSelectorSpawner.Dispose();


        Entities.ForEach((Entity entity, ref Translation translation, ref PlayerInputComponent input) =>
        {
            if (input.LeftClick)
            {
                Main.instance.selectedAreaGameObject.SetActive(true);
                startPos = input.MousePosition;
            }

            if (input.LeftClickHeldDown)
            {
                float3 selectionAreaPosition = startPos / 2 + input.MousePosition / 2 + new float3(0,1,0);
                float3 selectionAreaSize = new float3(math.max(input.MousePosition.x, startPos.x), 1, math.max(input.MousePosition.z, startPos.z)) - new float3(math.min(input.MousePosition.x, startPos.x), 0, math.min(input.MousePosition.z, startPos.z));//(float3)input.MousePosition - startPos;
                Main.instance.selectedAreaGameObject.transform.position = selectionAreaPosition;
                Main.instance.selectedAreaGameObject.transform.localScale = selectionAreaSize;
            }

            if (input.LeftClickReleased)
            {
                float3 endPos = input.MousePosition;
                float3 lowerLeftPosition = new float3(math.min(startPos.x, endPos.x), 0, math.min(startPos.z, endPos.z));
                float3 upperRightPositio = new float3(math.max(startPos.x, endPos.x), 0, math.max(startPos.z, endPos.z));

                if (translation.Value.x >= lowerLeftPosition.x &&
                    translation.Value.z >= lowerLeftPosition.z &&
                    translation.Value.x <= upperRightPositio.x &&
                    translation.Value.z <= upperRightPositio.z)
                {
                    Entity ent = EntityManager.Instantiate(prefabEntity);
                    EntityManager.SetComponentData(ent, new Translation { Value = translation.Value - new float3(0, 1, 0) });
                    PostUpdateCommands.AddComponent(entity, new SelectedUnitComponent { RenderedSelectorEntity = ent});
                }
                Main.instance.selectedAreaGameObject.SetActive(false);


            }

            
        });
        // This could be done with the if statement first so it wont try to loop this every frame. But this is probably negligible performance hit anyway
        Entities.ForEach((Entity entity, ref PlayerInputComponent input, ref SelectedUnitComponent selected) => {
            if (input.RightClick)
            {
                EntityManager.DestroyEntity(selected.RenderedSelectorEntity);
                PostUpdateCommands.RemoveComponent(entity, typeof(SelectedUnitComponent));
            }
        });
        

    }
}



