using UnityEngine;

[System.Serializable]
public class TemporaryEffect
{

    [SerializeField] private stock targetStock;
    [SerializeField] private float epsChange;
    [SerializeField] private bool isPositive;
    [SerializeField] private int remainingDuration;

public TemporaryEffect(stock targetStock, float epsChange, bool isPositive, int duration)
{
    this.targetStock = targetStock;
    this.epsChange = (epsChange/100)*targetStock.EPSnow;
    this.isPositive = isPositive;
    this.remainingDuration = duration;
}

    // Offentliga fält för att visa effekten i inspektorn
    public stock TargetStock => targetStock;
    public float EpsChange => epsChange;
    public bool IsPositive => isPositive;
    public int RemainingDuration => remainingDuration;

    public bool Tick()
{
        //Debug.Log("Tick");
    remainingDuration--;

    if (remainingDuration == 0)
    {
            Debug.Log("EPS change: " + epsChange);
            Debug.Log("EPS nu: " + targetStock.EPSnow);
            Debug.Log("Positivt event? = " + isPositive);
        // Återställ effekten när tiden är ute
        targetStock.updateEPS(isPositive ? -epsChange + targetStock.EPSnow : epsChange + targetStock.EPSnow);
            //Debug.Log("Återställ EPS med: " + (isPositive ? -(epsChange + targetStock.EPSnow) : epsChange + targetStock.EPSnow));
        return true;
    }


    return false;
}
}
