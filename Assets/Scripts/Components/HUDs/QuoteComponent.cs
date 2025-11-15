using UnityEngine;
using System;  
using TMPro;
using NumaModels;

[ExecuteInEditMode]
public class QuoteComponent : MonoBehaviour
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private float _delay = 0.1f;
    [SerializeField]
    private QuoteModel[] _quoteDB;
    [SerializeField]
    private TMP_Text _quoteText;

    private DateTime _currentDate = DateTime.Now;
    private int _currentIndex;

    private void Update()
    {
        TimeSpan minutesDifference = DateTime.Now - _currentDate;
        if (minutesDifference.TotalMinutes >= _delay)
        {
            _currentDate = DateTime.Now;
            GetRandomQuote();
        }
    }

    private void GetRandomQuote()
    {
        // Check if the QuoteDB is null or empty
        if (_quoteDB == null)
        {
            Debug.LogError($"[{gameObject.name}] QuoteDB is not assigned");
            return;
        }
        if (_quoteDB.Length == 0)
        {
            Debug.LogError($"[{gameObject.name}] QuoteDB has no quotes");
            return;
        }

        // Add index or restart to zero
        _currentIndex += 1;
        if (_currentIndex >= _quoteDB.Length)
        {
            _currentIndex = 0;
        }

        _quoteText.text = _quoteDB[_currentIndex].Quote;
        Debug.Log($"[{gameObject.name}] Start random the quote with index: " + _currentIndex);
    }
}
