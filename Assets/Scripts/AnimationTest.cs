using Plugins.Animations;
using Plugins.Animations.Core;
using Plugins.Animations.Punch;
using Sirenix.OdinInspector;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] private PunchScaleAnimation _punchScaleAnimation;

    private IAnimation _animation;

    private void Awake()
    {
        _animation = new AnimationGroup(_punchScaleAnimation);
    }

    [Button]
    private void Play()
    {
        _animation.PlayForward(() => Debug.Log("Animation completed"));
    }

    [Button]
    private void Stop()
    {
        _animation.Stop();
    }

    [Button]
    private void PlayReversed()
    {
        _animation.PlayBackward(() => Debug.Log("Animation completed(Reversed)"));
    }

    [Button]
    private void MoveToStartState()
    {
        _animation.SetStartState();
    }

    [Button]
    private void MoveToEndState()
    {
        _animation.SetEndState();
    }
}
