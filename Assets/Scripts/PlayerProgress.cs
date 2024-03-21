using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> levels;

    public RectTransform experienceValueRectTransform;
    public TextMeshProUGUI levelValueTMP;

    private int _levelValue = 1;

    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;


    void Start()
    {
        SetLevel(_levelValue);
        DrawUi();
    }


    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if (_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_levelValue += 1);
            _experienceCurrentValue = 0;
        }
        DrawUi();
    }

    private void SetLevel(int value)
    {
        _levelValue = value;

        var currentLevel = levels[_levelValue - 1];
        _experienceTargetValue = currentLevel.experienceForTheNextLevel;
        GetComponent<FireballCast>().damage = currentLevel.fireballDamage;

        var grenadecaster = GetComponent<GrenadeCaster>(); 
        grenadecaster.damage = currentLevel.grenadeDamage;
        if (currentLevel.grenadeDamage < 0)
        {            
            grenadecaster.enabled = false;
        }
        else
        {
            grenadecaster.enabled = true;
        }
    }

    private void DrawUi()
    {
        experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }
}
