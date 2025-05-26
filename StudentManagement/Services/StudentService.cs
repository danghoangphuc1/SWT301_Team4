using System.Collections.Generic;
using System.Linq;

public class StudentService
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        if (students.Any(s => s.Id == student.Id))
            throw new System.Exception("Student with the same ID already exists.");
        students.Add(student);
    }

    public bool RemoveStudent(string id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student == null) return false;
        students.Remove(student);
        return true;
    }

    public Student GetStudentById(string id)
    {
        return students.FirstOrDefault(s => s.Id == id);
    }

    public List<Student> FindStudentsByName(string name)
    {
        return students.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList();
    }

    public double CalculateAverageGPA()
    {
        if (students.Count == 0) return 0;
        return students.Average(s => s.GPA);
    }

    public void UpdateStudent(Student updatedStudent)
    {
        var student = students.FirstOrDefault(s => s.Id == updatedStudent.Id);
        if (student == null)
            throw new System.Exception("Student not found.");

        student.Name = updatedStudent.Name;
        student.Age = updatedStudent.Age;
        student.GPA = updatedStudent.GPA;
    }
}
