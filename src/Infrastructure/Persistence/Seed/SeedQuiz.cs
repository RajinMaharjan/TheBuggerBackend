using Excallibur.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Excallibur.Infrastructure.Persistence.Seed
{
    public class SeedQuiz
    {
        public static void SeedQuestionOption(ModelBuilder modelBuilder)
        {
            List<Guid> questionIds = new List<Guid>();
            Guid createdById = Guid.NewGuid();
            List<string> questionNames = new List<string>() {
                "System testing should investigate",
                "Which is the non-functional testing",
                "Bug life cycle (1M)",
                "Which is not the software characteristics",
                "Which is not the testing objectives",
                "Which is not the fundamental test process ",
                "Which of the following are valid objectives for testing?\r\ni. To find defects.\r\nii. To gain confidence in the level of quality.\r\niii. To identify the cause of defects.\r\niv. To prevent defects.\r\n",
                "Which of the following requirements would be tested by a functional system",
                "Pick the best definition of quality",
                "One Key reason why developers have difficulty testing their own work is:",
                "During the software development process, at what point can the test process start?",
                "Acceptance test cases are based on what?",
                "Faults found by users are due to:",
                "What is the main reason for testing software before releasing it?",
                "Which of the following statements is not true",
                "Which of the following statements are true?",
                "When what is visible to end-users is a deviation from the specific or expected behavior, this is called:",
                "Regression testing should be performed: \r\nv) every week\r\nw) after the software has changed\r\nx) as often as possible\r\ny) when the environment has changed\r\nz) when the project manager says\r\n",
                "Non-functional system testing includes:",
                "What is the purpose of test completion criteria in a test plan:",
                "What statement about expected outcomes is FALSE:"
            };

            for (int i = 0; i < questionNames.Count; i++)
            {
                questionIds.Add(Guid.NewGuid());
            }

            for (int i = 0; i < questionNames.Count; i++)
            {
                AddQuestion(questionIds[i], questionNames[i], createdById, modelBuilder);
            }
            //Q1
            AddOption("Non-functional requirements only not Functional requirements", questionIds[0], createdById, false, modelBuilder);
            AddOption("Functional requirements only not non-functional requirements", questionIds[0], createdById, false, modelBuilder);
            AddOption("Non-functional requirements and Functional requirements", questionIds[0], createdById, true, modelBuilder);
            AddOption("Non-functional requirements or Functional requirements", questionIds[0], createdById, false, modelBuilder);
            //Q2
            AddOption("Performance testing", questionIds[1], createdById, true, modelBuilder);
            AddOption("Unit testing", questionIds[1], createdById, false, modelBuilder);
            AddOption("Regression testing", questionIds[1], createdById, false, modelBuilder);
            AddOption("Sanity testing", questionIds[1], createdById, false, modelBuilder);
            //Q3
            AddOption("Open, Assigned, Fixed, Closed", questionIds[2], createdById, true, modelBuilder);
            AddOption("Open, Fixed, Assigned, Closed", questionIds[2], createdById, false, modelBuilder);
            AddOption("Assigned, Open, Closed, Fixed", questionIds[2], createdById, false, modelBuilder);
            AddOption("Assigned, Open, Fixed, Closed", questionIds[2], createdById, false, modelBuilder);
            //Q4
            AddOption("Reliability", questionIds[3], createdById, false, modelBuilder);
            AddOption("Usability", questionIds[3], createdById, false, modelBuilder);
            AddOption("Scalability", questionIds[3], createdById, true, modelBuilder);
            AddOption("Maintainability", questionIds[3], createdById, false, modelBuilder);
            //Q5
            AddOption("Finding defects", questionIds[4], createdById, false, modelBuilder);
            AddOption("Gaining confidence about the level of quality and providing information", questionIds[4], createdById, false, modelBuilder);
            AddOption("Preventing defects", questionIds[4], createdById, false, modelBuilder);
            AddOption("Debugging defects", questionIds[4], createdById, true, modelBuilder);
            //Q6
            AddOption("Planning and control", questionIds[5], createdById, false, modelBuilder);
            AddOption("Test closure activities", questionIds[5], createdById, false, modelBuilder);
            AddOption("Analysis and design", questionIds[5], createdById, false, modelBuilder);
            AddOption("None", questionIds[5], createdById, true, modelBuilder);
            //Q7
            AddOption(" i,ii, and iii", questionIds[6], createdById, false, modelBuilder);
            AddOption("ii, iii and iv", questionIds[6], createdById, false, modelBuilder);
            AddOption("i, ii and iv", questionIds[6], createdById, true, modelBuilder);
            AddOption("i,iii and iv", questionIds[6], createdById, false, modelBuilder);
            //Q8
            AddOption(" The system must be able to perform its functions for an average of 23 hours 50 mins Per day", questionIds[7], createdById, false, modelBuilder);
            AddOption("The system must perform adequately for up to 30 users", questionIds[7], createdById, false, modelBuilder);
            AddOption("The system must allow a user to amend the address of a customer", questionIds[7], createdById, true, modelBuilder);
            AddOption("The system must allow 12,000 new customers per year", questionIds[7], createdById, false, modelBuilder);
            //Q9
            AddOption("Quality is job one", questionIds[8], createdById, false, modelBuilder);
            AddOption("Zero defects", questionIds[8], createdById, false, modelBuilder);
            AddOption("Conformance to requirements", questionIds[8], createdById, true, modelBuilder);
            AddOption("Work as designed", questionIds[8], createdById, false, modelBuilder);
            //Q10
            AddOption("Lack of technical documentation", questionIds[9], createdById, false, modelBuilder);
            AddOption("Lack of test tools on the market for developers", questionIds[9], createdById, false, modelBuilder);
            AddOption("Lack of training", questionIds[9], createdById, false, modelBuilder);
            AddOption("Lack of Objectivity", questionIds[9], createdById, true, modelBuilder);
            //Q11
            AddOption("When the code is complete", questionIds[10], createdById, false, modelBuilder);
            AddOption("When the design is complete", questionIds[10], createdById, false, modelBuilder);
            AddOption("When the software requirements have been approved", questionIds[10], createdById, true, modelBuilder);
            AddOption("When the first code module is ready for unit testing", questionIds[10], createdById, false, modelBuilder);
            //Q12
            AddOption("Requirements", questionIds[11], createdById, true, modelBuilder);
            AddOption("Design", questionIds[11], createdById, false, modelBuilder);
            AddOption("Code", questionIds[11], createdById, false, modelBuilder);
            AddOption("Decision table", questionIds[11], createdById, false, modelBuilder);
            //Q13
            AddOption("Poor quality software", questionIds[12], createdById, false, modelBuilder);
            AddOption("Poor software and poor testing", questionIds[12], createdById, true, modelBuilder);
            AddOption("Bad luck", questionIds[12], createdById, false, modelBuilder);
            AddOption("Insufficient time for testing", questionIds[12], createdById, false, modelBuilder);
            //Q14
            AddOption("to show that system will work after release", questionIds[13], createdById, false, modelBuilder);
            AddOption("to decide when the software is of sufficient quality to release", questionIds[13], createdById, false, modelBuilder);
            AddOption("to find as many bugs as possible before release", questionIds[13], createdById, false, modelBuilder);
            AddOption("to give information for a risk-based decision about release", questionIds[13], createdById, true, modelBuilder);
            //Q15
            AddOption("performance testing can be done during unit testing as well as during the testing of whole system", questionIds[14], createdById, false, modelBuilder);
            AddOption("The acceptance test does not necessarily include a regression test", questionIds[14], createdById, false, modelBuilder);
            AddOption("Verification activities should not involve testers (reviews, inspections etc)", questionIds[14], createdById, true, modelBuilder);
            AddOption("Test environments should be as similar to production environments as possible", questionIds[14], createdById, false, modelBuilder);
            //Q16
            AddOption("Faults in program specifications are the most expensive to fix", questionIds[15], createdById, false, modelBuilder);
            AddOption("Faults in code are the most expensive to fix", questionIds[15], createdById, false, modelBuilder);
            AddOption("Faults in requirements are the most expensive to fix", questionIds[15], createdById, true, modelBuilder);
            AddOption("Faults in designs are the most expensive to fix", questionIds[15], createdById, false, modelBuilder);
            //Q17
            AddOption("an error", questionIds[16], createdById, false, modelBuilder);
            AddOption("a fault", questionIds[16], createdById, false, modelBuilder);
            AddOption("a failure", questionIds[16], createdById, true, modelBuilder);
            AddOption("a defect", questionIds[16], createdById, false, modelBuilder);
            AddOption("a mistake", questionIds[16], createdById, false, modelBuilder);
            //Q18
            AddOption("v & w are true, x – z are false", questionIds[17], createdById, false, modelBuilder);
            AddOption("w, x & y are true, v & z are false", questionIds[17], createdById, false, modelBuilder);
            AddOption("w & y are true, v, x & z are false", questionIds[17], createdById, true, modelBuilder);
            AddOption("w is true, v, x y and z are false", questionIds[17], createdById, false, modelBuilder);
            AddOption("all of the above are true", questionIds[17], createdById, false, modelBuilder);
            //Q19
            AddOption("testing to see where the system does not function properly", questionIds[18], createdById, false, modelBuilder);
            AddOption("testing quality attributes of the system including performance and usability", questionIds[18], createdById, true, modelBuilder);
            AddOption("testing a system feature using only the software required for that action", questionIds[18], createdById, false, modelBuilder);
            AddOption("testing a system feature using only the software required for that function", questionIds[18], createdById, false, modelBuilder);
            AddOption("testing for functions that should not exist", questionIds[18], createdById, false, modelBuilder);
            //Q20
            AddOption("to know when a specific test has finished its execution", questionIds[19], createdById, false, modelBuilder);
            AddOption("to ensure that the test case specification is complete", questionIds[19], createdById, false, modelBuilder);
            AddOption("to set the criteria used in generating test inputs", questionIds[19], createdById, false, modelBuilder);
            AddOption("to know when test planning is complete", questionIds[19], createdById, false, modelBuilder);
            AddOption("to plan when to stop testing", questionIds[19], createdById, true, modelBuilder);
            //Q21
            AddOption("expected outcomes are defined by the software’s behavior", questionIds[20], createdById, true, modelBuilder);
            AddOption("expected outcomes are derived from a specification, not from the code", questionIds[20], createdById, false, modelBuilder);
            AddOption("expected outcomes include outputs to a screen and changes to files and databases", questionIds[20], createdById, false, modelBuilder);
            AddOption("expected outcomes should be predicted before a test is run", questionIds[20], createdById, false, modelBuilder);
            AddOption("expected outcomes may include timing constraints such as response times", questionIds[20], createdById, false, modelBuilder);


        }
        private static void AddQuestion(Guid id, string name, Guid createdById, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizQuestion>().HasData(
                new QuizQuestion
                {
                    Id = id,
                    Name = name,
                    CreatedAt = DateTime.Now,
                    CreatedBy = createdById,

                });
        }
        private static void AddOption(string name, Guid questionId, Guid createdById, bool isCorrect, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizOption>().HasData(
                new QuizOption
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    QuestionId = questionId,
                    CreatedAt = DateTime.Now,
                    CreatedBy = createdById,
                    IsCorrect = isCorrect

                });
        }
    }
}
