using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class ProductionCycle 
    { 
        public bool isDone { get; private set; } 
        public float progress { get; private set; } 

        private float _currentTime; 
        private float _targetTime; 

        public ProductionCycle(float duration) 
        { 
            _targetTime = duration;
        } 
        
        public void Tick(float delta) 
        { 
            if (_currentTime >= _targetTime) 
                return; 
            
            _currentTime += delta; 
            progress = Mathf.Clamp01(_currentTime / _targetTime); 
            
            if (_currentTime >= _targetTime) 
                isDone = true;
        }
        
        public void Reset() 
        { 
            _currentTime = 0f; 
            progress = 0f; 
            isDone = false; 
        } 
    }
}