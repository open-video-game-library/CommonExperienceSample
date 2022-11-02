using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archery
{
    public class HapticManager : MonoBehaviour
    {
        public void ProvideHapticFeedback(float tension, OVRInput.Controller controller)
        {
            OVRInput.SetControllerVibration(0.1f, 0.1f, controller);
        }
    }

}
