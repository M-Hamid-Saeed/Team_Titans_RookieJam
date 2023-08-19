using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractableButton : MonoBehaviour
{
    public int maxInteractions = 3;
    private int remainingInteractions;

    public TextMeshProUGUI interactionsText; // Use TextMeshProUGUI for TextMesh Pro support
    public Button button;

    void Awake()
    {
        remainingInteractions = maxInteractions;
        UpdateInteractionsText();
    }

    public void Interact()
    {
        if (remainingInteractions > 0)
        {
            remainingInteractions--;
            UpdateInteractionsText();


            if (remainingInteractions == 0)
            {
                button.interactable = false;
            }
        }
    }

    void UpdateInteractionsText()
    {
        interactionsText.text = remainingInteractions.ToString();
    }
}
