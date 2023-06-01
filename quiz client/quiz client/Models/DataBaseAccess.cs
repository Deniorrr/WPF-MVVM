using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using quiz_client.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;

namespace quiz_client.Models
{
    class DataBaseAccess
    {

        static SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\BazaQuiz.db; Version=3");


        public static void ReadQuizes(ObservableCollection<QuizListViewModel> quizes)
        {
            conn.Open();
            SQLiteDataReader datareader;
            SQLiteCommand command;
            command = conn.CreateCommand();

            command.CommandText =
            @"
                SELECT * FROM quizes
            ";
            datareader = command.ExecuteReader();
            while(datareader.Read()) {
                int quizId = datareader.GetInt32(0);
                string quizName = datareader.GetString(1);
                quizes.Add(new QuizListViewModel(quizId, quizName));
            }
            conn.Close();
        }

        public static Quiz ReadQuizContent(int quizId, string quizName)
        {
            conn.Open();
            SQLiteDataReader datareader;
            SQLiteCommand command;
            command = conn.CreateCommand();
            Quiz quiz = new Quiz(quizId, quizName);

            command.CommandText =
            @" SELECT * FROM questions JOIN answers ON questions.id = answers.question_id WHERE questions.quiz_id = " + quizId.ToString();

            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                string question_content = Encrypter.Decrypt(datareader.GetString(2));
                string decrypted_answer = Encrypter.Decrypt(datareader.GetString(5));
                Answer answer1 = new Answer(decrypted_answer, Encrypter.DecryptAnswerBool(decrypted_answer, datareader.GetString(6)));
                datareader.Read();
                decrypted_answer = Encrypter.Decrypt(datareader.GetString(5));
                Answer answer2 = new Answer(decrypted_answer, Encrypter.DecryptAnswerBool(decrypted_answer, datareader.GetString(6)));
                datareader.Read();
                decrypted_answer = Encrypter.Decrypt(datareader.GetString(5));
                Answer answer3 = new Answer(decrypted_answer, Encrypter.DecryptAnswerBool(decrypted_answer, datareader.GetString(6)));
                datareader.Read();
                decrypted_answer = Encrypter.Decrypt(datareader.GetString(5));
                Answer answer4 = new Answer(decrypted_answer, Encrypter.DecryptAnswerBool(decrypted_answer, datareader.GetString(6)));

                //string question_content = datareader.GetString(2);
                //Answer answer1 = new Answer(datareader.GetString(5), datareader.GetString(6));
                //datareader.Read();
                //Answer answer2 = new Answer(datareader.GetString(5), datareader.GetString(6));
                //datareader.Read();
                //Answer answer3 = new Answer(datareader.GetString(5), datareader.GetString(6));
                //datareader.Read();
                //Answer answer4 = new Answer(datareader.GetString(5), datareader.GetString(6));

                quiz.addQuestion(new Question(question_content, answer1, answer2, answer3, answer4));
            }

            conn.Close();
            
            return quiz;
        }
    }
}
