using UnityEngine;

namespace LastBastion.View.Interface
{
    public interface IObjectPoolView
    {
        Vector2 SpawnPosition { get; }

        SpawnableObject CreateObj();
        void DestroyObj(SpawnableObject obj);
        void InvokeSpawnedEvent(SpawnableObject obj);
    }
}
