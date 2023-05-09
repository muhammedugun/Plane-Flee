using System;

namespace Assets.Scripts.Plane.ObserverDesign
{
    /// <summary>
    /// Konumla ilgili gözlenim durumu ve bildirimlerde bulunmakla sorumlu
    /// </summary>
    public interface IPositionSubject
    {
        /// <summary>
        /// Hedef objeye ulaşmakla ilgili bildirim
        /// </summary>
        public static event Action OnTargetObjectPos;
        /// <summary>
        /// Hedef zemine vardığında bildirimde bulunur
        /// </summary>
        void TargetObjectPosNotify();

    }
}