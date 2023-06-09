﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_client.Models
{
    public class Answer
    {
        private string _content;
        private bool _correct;


        public Answer(string content, bool correct)
        {
            _content = content;
            _correct = correct;
        }

        public Answer(string content, string correct)
        {
            _content = content;
            if (correct == "y") _correct = true;
            else _correct = false;
        }

        public string Content { get => _content; set => _content = value; }
        public bool Correct { get => _correct; set => _correct = value; }

    }

}
