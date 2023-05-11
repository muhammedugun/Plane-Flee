using UnityEngine;

namespace Assets.Scripts.Background
{

    /// <summary>
    /// Arkaplan geçişi ile ilgili görevlerden sorumlu.
    /// Arkaplan geçişi: Oyun sırasında uçak ilerlerken arkaplanında uçağın hızına göre uçağın tersi yönde gitmesidir.
    /// </summary>
    public abstract class AbstractBackgroundTransition : MonoBehaviour
    {
        /// <summary>
        /// Arkaplanın geçiş hızı
        /// </summary>
        [Range(0f, 0.02f)]
        public float speed = 0.01f;

        /// <summary>
        /// Arkaplanı hıza göre ilerletir
        /// </summary>
        public abstract void Advance(float speed);

        /// <summary>
        /// Arkaplanı, normal arkaplan hızı ile referans hızı çarparak ilerletir. Not: refersans hız değeri 1 iken arkaplan normal hızı ile hareket edecektir
        /// </summary>
        /// <param name="referanceSpeed"></param>
        public abstract void AdvanceWithReferanceSpeed(float referanceSpeed);
    }
}