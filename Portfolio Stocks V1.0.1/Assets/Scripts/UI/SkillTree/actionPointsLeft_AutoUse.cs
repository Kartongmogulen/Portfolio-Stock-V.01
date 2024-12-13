using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actionPointsLeft_AutoUse : MonoBehaviour
{
    [SerializeField] private int savedIndex;//Skill som �r sparat att anv�nda �terst�ende po�ng

    public Sprite crossImage;
    public Sprite skillChoosen;
    public SkillsManager skillsManager;

    public void saveIndexForSkill()
    {
        savedIndex = skillsManager.getActiveSkill();
    }

    public void updateImage()
    {
        if (skillsManager.getActiveSkill() == savedIndex)
        {
            GetComponent<Image>().sprite = skillChoosen;
        }
        else
        {
            GetComponent<Image>().sprite = crossImage;
        }
    }

    public int getSavedIndex()
    {
        return savedIndex;
    }
}
