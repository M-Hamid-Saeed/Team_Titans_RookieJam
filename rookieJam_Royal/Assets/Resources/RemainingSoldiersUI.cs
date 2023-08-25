using UnityEngine;
using TMPro;

public class RemainingSoldiersUI : MonoBehaviour
{
    public pathCreator PathCreator; // Reference to the pathCreator script
    public TextMeshProUGUI remainingSoldiersText; // Reference to the TextMeshProUGUI component

    private void Update()
    {
        UpdateRemainingSoldiersText();
    }

    private void UpdateRemainingSoldiersText()
    {
        int remainingSoldiers = PathCreator.maxSoldierCount - PathCreator.currentSoldierCount;
        remainingSoldiersText.text = remainingSoldiers.ToString();
    }
}
