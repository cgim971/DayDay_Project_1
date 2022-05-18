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
        float delay;
        _skill.UseSkill(out delay);

        return delay;
    }
}
