using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

// Data for the BallSpawner to spawn data accordingly.
public struct BallSpawnerData : IComponentData
{
    public int NumOfBalls;
    public float SpeedOfBalls;
    public Entity MovingBallEntity;
}