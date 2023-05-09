using Assets.Scripts.Plane.ObserverDesign;
using Assets.Scripts.Spawn;

namespace Assets.Scripts.ObserverPattern
{
    public interface IObserverManager
    {
        /// <summary>
        /// Olaylara abone olur
        /// </summary>
        void SubscribeToEvents();

        /// <summary>
        /// Olaylara olan aboneliği bitirir
        /// </summary>
        void UnsubscribeToEvents();
      

    }
}