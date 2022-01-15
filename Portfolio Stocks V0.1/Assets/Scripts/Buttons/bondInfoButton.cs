using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bondInfoButton : MonoBehaviour
{
	public GameObject stockSectorPanel;
	public GameObject stockInfoPanel;
	public GameObject realEstatePanel;
	public GameObject bondPanel; 

	public int bondPanelOnOff;

	public void activateBondsPanel ()
	{
		if (bondPanelOnOff==0){
			bondPanel.SetActive (true);
			bondPanelOnOff++;
		}
		else {
				bondPanelOnOff = 0;
				bondPanel.SetActive (false);
			}
			
		realEstatePanel.SetActive (false);
		stockSectorPanel.SetActive (false);
		stockInfoPanel.SetActive (false);

	}

}