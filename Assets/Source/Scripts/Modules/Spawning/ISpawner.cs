using UnityEngine;

namespace LastBastion.Spawning
{
    public interface ISpawner
    {
        Vector2 SpawnPosition { get; }

        SpawnableObject CreateObj();
        void DestroyObj(SpawnableObject obj);
        void InvokeSpawnedEvent(SpawnableObject obj);
    }
}
