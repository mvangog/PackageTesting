using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Netherlands3D.LayerSystem
{
    public class TileSystemSettings : MonoBehaviour
    {
        public TileSystemConfiguration ConfigurationFile;

        void Awake()
        {

            Config.webserverRootPath = ConfigurationFile.webserverRootPath;
            Config.activeCamera = Camera.main;


        }
    }
}
