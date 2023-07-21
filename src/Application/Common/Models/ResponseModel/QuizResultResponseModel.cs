namespace Excallibur.Application.Common.Models.ResponseModel
{
    public class QuizResultResponseModel
    {
        public int Correct { get; set; }
        public int Incorrect { get; set; }
        public int Marks { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
