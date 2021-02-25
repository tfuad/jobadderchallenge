using JobAdderChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderChallenge.Services
{
    public interface IJobCandidateMatcherService
    {
        void SetMatcherMethod(IMatcherMethod method);
        IEnumerable<JobCandidate> GetJobCandidateScores(Job job, List<Candidate> candidates);
    }

    public interface IMatcherMethod
    {
        double Calculate(Job job, Candidate candidate);
    }

    public class JobCandidateMatcherService : IJobCandidateMatcherService
    {
        IMatcherMethod _matcherMethod;
        public JobCandidateMatcherService()
        {
            _matcherMethod = new SkillStrengthMatcher();
        }

        public void SetMatcherMethod(IMatcherMethod method)
        {
            _matcherMethod = method;
        }
        public IEnumerable<JobCandidate> GetJobCandidateScores(Job job, List<Candidate> candidates)
        {
            return candidates.Select(candidate => Calculate(job, candidate));
        }

        private JobCandidate Calculate(Job job, Candidate candidate)
        {
            double score = _matcherMethod.Calculate(job, candidate);
            return new JobCandidate(job, candidate, score);
        }
    }

    public class SkillStrengthMatcher : IMatcherMethod
    {
        public double Calculate(Job job, Candidate candidate)
        {
            double score = 0;
            for (var index = 0; index < candidate.CandidateSkills.Length; index++)
            {
                var candidateSkill = candidate.CandidateSkills[index];

                var jobSkillIndex = Array.IndexOf(job.JobSkills, candidateSkill);
                if (jobSkillIndex >= 0)
                {
                    // 1/(2^jobSkillIndex) // this gives a weight value starting from 1 and moving towards 0
                    // this is one approach that allows us to reduce the impact lower skills have
                    // we perform the same calculation on the candidates skill and multiply the values together
                    // this new computed value gives a relative strength between the two skills
                    // and helps to summarize the candidate/job skill to a single score value
                    // due to the diminishing nature of this algorithm the maximum score value will be 4/3 (1.333)
                    // so i'm normalizing the score by multiplying the final result by 4/3
                    // this could be done directly after calculating each score but it's more efficient to do it at the end.
                    score += (1d / Math.Pow(2, jobSkillIndex)) * (1d / Math.Pow(2, index));
                }
            }
            return score / (4d / 3d);
        }
    }
}