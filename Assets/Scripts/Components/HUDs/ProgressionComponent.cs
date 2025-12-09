using UnityEngine;
using UnityEngine.UI;
using NumaModels;
using UnityEngine.Assertions;


//[ExecuteInEditMode]
public class ProgressionComponent : MonoBehaviour
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private int _minValue;
    [SerializeField]
    private int _maxValue;
    [SerializeField]
    private int _currentValue;
    [SerializeField]
    private Image _progressionImage;

    private void Awake()
    {
        Assert.IsNotNull(_progressionImage, $"[{gameObject.name}] Progression image is not assigned");
    }

    //private void Update()
    //{
    //    GetProgression();
    //}

    public void ResetProgression(int maxValue)
    {
        _currentValue = 0;
        _minValue = 0;
        _maxValue = maxValue;
        GetProgression();
    }

    public void SetProgression(ProgressionComponentModel progressionValue)
    {
        _minValue = progressionValue.MinValue;
        _maxValue = progressionValue.MaxValue;
        _currentValue = progressionValue.CurrentValue;
        GetProgression();
    }

    public void UpdateProgression(int currentValue)
    {
        _currentValue = currentValue;
        GetProgression();
    }

    private void GetProgression()
    {
        // Check if min value is greater or equal to max value
        if (_minValue >= _maxValue)
        {
            Debug.LogError($"[{gameObject.name}] Min value is greater or equal than max value");
            return;
        }

        // Avoid the current value exceed from min or max value
        if (_currentValue < _minValue)
        {
            _currentValue = _minValue;
        }
        if (_currentValue > _maxValue)
        {
            _currentValue = _maxValue;
        }
        
        // Calculate the fill amount based on the current, min, and max offset
        float currentOffset = _currentValue - _minValue;
        float maxOffset = _maxValue - _minValue;
        float fillAmount = currentOffset / maxOffset;
        _progressionImage.fillAmount = fillAmount;
    }

    public string GetName()
    {
        return _name;
    }
}
