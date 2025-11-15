using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ImageButtonComponent : MonoBehaviour
{
    [SerializeField] 
    private string _name;
    [SerializeField]
    private bool _isEnable;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private Sprite _enableSprite;
    [SerializeField]
    private Sprite _disableSprite;

    private void Update()
    {
        UpdateButton();
    }

    public void SetEnable(bool isEnable)
    {
        _isEnable = isEnable;
    }

    private void UpdateButton()
    {
        // Check if button reference is assigned
        if (_button == null)
        {
            Debug.LogError($"[{gameObject.name}] Button reference is missing.");
            return;
        }

        // Update button sprite based on the enable state
        if (_isEnable)
        {
            _button.GetComponent<Image>().sprite = _enableSprite;
            _button.interactable = true;
        }
        else
        {
            _button.GetComponent<Image>().sprite = _disableSprite;
            _button.interactable = false;
        }
    }
}
