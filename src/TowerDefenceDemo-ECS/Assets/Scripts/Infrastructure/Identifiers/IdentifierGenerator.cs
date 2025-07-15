using System.Collections.Generic;

namespace Infrastructure.Identifiers
{
    public class IdentifierGenerator : IIdentifierGenerator
    {
        private readonly HashSet<int> _usedIds = new(64);
        private readonly Queue<int> _recycledIds = new(64);
        
        private int _nextId = 1;
        
        public int GetId()
        {
            if (_recycledIds.Count > 0)
            {
                int recycledId = _recycledIds.Dequeue();
                _usedIds.Add(recycledId);
                
                return recycledId;
            }

            int newId = _nextId++;
            _usedIds.Add(newId);
            
            return newId;
        }
        
        public void ReleaseId(int id)
        {
            if (!_usedIds.Contains(id))
                return;
            
            _usedIds.Remove(id);
            _recycledIds.Enqueue(id);
        }

    }
}