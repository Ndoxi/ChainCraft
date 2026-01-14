using ChainCraft.Data.Providers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public class AnimationPlayer : MonoBehaviour, IAnimationPlayer
    {
        private class AnimationEntry
        {
            public GameObject target;
            public Vector3 start;
            public Vector3 end;
            public float duration;
            public float elapsed;
            public AnimationCurve heightCurve;
            public bool autoDestroy;
            public Action onComplete;
        }

        private readonly List<AnimationEntry> _animations = new();

        public void Play(GameObject target,
                         Vector3 from,
                         Vector3 to,
                         AnimationsConfig.Animation animParams,
                         bool autoDestroy = true,
                         Action onComplete = null)
        {
            var entry = new AnimationEntry
            {
                target = target,
                start = from,
                end = to,
                duration = animParams.duration,
                heightCurve = animParams.curveY,
                autoDestroy = autoDestroy,
                onComplete = onComplete
            };

            target.transform.position = from;

            _animations.Add(entry);
        }

        private void Update()
        {
            Tick(Time.deltaTime);
        }

        private void Tick(float delta)
        {
            for (int i = _animations.Count - 1; i >= 0; i--)
            {
                var entry = _animations[i];
                entry.elapsed += delta;
                float t = Mathf.Clamp01(entry.elapsed / entry.duration);

                Vector3 pos = Vector3.Lerp(entry.start, entry.end, t);
                pos.y += entry.heightCurve?.Evaluate(t) ?? 0f;

                entry.target.transform.position = pos;

                if (t >= 1f)
                {
                    entry.onComplete?.Invoke();

                    if (entry.autoDestroy && entry.target != null)
                        Destroy(entry.target);

                    _animations.RemoveAt(i);
                }
            }
        }
    }
}