using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCase : MonoBehaviour
{
    [SerializeField] SkillBase _skill;
    /// <summary>
    /// �̰Ŵ� ��ų �ٲ� �� ��� ���࿡ �ʱ� �� ������ null�� ���� �� �ſ���
    /// </summary>
    /// <param name="skill"></param>
    public void SetSkill(SkillBase skill = null)
    {
        _skill = skill;
    }

    /// <summary>
    /// ��ų ��� �� ��
    /// </summary>
    /// <returns></returns>
    public float UseSkill()
    {
        if (_skill == null) return 0f;
        GameManager._instance._playerController.Attack = _skill.attackPower;
        float delay;
        _skill.UseSkill(out delay);

        return delay;
    }
}
