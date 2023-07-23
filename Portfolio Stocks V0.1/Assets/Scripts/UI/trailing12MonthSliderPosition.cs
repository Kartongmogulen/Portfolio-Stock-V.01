using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trailing12MonthSliderPosition : MonoBehaviour
{
    //Förflyttar en slider beroende på högsta och lägsta värdet senaste 12 månaderna

    public float number;
    public Slider yourSlider;

    
    public void MoveSlider(float price, float high, float low)
    {
        Debug.Log("Pris: " + price);
        Debug.Log("Högsta pris: " + high);
        number = (price-low)/(high-low);
        yourSlider.value = number;     //num should be from 0 to 1, because that's the range of a slider
    }

    
    public float slidersRelativePoistionFromTwoValues(float price, float low, float high)
    {
        number = (price - low) / (high - low);

        return number;
    }
}
