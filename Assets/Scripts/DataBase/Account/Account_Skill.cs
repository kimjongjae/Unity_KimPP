using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account_Skill : MonoBehaviour
{
    bool isSkillAuto = false;
    public bool GetIsSkillAuto => isSkillAuto;

    public void SetIsSkillAuto(bool isAuto)
    {
        isSkillAuto = isAuto;
    }
}
