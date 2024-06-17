using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTimeHandle : MonoBehaviour
{
    [SerializeField]
    private Text skill_CoolTimeText = null;
    [SerializeField]
    private Image skill_FillAmountImg = null;
    [SerializeField]
    private Image skill_Image = null;

    private int skillIdx = 0;
    private float skillCoolTime = 0f;
    Coroutine skillCoolTimethread = null;

    private void Start()
    {
        
    }

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
            if (skillIdx == 0)
                continue;

            if (skillCoolTime < 0f || skillCoolTime == 0f)
            {
                skillCoolTime = 0f;
                continue;
            }

            skillCoolTime -= 0.1f;

            if(skillCoolTime < 0f || skillCoolTime == 0f)
            {
                GameEventObserver.Publish(GameEventType.Character_SkillAdd, skillIdx);
            }
        }
    }
}
