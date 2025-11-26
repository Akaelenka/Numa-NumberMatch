using UnityEngine;
using System;  
using TMPro;
using NumaModels;
using UnityEngine.Assertions;

//[ExecuteInEditMode]
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


    private void Awake()
    {
        Assert.IsNotNull(_quoteText, $"[{gameObject.name}] Quote Text is not assigned");
        Assert.IsNotNull(_quoteDB, $"[{gameObject.name}] QuoteDB is not assigned");
        Assert.AreNotEqual(0, _quoteDB.Length, $"[{gameObject.name}] QuoteDB are empty");
    }

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
