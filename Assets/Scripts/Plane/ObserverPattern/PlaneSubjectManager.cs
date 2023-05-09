using UnityEngine;

namespace Assets.Scripts.Plane.ObserverDesign
{
    /// <summary>
    /// Uçağın gözlenen durumu (Observer design pattern) ile ilgili görevleri yönetmekten sorumlu
    /// </summary>
    public class PlaneSubjectManager : MonoBehaviour
    {
        IPositionSubject positionSubject;
        private void Start()
        {
            positionSubject = GetComponent<IPositionSubject>();
        }
        private void LateUpdate()
        {
            positionSubject.TargetObjectPosNotify();
        }

    }
}