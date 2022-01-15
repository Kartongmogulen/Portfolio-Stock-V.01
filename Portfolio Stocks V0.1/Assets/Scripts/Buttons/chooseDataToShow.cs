using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script för vilken data som ska visas då Sector samt Föreatag har valts

public class chooseDataToShow : MonoBehaviour
{
    
	public GameObject divDataGO;
	public GameObject keyMetricGO;
	public GameObject week52PanelGO;

	public GameObject buttonDivData;
	public GameObject buttonKeyMetric;

	private int dataToShowInt;

	public void divDataShow(){

		dataToShowInt = 0;
		divDataGO.SetActive (true);
		buttonDivData.GetComponent<Image>().color = Color.green;
		deactivatedOther ();
	}

	public void keyMetricShow()
	{
		dataToShowInt = 1;
		keyMetricGO.SetActive (true);
		week52PanelGO.SetActive (true);
		buttonKeyMetric.GetComponent<Image>().color = Color.green;
		deactivatedOther ();
	}

	public void deactivatedOther()
	{
		if (dataToShowInt == 0) 
		{
			keyMetricGO.SetActive (false);
			week52PanelGO.SetActive (false);
			buttonKeyMetric.GetComponent<Image>().color = Color.white;
		}

		if (dataToShowInt == 1) 
		{
			divDataGO.SetActive (false);
			buttonDivData.GetComponent<Image>().color = Color.white;
		}


	}


}
