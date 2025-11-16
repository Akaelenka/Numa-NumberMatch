using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayCheat : MonoBehaviour
{
    public TMP_InputField CheatInputField;
    public Button RemoveTilesInBlockButton;

    private void Awake()
    {
        RemoveTilesInBlockButton.onClick.AddListener(RemoveTilesInBlock);
    }

    private void RemoveTilesInBlock()
    {
        TileNewEM.RemoveTilesInRow(int.Parse(CheatInputField.text));
    }
}
