using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct PlayerInputComponent : IComponentData
{
    public BlittableBool LeftClick;
    public BlittableBool RightClick;
    public BlittableBool LeftClickReleased;
    public BlittableBool RightClickReleased;
    public BlittableBool LeftClickHeldDown;
    public BlittableBool RightClickHeldDown;
    public float3 MousePosition;
}
