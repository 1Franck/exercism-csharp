using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    Dictionary<string, int> students = new Dictionary<string, int>();
    
    public void Add(string student, int grade)
    {
        students.Add(student, grade);
    }

    public IEnumerable<string> Roster()
    {
        return 
            from student in students
            orderby student.Value, student.Key
            select student.Key;
    }

    public IEnumerable<string> Grade(int grade)
    {
         return 
            from student in students
            where student.Value >= grade
            orderby student.Value, student.Key
            select student.Key;
    }
}