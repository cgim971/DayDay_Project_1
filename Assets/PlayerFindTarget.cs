using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFindTarget : MonoBehaviour
{


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("portal"))
        {
            if (Input.GetKeyDown(KeyCode.F))
                other.GetComponent<PortalController>().UsePortal();
        }
    }


}
