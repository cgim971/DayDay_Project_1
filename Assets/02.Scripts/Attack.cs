using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool _isDisable = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("monster") )
        {
            other.GetComponent<MonsterBase>().TakeDamaged(GameManager._instance._playerController.Attack);
        }
        if (other.CompareTag("monsterA"))
        {
            other.GetComponentInParent<MonsterBase>().TakeDamaged(GameManager._instance._playerController.Attack);
        }
        if ((other.CompareTag("monster") && _isDisable) || (other.CompareTag("wall") && _isDisable) || (other.CompareTag("monsterA") && _isDisable))
        {
            Destroy(gameObject);
        }
    }
}
