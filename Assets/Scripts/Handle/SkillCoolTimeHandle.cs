using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCoolTimeHandle : MonoBehaviour
{
    public int skillIdx = 0;
    private float skillCoolTime = 0f;
    Coroutine skillCoolTimethread = null;

    private void OnEnable()
    {
        skillCoolTime = 5f;
        skillCoolTimethread = StartCoroutine(SkillCoolTimeThread());
    }

    private void OnDisable()
    {
        StopCoroutine(skillCoolTimethread);
        skillCoolTimethread = null;
    }

    IEnumerator SkillCoolTimeThread()
    {
        var waitSecond = new WaitForSeconds(0.1f);

        while (true)
        {
            yield return waitSecond;
            if (skillCoolTime < 0f || skillCoolTime == 0f)
            {
                skillCoolTime = 0f;
                continue;
            }

            skillCoolTime -= 0.1f;
        }
    }
}
