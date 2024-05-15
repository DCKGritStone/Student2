using System.ComponentModel.DataAnnotations;

namespace Student2.API.Data
{
    public class Candidate
    {
        [Key] public int CandidateId { get; set; }
        public string? CandidateName { get; set;}

        
    }
}
