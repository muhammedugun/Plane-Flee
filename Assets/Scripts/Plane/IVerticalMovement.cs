using UnityEngine;

namespace Assets.Scripts.Plane
{
    /// <summary>
    /// Dikey eksen hareketleri ile ilgili sorumlulukları üstlenir
    /// </summary>
    public interface IVerticalMovement
    {
        /// <summary>
        /// Kullanıcı girdisini kontrol eder
        /// </summary>
        bool CheckInput();

        /// <summary>
        /// Dikey yönde hareketi gerçekleştirir
        /// </summary>
        void MoveVelocity(float speed, Rigidbody2D rb);
    }
}