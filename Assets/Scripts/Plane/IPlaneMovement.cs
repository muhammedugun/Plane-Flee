namespace Assets.Scripts.Plane
{
    /// <summary>
    /// Uçak hareketi ile ilgili görevlerden sorumlu.
    /// </summary>
    public interface IPlaneMovement
    {
        /// <summary>
        /// Yatay hareket hızı
        /// </summary>
        public float HorizontalSpeed { get; set; }

        /// <summary>
        /// Dikey hareket hızı
        /// </summary>
        public float VerticalSpeed { get; set; }
        /// <summary>
        /// Uçağı yatay eksende hareket ettirir
        /// </summary>
        void MoveHorizontal();

        /// <summary>
        /// Uçağı dikey eksende hareket ettirir
        /// </summary>
        void MoveVertical();
    }
}