using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using React_Asp.Model;
using System.ComponentModel.DataAnnotations;
namespace React_Asp.Model
{
  
    public class Quest
    {
        public int QuestID { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public int Limit { get; set; }
        public DateTime Created { get; set; }
        [DisplayFormat(DataFormatString ="mm/dd/yyyy")]
        public DateTime Enddate { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public List<User> Userdonors { get; set; }

        public string State { get; set; }
    }

}