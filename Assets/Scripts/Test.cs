using System;
using DG.Tweening.Core;
using Plugins.Animations.Adapters.Core;
using UnityEngine;

public class Test : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Adapter<Color> _colorAdapter;

    private void Awake()
    {
    }
}
