using UnityEngine;
using System.Collections.Generic;

namespace NumaModels
{
    [CreateAssetMenu(fileName = "QuoteDB", menuName = "Scriptable Objects/Numa/QuoteDB")]
    public class QuoteModel : ScriptableObject
    {
        public string Name;
        public string Quote;
    }
}
