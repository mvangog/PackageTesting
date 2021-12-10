using UnityEngine;
using Netherlands3D.CoordinateSystems;

namespace Netherlands3D.LayerSystem
{
    /// <summary>
    /// bepaalt elke frame welk deel van amsterdam in beeld is en stelt in als public Brutile.Extent in WGS84 beschikbaar
    /// </summary>
    public static class CameraExtents
    {
        private enum Corners
        {
            TOP_LEFT,
            TOP_RIGHT,
            BOTTOM_LEFT,
            BOTTOM_RIGHT
        }

        
        private static float maximumViewDistance = 5000;
        
        private static bool drawDebugLines = true;

        private static Vector3[] corners;

        public static Extent cameraExtent;

        

        

        private static Extent CameraExtent()
        {
            // Determine what world coordinates are in the corners of our view
            corners = new Vector3[4];
            corners[0] = GetCornerPoint(Corners.TOP_LEFT);
            corners[1] = GetCornerPoint(Corners.TOP_RIGHT);
            corners[2] = GetCornerPoint(Corners.BOTTOM_RIGHT);
            corners[3] = GetCornerPoint(Corners.BOTTOM_LEFT);

            // Determine the min and max X- en Z-value of the visible coordinates
            var unityMax = new Vector3(-9999999, -9999999, -99999999);
            var unityMin = new Vector3(9999999, 9999999, 9999999);
            for (int i = 0; i < 4; i++)
            {
                unityMin.x = Mathf.Min(unityMin.x, corners[i].x);
                unityMin.z = Mathf.Min(unityMin.z, corners[i].z);
                unityMax.x = Mathf.Max(unityMax.x, corners[i].x);
                unityMax.z = Mathf.Max(unityMax.z, corners[i].z);
            }

            // Convert min and max to WGS84 coordinates
            var rdMin = CoordConvert.UnitytoRD(unityMin);
            var rdMax = CoordConvert.UnitytoRD(unityMax);

            // Area that should be loaded
            var extent = new Extent(rdMin.x, rdMin.y, rdMax.x, rdMax.y);
            return extent;
        }

        private static Vector3 GetCornerPoint(Corners corner)
        {
            var screenPosition = new Vector2();

            switch (corner)
            {
                case Corners.TOP_LEFT:
                    screenPosition.x = 0;
                    screenPosition.y = 1;

                    break;
                case Corners.TOP_RIGHT:
                    screenPosition.x = 1;
                    screenPosition.y = 1;
                    break;
                case Corners.BOTTOM_LEFT:
                    screenPosition.x = 0;
                    screenPosition.y = 0;
                    break;
                case Corners.BOTTOM_RIGHT:
                    screenPosition.x = 1;
                    screenPosition.y = 0;
                    break;
                default:
                    break;
            }
            var output = new Vector3();

            var topScreenPointFar = Config.activeCamera.ViewportToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 10000));
            var topScreenPointNear = Config.activeCamera.ViewportToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 10));

            // Calculate direction vector
            Vector3 direction = topScreenPointNear - topScreenPointFar;
            float factor; //factor waarmee de Richtingvector vermenigvuldigd moet worden om op het maaiveld te stoppen
            if (direction.y < 0) //wanneer de Richtingvector omhooggaat deze factor op 1 instellen
            {
                factor = 1;
            }
            else
            {
                factor = ((topScreenPointNear.y) / direction.y); //factor bepalen t.o.v. maaiveld (aanname maaiveld op 0 NAP = ca 40 Unityeenheden in Y-richting)
            }

            // Determine the X, Y, en Z location where the viewline ends
            output.x = topScreenPointNear.x - Mathf.Clamp((factor * direction.x), -1 * maximumViewDistance, maximumViewDistance);
            output.y = topScreenPointNear.y - Mathf.Clamp((factor * direction.y), -1 * maximumViewDistance, maximumViewDistance);
            output.z = topScreenPointNear.z - Mathf.Clamp((factor * direction.z), -1 * maximumViewDistance, maximumViewDistance);

            return output;
        }

        private static void OnDrawGizmos()
        {
            if (!drawDebugLines) return;

            Gizmos.color = Color.green;
            foreach (var corner in corners)
                Gizmos.DrawLine(Config.activeCamera.transform.position, corner);
        }

        public static void CalculateExtent()
        {
            cameraExtent = CameraExtent();
        }

        public static Vector3 GetPosition()
        {
            return Config.activeCamera.transform.position;
        }

        public static Vector3[] GetWorldSpaceCorners()
        {
            return corners;
        }
    }
}