using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class RotatingCubeSystem : JobComponentSystem
{
    [BurstCompile]
    public struct RotatingCubeJob : IJobForEach<Rotation, RotationSpeed>
    {
        public float deltaTime;
        public void Execute(ref Rotation rotation, [ReadOnly] ref RotationSpeed rotationSpeed)
        {
            float rotationThisFrame = deltaTime * rotationSpeed.Value;
            //var q = Quaternion.AngleAxis(rotationThisFrame, new float3(0.0f, 1.0f, 0.0f));
            var q = Quaternion.AxisAngle(new float3(0.0f, 1.0f, 0.0f), rotationThisFrame);
            rotation.Value = math.mul(q, rotation.Value);
        }
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
       
        return new RotatingCubeJob{ deltaTime = Time.DeltaTime}.Schedule(this, inputDeps);
    }
}
