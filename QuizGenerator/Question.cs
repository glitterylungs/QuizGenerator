using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator
{
    internal class Question
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string answerOne { get; set; }
        public string answerTwo { get; set; }
        public string answerThree { get; set; }
        public string answerFour { get; set; }
        public List<string> correctAnswers { get; set; }

        public Question(string name, string answerOne, string answerTwo, string answerThree, string answerFour, List<string> correctAnswers)
        {
            this.name = name;
            this.answerOne = answerOne;
            this.answerTwo = answerTwo;
            this.answerThree = answerThree;
            this.answerFour = answerFour;
            this.correctAnswers = correctAnswers;
        }

        public override string ToString()
        {
            return $"{name}\nA: {answerOne}\nB: {answerTwo}\nC: {answerThree}\nD: {answerFour}\nCorrect answers: {String.Join(", ", correctAnswers)}";
        }

    }
}
