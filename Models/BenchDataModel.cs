using SmolovJrBench.Custom_Model_Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmolovJrBench.Models
{
    public class BenchDataModel
    {
        [PositiveDouble("You must enter a valid number")]
        //[RegularExpression(@"^\d+(\.\d{1}?)$", ErrorMessage = "Otillåtet nummer format")]
        public string MaxBenchWeight { get; set; }

        [PositiveDouble("You must enter a valid number")]
        //[RegularExpression(@"^\d+\.\d{1}$", ErrorMessage = "Otillåtet nummer format")]
        public string Increment { get; set; }
        public bool HasErrors { get; set; }
        public IEnumerable<string> ValidationErrors { get; set; }
    }
}
