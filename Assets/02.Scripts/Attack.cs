using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("monster"))
        {
            other.GetComponent<MonsterBase>().TakeDamaged(GameManager._instance._playerController.Attack);
        }
    }
}
