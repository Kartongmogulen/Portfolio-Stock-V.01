using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class windowGraph : MonoBehaviour
{
	public GameObject MainCanvasGO;
	public GameObject DataPointsGO;
	public float[] valueList;

	public float graphHeight;

	[SerializeField] float xSize;

	[SerializeField] private Sprite circleSprite;
	public RectTransform windowGraphContainer; 
	public RectTransform graphContainer; 
	public RectTransform DataPoints;
	public GameObject labelTemplateX;
	public GameObject labelTemplateY;
	public GameObject dashTemplateX;
	public GameObject dashTemplateY;

	private float maxValue;

	private void Awake(){
		//graphContainer = transform.Find ("graphContainer").GetComponent<RectTransform> ();
		//labelTemplateX.gameObject.SetActive (true);
		//labelTemplateX = graphContainer.Find ("labelTemplateX").GetComponent<RectTransform> ();
		//dashTemplateX = graphContainerGO.Find ("dashTemplateX").GetComponent<RectTransform> ();
		//CreateCircle (new Vector2 (100, 100));
		//List<float> valueList = new List<float> () { 10, 30, 50, 30, 70, 90, 50 };
		//ShowGraph (valueList);
		//valueList[0] = 0;
	}

	public void CreateGraph (){
		valueList = MainCanvasGO.GetComponent<infoStockSector> ().utiPriceHist;
		findMaxValue (valueList);
		ShowGraph (valueList);
	}

	private void CreateCircle (Vector2 anchoredPosition){
		GameObject gameObject = new GameObject ("circle", typeof(Image));
		gameObject.transform.SetParent (DataPoints, false);
		gameObject.GetComponent<Image> ().sprite = circleSprite;
		RectTransform rectTransform = gameObject.GetComponent<RectTransform> (); 
		rectTransform.anchoredPosition = anchoredPosition;
		rectTransform.sizeDelta = new Vector2 (11, 11);
		rectTransform.anchorMin = new Vector2 (0, 0);
		rectTransform.anchorMax = new Vector2 (0, 0);
	}

	private void ShowGraph(float[] valueList) {

		destroyPreviousData ();

		graphHeight = windowGraphContainer.sizeDelta.y;
		//float graphHeight = 10f;
		float yMaximum = 0.5f;
		xSize = (windowGraphContainer.sizeDelta.x-50f)/12;
		for (int i = 0; i < 12; i++) {
			float xPosition = xSize + i * xSize;
			//float yPosition = (valueList [i] / yMaximum) * graphHeight; 
			float yPosition = (valueList [i] / maxValue)*(graphHeight*0.4f);// Max-värdet är alltid på 40% av grafens höjd
			CreateCircle(new Vector2(xPosition,yPosition));

			GameObject labelX = Instantiate (labelTemplateX);
			labelX.GetComponent<RectTransform>().SetParent (DataPoints);
			labelX.gameObject.SetActive (true);
			labelX.GetComponent<RectTransform>().anchoredPosition = new Vector2 (xPosition, 0);
			labelX.GetComponent<Text> ().text = (i+1).ToString ();

			//Skapar linjer i grafen
			GameObject dashX = Instantiate (dashTemplateX);
			dashX.GetComponent<RectTransform>().SetParent (DataPoints);
			dashX.gameObject.SetActive (true);
			dashX.GetComponent<RectTransform>().anchoredPosition = new Vector2 (xPosition, graphHeight/2);

		}

		int separatorCount = 10;
		for (int i = 0; i <= separatorCount; i++) {
			GameObject labelY = Instantiate (labelTemplateY);
			labelY.GetComponent<RectTransform>().SetParent (DataPoints);
			labelY.gameObject.SetActive (true);
			float normalizedValue = i* 1f/separatorCount;
			labelY.GetComponent<RectTransform>().anchoredPosition = new Vector2 (-7f, normalizedValue*graphHeight);
			float graphMaxValue = 2.5f*maxValue*normalizedValue;
			labelY.GetComponent<Text> ().text = Mathf.RoundToInt(graphMaxValue).ToString ();

			//Skapar linjer i grafen 
			GameObject dashY = Instantiate (dashTemplateY);
			dashY.GetComponent<RectTransform>().SetParent (DataPoints);
			dashY.gameObject.SetActive (true);
			dashY.GetComponent<RectTransform>().anchoredPosition = new Vector2 (160, normalizedValue*graphHeight);
		}
	}

	//Skapa linjer mellan punkterna
	private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPostionB){
		
	}

	private void destroyPreviousData(){

		foreach (Transform child in transform)
			GameObject.Destroy (child.gameObject);
	
	}

	private void findMaxValue(float[] valueList){

		for (int i = 1; i < valueList.Length; i ++){
		
			if (valueList[i] > valueList[i-1])
		
				maxValue = valueList[i];
			}
	}
}


