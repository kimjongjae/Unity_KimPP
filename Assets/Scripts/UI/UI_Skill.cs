using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Skill : MonoBehaviour
{
    [SerializeField]
    private Text autoSkill = null;
    [SerializeField]
    private Button autoButton = null;

    private void Start()
    {
        AutoTextUpdate();
        autoButton.onClick.AddListener(On_ClickAutoBtn);
    }

    public void On_ClickAutoBtn()
    {
        AccountData.Instance.account_Skill.SetIsSkillAuto(!AccountData.Instance.account_Skill.GetIsSkillAuto);
        AutoTextUpdate();
    }

    void AutoTextUpdate()
    {
        autoSkill.text = AccountData.Instance.account_Skill.GetIsSkillAuto == true ? "Auto ON" : "Auto OFF";
    }
}
