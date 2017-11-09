using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{
    public class CameraBounds : MonoBehaviour
    {
        public Vector3 size = new Vector3(50f, 15f, 80f);

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, size);
        }

        // Takes in current pos and returns adjusted Pos (constrained)
        public Vector3 GetAdjustedPos (Vector3 incomingPos)
        {
            //Store position in a smaller variable
            Vector3 pos = transform.position;
            Vector3 halfSize = size * 0.5f;

            //Is incomingPos.z outside positive Z?
            if (incomingPos.z > pos.z + halfSize.z)
            {
                incomingPos.z = pos.z + halfSize.z;
            }

            //Is incomingPos.z outside negative Z?
            if (incomingPos.z < pos.z - halfSize.z)
            {
                incomingPos.z = pos.z - halfSize.z;
            }

            //Is incomingPos.y outside positive Y?
            if (incomingPos.y > pos.y + halfSize.y)
            {
                incomingPos.y = pos.y + halfSize.y;
            }

            //Is incomingPos.y outside negative Y?
            if (incomingPos.y < pos.y - halfSize.y)
            {
                incomingPos.y = pos.y - halfSize.y;
            }

            //Is incomingPos.x outside positive X?
            if (incomingPos.x > pos.x + halfSize.x)
            {
                incomingPos.x = pos.x + halfSize.x;
            }

            //Is incomingPos.x outside negative X?
            if (incomingPos.x < pos.x - halfSize.x)
            {
                incomingPos.x = pos.x - halfSize.x;
            }

            return incomingPos;
        }

    }
}
