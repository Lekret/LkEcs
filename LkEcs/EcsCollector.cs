using System.Collections;
using System.Collections.Generic;

namespace LkEcs
{
    public sealed class EcsCollector : IEnumerable<Entity>
    {
        private readonly HashSet<Entity> _entities = new HashSet<Entity>();
        
        public int Count => _entities.Count;
        
        public void ClearEntities()
        {
            _entities.Clear();
        }

        public MutableEntityEnumerator GetEnumerator()
        {
            return MutableEntityEnumerator.Create(_entities);
        }
        
        IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator() => GetEnumerator();
        
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        internal void AddEntity(Entity entity)
        {
            _entities.Add(entity);
        }

        internal void RemoveEntity(Entity entity)
        {
            _entities.Remove(entity);
        }
    }
}