using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

// Note the class is a monobehaviour still. So it can be given to a GameObject.
// This code runs when the GameObject is turned into an Entity by adding a ConvertToEntity component to it in the editor.
public class BallSpawnerConverter : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    // Fields exposed to the editor.
    [SerializeField] private int NumOfBalls;
    [SerializeField] private float BallMovementSpeed;
    [SerializeField] private GameObject MovinBallPrefab;

    // This method is run when the GameObject is turned into an Entity.
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        // Creates a Entity out of a prefab. Does not work without IDeclareReferencedPrefabs inherritance.
        // This does not actually Instantiate the Entity. It just creates the data for it.
        // Entity instantiation is done inside a system with Entitymanager.Instantiate()
        Entity ballEntity = conversionSystem.GetPrimaryEntity(MovinBallPrefab);

        // Making a component out of the values the user has given from the editor.
        BallSpawnerData ballSpawnerData = new BallSpawnerData
        {
            NumOfBalls = NumOfBalls,
            SpeedOfBalls = BallMovementSpeed,
            MovingBallEntity = ballEntity,
        };
        // Adding the component that was made above to the entity that was made from the.
        dstManager.AddComponentData(entity, ballSpawnerData);
    }
    // If you are Using Prefabs, you need to add the prefab to referencedPrefabs so ECS knows how to convert it to an entity. Or something.
    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(MovinBallPrefab);
    }
}
