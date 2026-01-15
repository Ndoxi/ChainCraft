using ChainCraft.Data.Providers;
using System;
using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public interface IAnimationPlayer
    {
        void Play(GameObject target,
                  Vector3 from,
                  Vector3 to,
                  AnimationsConfig.Animation animParams,
                  bool autoDestroy = true,
                  Action onComplete = null);
        void PlayHoming(GameObject target,
                  Vector3 from,
                  Func<Vector3> destGetter,
                  AnimationsConfig.Animation animParams,
                  bool autoDestroy = true,
                  Action onComplete = null);
    }
}