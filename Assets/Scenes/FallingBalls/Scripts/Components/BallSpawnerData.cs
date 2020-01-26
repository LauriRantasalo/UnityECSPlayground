using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct BallSpawnerData : IComponentData
{
    public int NumOfBalls;
    public float SpeedOfBalls;
    public Entity MovingBallEntity;
}
