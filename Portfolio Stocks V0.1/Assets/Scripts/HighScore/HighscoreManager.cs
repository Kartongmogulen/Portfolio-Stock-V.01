using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HighscoreManager : MonoBehaviour
{
    private const int MaxHighscores = 5;
    [SerializeField] List<int> highscores;

    public List<TextMeshProUGUI> highscoreTextList; // Lista med TextMeshProUGUI-objekt för att visa highscores

    void Start()
    {
        LoadHighscores();
        UpdateHighscoreDisplay();
    }

    public void AddHighscore(int score)
    {
        //Debug.Log("Score: " + score);
        highscores.Add(score);
        highscores.Sort((a, b) => b.CompareTo(a)); // Sortera i fallande ordning

        if (highscores.Count > MaxHighscores)
        {
            highscores.RemoveAt(highscores.Count - 1); // Ta bort den lägsta poängen om listan är längre än MaxHighscores
        }

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
        return new List<int>(highscores); // Returnera en kopia av listan för att förhindra manipulation
    }

    public void ClearHighscores()
    {
        highscores.Clear();

        for (int i = 0; i < MaxHighscores; i++)
        {
            PlayerPrefs.DeleteKey("Highscore" + i);
        }

        PlayerPrefs.Save();
    }

    private void UpdateHighscoreDisplay()
    {
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
    }
}

