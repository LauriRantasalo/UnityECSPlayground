using Unity.Entities;

public struct UnitSpawnerComponent : IComponentData
{
    public int NumOfUnitsX;
    public int NumOfUnitsZ;
    public Entity UnitEntity;
}