using System.ComponentModel.DataAnnotations;

namespace Student2.API.Data
{
    public class AssessmentCategory
    {
       [Key] public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int CuttoffMarks { get; set; }
    }
}
