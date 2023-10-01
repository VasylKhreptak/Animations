using UnityEngine;

namespace Plugins.Animations.Adapters.Core
{
    public abstract class Adapter<T> : MonoBehaviour
    {
        public abstract T Value { get; set; }

        #region MonoBehaviour

        private void OnValidate()
        {
            Value ??= GetComponent<T>();
        }

        #endregion
    }
}
