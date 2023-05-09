namespace Assets.Scripts.Background
{

    /// <summary>
    /// Arkaplan geçişi ile ilgili görevlerden sorumlu.
    /// Arkaplan geçişi: Oyun sırasında uçak ilerlerken arkaplanında uçağın hızına göre uçağın tersi yönde gitmesidir.
    /// </summary>
    public interface IBackgroundTransition 
    {
        /// <summary>
        /// Arkaplanın geçiş hızı
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Arkaplanı hıza göre ilerletir
        /// </summary>
        void Advance(float speed);

        /// <summary>
        /// Arkaplanı, normal arkaplan hızı ile referans hızı çarparak ilerletir. Not: refersans hız değeri 1 iken arkaplan normal hızı ile hareket edecektir
        /// </summary>
        /// <param name="referanceSpeed"></param>
        public void AdvanceWithReferanceSpeed(float referanceSpeed);
    }
}