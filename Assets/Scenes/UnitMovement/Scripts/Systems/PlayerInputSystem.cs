using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

public class PlayerInputSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var mousePos = Input.mousePosition;
        var ray = Camera.main.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            mousePos = new float3(hit.point.x, 1, hit.point.z);
        }

        Entities.ForEach((Entity entity, ref PlayerInputComponent playerInputComponent) => {
            playerInputComponent.MousePosition = mousePos;
            playerInputComponent.LeftClick = Input.GetMouseButtonDown(0);
            playerInputComponent.RightClick = Input.GetMouseButtonDown(1);
            playerInputComponent.LeftClickReleased = Input.GetMouseButtonUp(0);
            playerInputComponent.RightClickReleased = Input.GetMouseButtonUp(1);
            playerInputComponent.LeftClickHeldDown = Input.GetMouseButton(0);
            playerInputComponent.RightClickHeldDown = Input.GetMouseButton(1);
        });
    }
}
