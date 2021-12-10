using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Netherlands3D.LayerSystem
{
    public static class Config
    {
        public  delegate void TileHandlerStarted();
        public static event TileHandlerStarted onTileHandlerStarted;
        public delegate void TileHandlerFinished();
        public static event TileHandlerFinished onTileHandlerFinished;

        public static Camera activeCamera;
        public static string webserverRootPath;
        private static bool Busy;
        public static bool busy()
        {
            return Busy;
        }
        public static void busy(bool value)
        {
            if (value)
            {
                onTileHandlerStarted?.Invoke();
            }
            else
            {
                onTileHandlerFinished?.Invoke();
            }
            Busy = busy();
        }
        

    }
}
