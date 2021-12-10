using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Netherlands3D.CoordinateSystems;

namespace Netherlands3D.LayerSystem
{
    public class CoordinateConfigurationSettings : MonoBehaviour
    {
        public CoordinateConfiguration ConfigurationFile;

        void Awake()
        {

            CoordinateSystems.Config.activeConfiguration = ConfigurationFile;

        }
    }
}
