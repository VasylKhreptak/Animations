using System;
using DG.Tweening;
using Plugins.Animations.Core;

namespace Plugins.Animations
{
    public class AnimationGroup : IAnimation
    {
        private readonly IAnimation[] _animations;

        public AnimationGroup(params IAnimation[] animations)
        {
            _animations = animations;
        }

        private Tween _tween;

        public float Duration => CreateForwardTween().Duration();

        public bool IsPlaying => _tween != null && _tween.IsPlaying();

        public void PlayForward(Action onComplete = null)
        {
            Stop();
            _tween = CreateForwardTween().OnComplete(() => onComplete?.Invoke()).Play();
        }

        public void PlayBackward(Action onComplete = null)
        {
            Stop();
            _tween = CreateBackwardTween().OnComplete(() => onComplete?.Invoke()).Play();
        }

        public void Stop() => _tween.Kill();

        public void SetStartState()
        {
            Stop();

            foreach (var animation in _animations)
            {
                animation.SetStartState();
            }
        }

        public void SetEndState()
        {
            Stop();

            foreach (var animation in _animations)
            {
                animation.SetEndState();
            }
        }

        public Tween CreateForwardTween()
        {
            Sequence sequence = DOTween.Sequence();

            foreach (var animation in _animations)
            {
                sequence.Join(animation.CreateForwardTween());
            }

            return sequence;
        }

        public Tween CreateBackwardTween()
        {
            Sequence sequence = DOTween.Sequence();

            foreach (var animation in _animations)
            {
                sequence.Join(animation.CreateBackwardTween());
            }

            return sequence;
        }
    }
}
