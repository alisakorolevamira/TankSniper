using Lean.Touch;
using UnityEngine;

namespace Sources.Scripts
{
    public class TankPoint : MonoBehaviour
    {
        public bool IsAvailable;

        public void ChangeAvailability(bool aa)
        {
            IsAvailable = aa;
        }
    }
}