using UnityEngine;

namespace LastBastion.UnityUtilities.Spawning
{
    public interface ISpawner
    {
        Vector2 SpawnPosition { get; }

        SpawnableObject CreateObj();
        void DestroyObj(SpawnableObject obj);
        void InvokeSpawnedEvent(SpawnableObject obj);
    }
}
