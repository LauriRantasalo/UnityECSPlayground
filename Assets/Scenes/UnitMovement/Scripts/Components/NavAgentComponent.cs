using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public enum NavAgentStatus
{
    Idle,
    Moving,
}
public struct NavAgentComponent : IComponentData
{
    public float3 finalDestination;
    public NavAgentStatus agentStatus;
}
