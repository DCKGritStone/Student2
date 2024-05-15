using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student2.API.Data
{
    public class AssessmentResult
    {
        [Key] public int AssessmentId { get; set; }
        public int CandidateId { get; set; }
        [ForeignKey("CandidateId")]

        public Candidate? Candidate { get; set; }


        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        public AssessmentCategory? AssessmentCategory { get; set; }
        public int Score { get; set; }

       
    }
  
    }
