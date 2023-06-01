using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_client.Models
{
    public class Question
    {
        private int _id;
        private string _question;
        private Answer answer1;
        private Answer answer2;
        private Answer answer3;
        private Answer answer4;
        private bool userAnswer1;
        private bool userAnswer2;
        private bool userAnswer3;
        private bool userAnswer4;



        public string question { get => _question; set => _question = value; }
        public Answer Answer1 { get => answer1; set => answer1 = value; }
        public Answer Answer2 { get => answer2; set => answer2 = value; }
        public Answer Answer3 { get => answer3; set => answer3 = value; }
        public Answer Answer4 { get => answer4; set => answer4 = value; }
        public bool UserAnswer1 { get => userAnswer1; set => userAnswer1 = value; }
        public bool UserAnswer2 { get => userAnswer2; set => userAnswer2 = value; }
        public bool UserAnswer3 { get => userAnswer3; set => userAnswer3 = value; }
        public bool UserAnswer4 { get => userAnswer4; set => userAnswer4 = value; }

        public Question(string question, Answer answer1, Answer answer2, Answer answer3, Answer answer4)
        {
            _question = question;
            Answer1 = answer1;
            Answer2 = answer2;
            Answer3 = answer3;
            Answer4 = answer4;

        }

        public void saveAnswers(bool UserAnswer1, bool UserAnswer2, bool UserAnswer3, bool UserAnswer4)
        {
            userAnswer1 = UserAnswer1;
            userAnswer2 = UserAnswer2;
            userAnswer3 = UserAnswer3;
            userAnswer4 = UserAnswer4;
        }

        public bool Correct()
        {
            if (answer1.Correct != userAnswer1) return false;
            if (answer2.Correct != userAnswer2) return false;
            if (answer3.Correct != userAnswer3) return false;
            if (answer4.Correct != userAnswer4) return false;
            return true;
        }

    }

}
