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
    private Sprite _highlightSprite;
    [SerializeField]
    private TMP_Text _tileText;
    [SerializeField]
    private string _tileValue;

    private bool _isHighlighted;

    private void Update()
    {
        if (_isHighlighted && _isEnable)
        {
            _tileButton.GetComponent<Image>().sprite = _highlightSprite;
        }
        else if (!_isHighlighted && _isEnable) 
        {
            _tileButton.GetComponent<Image>().sprite = _enableSprite;
        }
        else 
        {
            _tileButton.GetComponent<Image>().sprite = _disableSprite;
        }
    }

    public void SetValue(int value)
    {
        _tileButton.interactable = true;
        _tileValue = value.ToString();
        _tileText.text = value.ToString();
        _isEnable = true;
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

    public Button GetButton() 
    {
        return _tileButton;
    }

    public bool IsEnable() 
    {
        return _isEnable;
    }

    public void SetActiveTile(bool isActive)
    {
        _tileButton.interactable = isActive;
        _isEnable = isActive;
    }
    
    public void DisableTile() 
    {
        _tileButton.interactable = false;
        _tileValue = null;
        _tileText.text = _tileValue;
        _isEnable = false;
    }

    public void ToggleColorButton(bool isEnable)
    {
        _isHighlighted = isEnable;
    }
}
