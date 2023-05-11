using UnityEngine;

namespace Assets.Scripts.Plane
{
    /// <summary>
    /// Dikey eksen hareketleri ile ilgili sorumlulukları üstlenir
    /// </summary>
    public abstract class AbstractVerticalMovement : MonoBehaviour
    {
        /// <summary>
        /// Kullanıcı girdisini kontrol eder
        /// </summary>
        public abstract bool CheckInput();

        /// <summary>
        /// Dikey yönde hareketi gerçekleştirir
        /// </summary>
        public abstract void MoveVelocity(float speed, Rigidbody2D rb);
    }
}