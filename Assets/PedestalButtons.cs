//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Demonstrates the use of the controller hint system
//
//=============================================================================

using UnityEngine;
using System.Collections;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    //-------------------------------------------------------------------------
    public class PedestalButtons : MonoBehaviour
    {
        public void clearTrash()
        {
            Debug.Log("cleartrash called");
            GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("toTrash");
            for (int i = 0; i < objectsToDelete.Length; i++)
            {
                DestroyImmediate(objectsToDelete[i]);

            }
        }

        public void toggleGravity()
        {
            GameObject.Find("Brush").GetComponent<GlobMaker>().gravity = !GameObject.Find("Brush").GetComponent<GlobMaker>().gravity;
        }
    }
}
