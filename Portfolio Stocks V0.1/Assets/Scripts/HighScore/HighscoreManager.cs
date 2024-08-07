using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HighscoreManager : MonoBehaviour
{
    private const int MaxHighscores = 5;
    [SerializeField] List<int> highscores;
    private int? latestScore; // Variabel f�r att h�lla reda p� den senaste scoren

    public List<TextMeshProUGUI> highscoreTextList; // Lista med TextMeshProUGUI-objekt f�r att visa highscores
    public GameObject highScoreUI;

    void Start()
    {
        LoadHighscores();
        UpdateHighscoreDisplay();
        highScoreUI.SetActive(false);// Inaktiverar vid start
    }

    public void endGame()
    {
        UpdateHighscoreDisplay();
        highScoreUI.SetActive(true);
    }

    public void AddHighscore(int score)
    {
        //Debug.Log("Score: " + score);
        highscores.Add(score);
        highscores.Sort((a, b) => b.CompareTo(a)); // Sortera i fallande ordning

        if (highscores.Count > MaxHighscores)
        {
            highscores.RemoveAt(highscores.Count - 1); // Ta bort den l�gsta po�ngen om listan �r l�ngre �n MaxHighscores
        }
        
        latestScore = score;
        SaveHighscores();
        
    }

    private void LoadHighscores()
    {
        highscores = new List<int>();

        for (int i = 0; i < MaxHighscores; i++)
        {
            string key = "Highscore" + i;
            if (PlayerPrefs.HasKey(key))
            {
                highscores.Add(PlayerPrefs.GetInt(key));
            }
        }

        highscores.Sort((a, b) => b.CompareTo(a)); // Sortera i fallande ordning
    }

    private void SaveHighscores()
    {
        for (int i = 0; i < MaxHighscores; i++)
        {
            if (i < highscores.Count)
            {
                PlayerPrefs.SetInt("Highscore" + i, highscores[i]);
            }
            else
            {
                PlayerPrefs.DeleteKey("Highscore" + i);
            }
        }

        PlayerPrefs.Save();
    }

    public List<int> GetHighscores()
    {
        return new List<int>(highscores); // Returnera en kopia av listan f�r att f�rhindra manipulation
    }

    public void ClearHighscores()
    {
        highscores.Clear();

        for (int i = 0; i < MaxHighscores; i++)
        {
            PlayerPrefs.DeleteKey("Highscore" + i);
        }

        PlayerPrefs.Save();
        latestScore = null;
    }

    private void UpdateHighscoreDisplay()
    {
        for (int i = 0; i < highscoreTextList.Count; i++)
        {
            if (i < highscores.Count)
            {
                highscoreTextList[i].text = (i + 1) + ". " + highscores[i];
                // Highlighta om det �r den senaste scoren
                if (latestScore.HasValue && highscores[i] == latestScore.Value)
                {
                    highscoreTextList[i].text = $"<b>{i + 1}. {highscores[i]}</b>"; // Anv�nd rich text f�r fet stil
                    highscoreTextList[i].color = Color.red; // �ndra f�rg f�r att highlighta
                }
                else
                {
                    highscoreTextList[i].color = Color.black; // Standardf�rg
                }
            }
            else
            {
                highscoreTextList[i].text = (i + 1) + ". -";
                highscoreTextList[i].color = Color.black; // Standardf�rg
            }
        }
    }
    /*
    for (int i = 0; i < highscoreTextList.Count; i++)
    {
        if (i < highscores.Count)
        {
            highscoreTextList[i].text = (i + 1) + ". " + highscores[i];
        }
        else
        {
            highscoreTextList[i].text = (i + 1) + ". -";
        }
    }
    */
}


