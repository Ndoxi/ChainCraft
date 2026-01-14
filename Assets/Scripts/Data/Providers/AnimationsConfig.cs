using System;
using UnityEngine;

namespace ChainCraft.Data.Providers
{
    [CreateAssetMenu(menuName = "Scriptable Objects/AnimationsConfig")]
    public class AnimationsConfig : ScriptableObject
    {
        public Animation throwAnimation => _throwAnimation;

        [SerializeField] private Animation _throwAnimation;


        [Serializable]
        public struct Animation
        {
            public AnimationCurve curveY;
            public float duration;
        }
    }
}
