using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Collections;

public class UnitCommandSystem : JobComponentSystem
{

    private struct MovementJob : IJobForEach<PlayerInputComponent, NavAgentComponent, SelectedUnitComponent>
    {
        public void Execute(ref PlayerInputComponent input, ref NavAgentComponent navAgent, ref SelectedUnitComponent selected)
        {
            if (input.LeftClick)
            {
                navAgent.finalDestination = input.MousePosition;
                navAgent.agentStatus = NavAgentStatus.Moving;
            }
            
        }
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        MovementJob movementJob = new MovementJob { };
        return movementJob.Schedule(this, inputDeps);
    }
}
