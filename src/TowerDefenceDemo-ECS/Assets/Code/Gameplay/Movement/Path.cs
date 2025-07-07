using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Movement
{
    public class Path
    {
        private readonly Transform[] _points;
        private int _currentPointIndex = 0;

        public Path(Transform[] points)
        {
            _points = points;
        }
        
        public Vector3 GetCurrentPosition()
        {
            return _points[_currentPointIndex].position;
        }
        
        public bool NextPosition()
        {
            if (_currentPointIndex < _points.Length - 1)
            {
                _currentPointIndex++;
                return true;
            }

            return false;
        }
    }
}