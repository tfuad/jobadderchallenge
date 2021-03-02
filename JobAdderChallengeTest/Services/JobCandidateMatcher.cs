using System;
using System.Collections.Generic;
using System.Linq;
using JobAdderChallenge.Core.Models;
using JobAdderChallenge.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobAdderChallengeTest.Services
{
    [TestClass]
    public class JobCandidateMatcher
    {
        [TestMethod]
        public void SkillStrengthMatcher_Calculate_PerfectScore()
        {
            IJobCandidateMatcherService matcherService = new JobCandidateMatcherService();
            matcherService.SetMatcherMethod(new SkillStrengthMatcher());


            var job = new Job
            {
                JobId = 5,
                Name = "Role",
                Company = "Test Company 5",
                Skills = "a, b, c, d, e, f, g, h, i, j"
            };

            var candidate1 = new Candidate
            {
                CandidateId = 1,
                Name = "Candidate 1",
                SkillTags = "a, b, c, d, e, f, g, h, i, j"
            };

            var results = matcherService.GetJobCandidateScores(job, new List<Candidate> { candidate1 }).ToList();

            Assert.IsNotNull(results);
            Assert.AreEqual(1, results.Count);

            var result = results.First();
            Assert.IsNotNull(result);

            Assert.IsTrue(result.Score > 0.95d, "A stronger score was expected for this set (scored below 0.95)");

            // Test candidate results match expectations
            Assert.AreEqual(1, result.Candidate.CandidateId);
            Assert.AreEqual(10, result.Candidate.CandidateSkills);
            // skills should also perfectly match
            Assert.AreEqual(10, result.Job.JobSkills.Intersect(result.Candidate.CandidateSkills).Count());

            // Ensure job information still lines up as expected.
            Assert.AreEqual(5, result.Job.JobId);
            Assert.AreEqual("Role", result.Job.Name);
            Assert.AreEqual("Test Company 5", result.Job.Company);
            Assert.AreEqual(10, result.Job.JobSkills.Length);
            Assert.AreEqual("E", result.Job.JobSkills.First());
        }

        [TestMethod]
        public void SkillStrengthMatcher_Calculate_PerfectMatch_VaryingStrength()
        {
            // Candiate 2 is more versatile however candidate 1 has a stronger skill set for the required task
            // Candidate 2's strongest skill only applies to the least relevant skill required by the job.

            IJobCandidateMatcherService matcherService = new JobCandidateMatcherService();
            matcherService.SetMatcherMethod(new SkillStrengthMatcher());

            var job = new Job
            {
                JobId = 5,
                Name = "Role",
                Company = "Test Company 5",
                Skills = "a, b, c, d, e, f, g, h, i, j"
            };

            var candidate1 = new Candidate
            {
                CandidateId = 1,
                Name = "Candidate 1",
                SkillTags = "a, b, c, j"
            };

            var candidate2 = new Candidate
            {
                CandidateId = 2,
                Name = "Candidate 2",
                SkillTags = "j, i, h, g, f, e, d, c, b, a"
            };

            var results = matcherService.GetJobCandidateScores(job, new List<Candidate> { candidate1, candidate2 }).ToList();

            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count);

            var firstPlace = results[0];
            var secondPlace = results[1];
            Assert.IsNotNull(firstPlace);
            Assert.IsNotNull(secondPlace);


            Assert.AreEqual(candidate1, firstPlace.Candidate);
            Assert.AreEqual(candidate2, secondPlace.Candidate);
            Assert.IsTrue(firstPlace.Score > secondPlace.Score, "Candidate1 should have scored higher than Candidate2");
        }

        [TestMethod]
        public void SkillStrengthMatcher_Calculate_PerfectMatch_NotPunishedForExtraIrrelevantSkills()
        {
            // Candiate 1 will have a slight edge over candidate 2 by having 1 extra least-relevant skill over candidate 2
            // Candidate 1 will also have several unrelated skills
            // The goal is to ensure Candidate 1 still wins and isn't being punished for those extra skills

            IJobCandidateMatcherService matcherService = new JobCandidateMatcherService();
            matcherService.SetMatcherMethod(new SkillStrengthMatcher());

            var job = new Job
            {
                JobId = 5,
                Name = "Role",
                Company = "Test Company 5",
                Skills = "a, b, c, d, e, f, g, h, i, j"
            };

            var candidate1 = new Candidate
            {
                CandidateId = 1,
                Name = "Candidate 1",
                SkillTags = "a, b, c, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z"
            };

            var candidate2 = new Candidate
            {
                CandidateId = 2,
                Name = "Candidate 2",
                SkillTags = "a, b, c, j"
            };

            var results = matcherService.GetJobCandidateScores(job, new List<Candidate> { candidate1, candidate2 }).ToList();

            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count);

            var firstPlace = results[0];
            var secondPlace = results[1];
            Assert.IsNotNull(firstPlace);
            Assert.IsNotNull(secondPlace);


            Assert.AreEqual(candidate1, firstPlace.Candidate);
            Assert.AreEqual(candidate2, secondPlace.Candidate);
            Assert.IsTrue(firstPlace.Score > secondPlace.Score, "Candidate1 should have scored higher than candidate 2");
        }

        // TODO: extra tests
        // A candidate with a strong-relevant skill should outperform an candidate with strong-less-relevant skills or weak-relevant-skills
        // A candidate shouldn't be able to dominate a job simply by having every skill under the sun


    }
}
