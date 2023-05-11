using UnityEngine;

namespace Assets.Scripts.Plane
{
    /// <summary>
    /// Mobil platformlar için dikey eksendeki hareketleri yönetmekten sorumlu
    /// </summary>
    public class MobileVerticalMovement : AbstractVerticalMovement
    {
        /// <summary>
        /// dokunma gerçekleşti mi?
        /// </summary>
        bool isTouch;
        private void Update()
        {
            if (!isTouch)
            {
                isTouch = CheckInput();
            }
            
        }
        /// <summary>
        /// Kullanıcı girdisini Touch metodu ile kontrol eder
        /// </summary>
        public override bool CheckInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) return true;
                else return false;
            }
            else return isTouch;
        }

        public override void MoveVelocity(float speed, Rigidbody2D rb)
        {
           if(isTouch)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                isTouch=false;
            }
        }
    }
}