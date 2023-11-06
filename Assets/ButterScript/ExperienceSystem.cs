using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExperienceSystem : MonoBehaviour
{
    public PlayerExp player = new PlayerExp();
    public Slider expBar;
    public TextMeshProUGUI levelText;

    void Start()
    {
        UpdateUI();
    }

    public void OnButtonClick() // This method will be called when the button is clicked
    {
        player.Experience += 20; 

        while (player.Experience >= player.Level * 1000 && player.Level < 10)
        {
            player.Experience -= player.Level * 1000;
            player.Level++;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        levelText.text = player.Level.ToString();
        expBar.value = (float)player.Experience / (player.Level * 1000); // Corrected expBar value calculation
    }
}