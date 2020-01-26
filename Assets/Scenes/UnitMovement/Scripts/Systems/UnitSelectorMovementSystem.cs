using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

public class UnitSelectorMovementSystem : JobComponentSystem
{
    private struct UnitSelectorMovementJob : IJobForEachWithEntity<Translation, SelectedUnitComponent>
    {
        public EntityCommandBuffer.Concurrent commandBuffer;

        public void Execute(Entity entity, int index, ref Translation translation, ref SelectedUnitComponent selected)
        {
            Entity selector = selected.RenderedSelectorEntity;                                                          //EntityManager.GetComponentData<SelectedUnitComponent>(entity).RenderedSelectorEntity;
            commandBuffer.SetComponent<Translation>(index, selector, new Translation { Value = translation.Value });    //EntityManager.SetComponentData(selector, new Translation { Value = translation.Value });
        }
    }


    EntityCommandBufferSystem commanBufferSystem;
    protected override void OnCreate()
    {
        commanBufferSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        base.OnCreate();
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var jobHandle = new UnitSelectorMovementJob
        {
            commandBuffer = commanBufferSystem.CreateCommandBuffer().ToConcurrent()
        }.Schedule(this, inputDeps);
        commanBufferSystem.AddJobHandleForProducer(jobHandle);
        return jobHandle;
    }
}