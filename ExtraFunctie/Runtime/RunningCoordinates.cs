using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Netherlands3D.CoordinateSystems;
using Netherlands3D.LayerSystem;

namespace Netherlands3D.UI
{
    public class RunningCoordinates : MonoBehaviour
    {
        public Text textfield;
        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
            Vector3RD coordinate = CoordConvert.UnitytoRD(Netherlands3D.LayerSystem.Config.activeCamera.transform.position);
            textfield.text = ($" x: {coordinate.x} y: {coordinate.x} ");
        }
    }
}
