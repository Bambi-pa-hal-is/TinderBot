using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderML
{
    public class SwipePrediction
    {
        [ColumnName("Score")]
        public bool SwipeRight { get; set; }
    }
}
