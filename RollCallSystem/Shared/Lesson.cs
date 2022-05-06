using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollCallSystem.Shared
{
    public class Lesson
    {
        public int id;
        public string subjectName;
        public DateTime startTime;
        public int? code;
        public DateTime? codeTime;
        public string campusName;
        public string teacherName;

        public Lesson(int id, string subjectName, DateTime startTime, int? code, DateTime? codeTime, string campusName, string teacherName)
        {
            this.id = id;
            this.subjectName = subjectName;
            this.startTime = startTime;
            this.code = code;
            this.codeTime = codeTime;
            this.campusName = campusName;
            this.teacherName = teacherName;
        }

        public Lesson() { }
    }
}
