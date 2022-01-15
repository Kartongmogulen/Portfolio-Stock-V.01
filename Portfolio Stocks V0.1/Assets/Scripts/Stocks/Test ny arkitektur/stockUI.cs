using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;

[System.Serializable]
public class stockUIEvent : UnityEvent<stockUI>	{}

public class stockUI : MonoBehaviour
{

	public stock Stock; 
	public Text stockName;

	public stockUIEvent onClicked;
   
	// Start is called before the first frame update
    void Start()
    {
		if (Stock) 
			Display (Stock);
				
    }

	public virtual void Display(stock Stock){
		this.Stock = Stock;
		stockName.text = Stock.name;

	}

	public virtual void Click(){
		Debug.Log ("StockUI Click");
		onClicked.Invoke (this);
	}

	
}
