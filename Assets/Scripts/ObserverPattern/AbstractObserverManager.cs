using UnityEngine;

namespace Assets.Scripts.ObserverPattern
{
    /// <summary>
    /// Gözlemcilik (Observer Design Pattern) ile ilgili görevleri yönetmekten sorumlu
    /// </summary>
    public abstract class AbstractObserverManager : MonoBehaviour
    {
        /// <summary>
        /// Olaylara abone olur
        /// </summary>
        public abstract void SubscribeToEvents();

        /// <summary>
        /// Olaylara olan aboneliği bitirir
        /// </summary>
        public abstract void UnsubscribeToEvents();
      

    }
}