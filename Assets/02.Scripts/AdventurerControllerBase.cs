using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerControllerBase : MonoBehaviour
{

    private GameObject _target;

    /// <summary>
    /// 공격 키를 누를 시
    /// </summary>
    void Attack()
    {
        if(_target == null)
        {

        }
        else
        {

        }
    }


    /// <summary>
    /// 상대 찾기
    /// </summary>
    void FindTarget()
    {
        _target = null;
    }

}
