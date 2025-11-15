using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileComponent : MonoBehaviour
{
    [SerializeField]
    private int _tileIndex;
    [SerializeField]
    private bool _isEnable;
    [SerializeField]
    private Button _tileButton;
    [SerializeField]
    private Sprite _enableSprite;
    [SerializeField]
    private Sprite _disableSprite;
    [SerializeField] 
    private TMP_Text _tileText;
    [SerializeField]
    private string _tileValue;

    public void SetValue(string value)
    {
        _tileButton.GetComponent<Image>().sprite = _enableSprite;
        _tileButton.interactable = true;
        _tileValue = value;
        _tileText.text = value;
        _isEnable = true;

        _tileButton.onClick.AddListener(OnButtonClicked);
    }

    public void SetIndex(int index) 
    {  
        _tileIndex = index; 
    }

    public int GetValue() 
    {
        return int.Parse(_tileValue);
    }

    public int GetIndex() 
    {
        return _tileIndex;
    }

    public bool IsEnable() 
    {
        return _isEnable;
    }

    public void DisableTile() 
    {
        _tileButton.GetComponent<Image>().sprite = _disableSprite;
        _tileButton.interactable = false;
        _tileValue = null;
        _tileText.text = _tileValue;
        _isEnable = false;
    }


    #region Button Listeners
    private void OnButtonClicked()
    {
        TileEM.SelectTileValue(int.Parse(_tileValue));
        TileEM.SelectTileIndex(_tileIndex);
    }
    #endregion
}
