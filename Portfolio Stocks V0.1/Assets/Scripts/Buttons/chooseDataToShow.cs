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
	public GameObject historicDataPanelGO;

	public GameObject buttonDivData;
	public GameObject buttonKeyMetric;
	public GameObject buttonHistoricData;

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

	public void historicDataShow()
	{
		dataToShowInt = 2;
		historicDataPanelGO.SetActive(true);
		buttonHistoricData.GetComponent<Image>().color = Color.green;
		deactivatedOther();
	}

	public void deactivatedOther()
	{
		if (dataToShowInt == 0) 
		{
			keyMetricGO.SetActive (false);
			week52PanelGO.SetActive (false);
			historicDataPanelGO.SetActive(false);
			buttonKeyMetric.GetComponent<Image>().color = Color.white;
			buttonHistoricData.GetComponent<Image>().color = Color.white;
		}

		if (dataToShowInt == 1) 
		{
			divDataGO.SetActive (false);
			historicDataPanelGO.SetActive(false);
			buttonDivData.GetComponent<Image>().color = Color.white;
			buttonHistoricData.GetComponent<Image>().color = Color.white;
		}

		if (dataToShowInt == 2)
		{
			keyMetricGO.SetActive(false);
			week52PanelGO.SetActive(false);
			divDataGO.SetActive(false);
			buttonKeyMetric.GetComponent<Image>().color = Color.white;
			buttonDivData.GetComponent<Image>().color = Color.white;
		}


	}


}
