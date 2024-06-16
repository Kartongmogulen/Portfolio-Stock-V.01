using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectiveProgressUI : MonoBehaviour
{
    [SerializeField] List<Text> progressTextList;
    [SerializeField] int activeIndex;

    // Start is called before the first frame update
    void Start()
    {
        progressTextList[activeIndex].text = "Hej";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setActiveIndex(int index)
    {
        activeIndex = index;
    }
}
