using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace QuestionAndAnswers.Models
{
    public class QA_DataModel
    {

        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public QA_DataModel()
        {

        }
    }
}
