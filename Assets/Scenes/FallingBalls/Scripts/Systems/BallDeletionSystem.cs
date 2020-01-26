﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Jobs;

public class BallDeletionSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, ref Translation translation, ref BallTag ballTag) =>
        {
            if (translation.Value.y < -2)
            {
                EntityManager.DestroyEntity(entity);
            }
        });
    }
   
}
