using UnityEngine;
using System.Collections.Generic;

namespace NumaModels
{
    [CreateAssetMenu(fileName = "QuoteDB", menuName = "ScriptableObjects/Numa/QuoteDB")]
    public class QuoteModel : ScriptableObject
    {
        public string Name;
        public string Quote;
    }
}
