using NumaModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class IntroPanelHUD : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputUsernameText;
    [SerializeField]
    private TMP_Text _errorText;
    [SerializeField]
    private Button _saveButton;

    private void Awake()
    {
        Assert.IsNotNull(_inputUsernameText, $"[{gameObject.name}] InputUsernameText is not assigned.");
        Assert.IsNotNull(_errorText, $"[{gameObject.name}] ErrorText is not assigned.");
        Assert.IsNotNull(_saveButton, $"[{gameObject.name}] SaveButton is not assigned.");

        _saveButton.onClick.AddListener(Save);
    }

    private void Save()
    {
        if (string.IsNullOrEmpty(_inputUsernameText.text)) 
        {
            _errorText.text = "username is empty.";
            return;
        }

        var data = new PlayerDataModel()
        {
            Username = _inputUsernameText.text,
            ExpValue = 0
        };
        SaveEM.SavePlayerData(data);
        SaveEM.LoadPlayerDataResult(data); // TODO: Check if it's correct
    }
}
