using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Netherlands3D
{
    
    public static class Events
    {
        private static Dictionary<string,System.Action> actionList;
        // Start is called before the first frame update
        
            public static void AddAction(string actionName, System.Action actionFunction)
        {
            actionList.Add(actionName, actionFunction);
        }
        public static System.Action getAction(string actionName)
        {
            if (actionList.ContainsKey(actionName))
            {
                return actionList[actionName];
            }
            return null;
        }
    }
}
