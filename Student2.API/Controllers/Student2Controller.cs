using Microsoft.AspNetCore.Mvc;
using Student2.API.Data;
using Student2.API.DataContext;
using Student2.API.DTO;

namespace Student2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student2Controller : ControllerBase
    {
        private readonly Student2DbContext dbContext;

        public Student2Controller(Student2DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllCandidateWithHighScores()
        {
            /*var result = from cand in dbContext.Candidates
                         join res in dbContext.Results on cand.CandidateId equals res.CandidateId 
                         join cate in dbContext.Categories on res.CategoryId equals cate.CategoryId
                         where res.Score > cate.CuttoffMarks

                         select new 
                         {
                             Name = cand.CandidateName,
                             AssessementDetails = new AssessmentResult
                             {
                                 AssessmentId = cand.CandidateId,
                                 CategoryId = cand.CandidateId,
                             }
                         };*/


            /*var candidatesWithHighScores = from res in dbContext.Results
                                           join cand in dbContext.Candidates on res.CandidateId equals cand.CandidateId
                                           join cate in dbContext.Categories on res.CategoryId equals cate.CategoryId
                                           where res.Score > cate.CuttoffMarks
                                           select new
                                           {
                                               candidateId = g,
                                               AssessmentDetails = g.Select(cand => new Candidate
                                               {

                                               })
                                           };*/

          /*  var result = from cand in dbContext.Candidates
                         join res in dbContext.Results on cand.CandidateId equals res.CandidateId 
                         join cate in dbContext.Categories on res.CategoryId equals cate.CategoryId 
                         where res.Score > cate.CuttoffMarks
                         select new
                         {
                             Name=cand.CandidateName,
                             AssessmentDetails=  new AssessmentResultDto
                             {

                             }
                         };*/

            var candidates = dbContext.Candidates;
            var assessmentResults = dbContext.Results;
            var categories = dbContext.Categories;

            var result = candidates.Select(candidate => new
            {
                candidateName = candidate.CandidateName,
                assessments = assessmentResults.Where(ar => ar.CandidateId == candidate.CandidateId)
                                   .GroupBy(ar => ar.CategoryId)
                                   .Select(group => new
                                   {
                                       assessmentIds = group.Where(ar => ar.Score > categories.First(c => c.CategoryId == ar.CategoryId).CuttoffMarks)
                                                            .Select(ar => ar.AssessmentId)
                                                            .ToList(),
                                       categories = group.Where(ar => ar.Score > categories.First(c => c.CategoryId == ar.CategoryId).CuttoffMarks)
                                                        .Select(ar => new
                                                        {
                                                            Category = categories.First(c => c.CategoryId == ar.CategoryId).CategoryName
                                                        })
                                                        .ToList()
                                   })
                                   .ToList()
            })
.ToList();

            /* var result = candidates.Select(candidate => new
             {
                 candidateName = candidate.CandidateName,
                 assessments = assessmentResults.Where(ar => ar.CandidateId == candidate.CandidateId)
                                            .GroupBy(ar => ar.CategoryId)
                                            .Select(group => new
                                            {
                                                assessmentIds = group.Select(ar => ar.AssessmentId),
                                                categories = group.Select(ar => new
                                                {
                                                    Category = categories.First(c => c.CategoryId == ar.CategoryId).CategoryName
                                                }).ToList()
                                            }).ToList()
             }).ToList();*/


            return Ok(result);
        }
    }
}


