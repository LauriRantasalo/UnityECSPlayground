using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Collections;
using Unity.Transforms;
using Unity.Mathematics;

public class NavAgentSystem : JobComponentSystem
{
    private struct NavAgentMovementJob : IJobForEach<NavAgentComponent, Translation>
    {
        public float deltaTime;
        public void Execute(ref NavAgentComponent navAgent, ref Translation translation)
        {
            var distance = math.distance(navAgent.finalDestination, translation.Value);
            var direction = math.normalize(navAgent.finalDestination - translation.Value);

            if(!(distance < 1) && navAgent.agentStatus == NavAgentStatus.Moving)
            {
                translation.Value += direction * 5 * deltaTime;
            }
            else
            {
                navAgent.agentStatus = NavAgentStatus.Idle;
            }
        }
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        NavAgentMovementJob movementJob = new NavAgentMovementJob{ deltaTime = Time.DeltaTime};
        return movementJob.Schedule(this, inputDeps);
    }
}
