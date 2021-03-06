/*
*  Copyright (C) X Gemeente
*                X Amsterdam
*                X Economic Services Departments
*
*  Licensed under the EUPL, Version 1.2 or later (the "License");
*  You may not use this work except in compliance with the License.
*  You may obtain a copy of the License at:
*
*    https://github.com/Amsterdam/3DAmsterdam/blob/master/LICENSE.txt
*
*  Unless required by applicable law or agreed to in writing, software
*  distributed under the License is distributed on an "AS IS" basis,
*  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
*  implied. See the License for the specific language governing
*  permissions and limitations under the License.
*/


using UnityEngine;

namespace Netherlands3D.CoordinateSystems
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CoordinatesConfiguration", order = 0)]
    [System.Serializable]
    public class CoordinateConfiguration : ScriptableObject
    {
        public enum MinimapOriginAlignment
        {
            TopLeft,
            BottomLeft
        }

        [Header("Bounding Box coordinates")]
        public Vector2RD RelativeCenterRD;
        public Vector2RD BottomLeftRD;
        public Vector2RD TopRightRD;

        public float zeroGroundLevelY = 43.0f;

        [Header("Tile layers external assets paths")]
        public string webserverRootPath = "https://3d.amsterdam.nl/web/data/";
	}
}