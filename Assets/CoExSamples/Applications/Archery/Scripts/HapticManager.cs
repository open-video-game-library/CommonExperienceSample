using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archery
{
    /// <summary>
    /// This class implements tactile feedback when drawing a bow. By default, Meta Quest's vibration process is implemented.
    /// </summary>
    public class HapticManager : MonoBehaviour
    {
        public void ProvideHapticFeedback(float tension, OVRInput.Controller controller)
        {
            OVRInput.SetControllerVibration(0.1f, 0.1f, controller);
        }
    }

}
