using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileObj : MonoBehaviour
{
    public static void CreateProjectObj(bool isOnlyDamage, Unit fromUnit, Unit toUnit, int skillIdx = 0)
    {

        if (isOnlyDamage)
        {
            toUnit.Damage(fromUnit, toUnit);
        }
        else
        {
            if (skillIdx != 0)
            {
                GameObject effectGo = null;
                ResourceManager.Instance.LoadResourceFromChche_Go("/", out effectGo);
                var effectProjectObj = effectGo.AddComponent<ProjectileObj>();
                effectProjectObj.Init(skillIdx, toUnit);
                effectProjectObj.TargetUnit = toUnit;
            }
            else
            {

            }
        }
    }

    public Unit TargetUnit = null;
    Coroutine SkillActionCor = null;

    public void Init(int skillIdx, Unit TargetUnit)
    {
        switch (skillIdx)
        {
            case 1:
                SkillActionCor = StartCoroutine(skillAction_Fire());
                break;
        }
    }

    IEnumerator skillAction_Fire()
    {
        transform.position = TargetUnit.transform.position;
        yield return null;
    }

    private void OnDisable()
    {
        if(SkillActionCor != null)
        {
            StopCoroutine(SkillActionCor);
            SkillActionCor = null;
        }
    }
}
