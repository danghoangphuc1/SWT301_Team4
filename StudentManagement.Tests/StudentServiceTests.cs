using NUnit.Framework;
using System;

[TestFixture]
public class StudentServiceTests
{
    private StudentService service;

    [SetUp]
    public void Setup()
    {
        service = new StudentService();
    }

    [Test]
    public void AddStudent_ShouldAdd_WhenNewStudent()
    {
        var student = new Student { Id = "1", Name = "Phuc", Age = 20, GPA = 3.5 };
        service.AddStudent(student);
        var result = service.GetStudentById("1");
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void AddStudent_ShouldThrow_WhenDuplicateId()
    {
        var student1 = new Student { Id = "1", Name = "Phuc", Age = 20, GPA = 3.5 };
        var student2 = new Student { Id = "1", Name = "Long", Age = 22, GPA = 3.8 };
        service.AddStudent(student1);

        var ex = Assert.Throws<Exception>(() => service.AddStudent(student2));
        Assert.That(ex.Message, Is.EqualTo("Student with the same ID already exists."));
    }

    [Test]
    public void RemoveStudent_ShouldReturnTrue_WhenStudentExists()
    {
        var student = new Student { Id = "1", Name = "Phuc", Age = 20, GPA = 3.5 };
        service.AddStudent(student);
        bool removed = service.RemoveStudent("1");
        Assert.That(removed, Is.True);
    }

    [Test]
    public void CalculateAverageGPA_ShouldReturnCorrectAverage()
    {
        service.AddStudent(new Student { Id = "1", Name = "A", Age = 20, GPA = 3.0 });
        service.AddStudent(new Student { Id = "2", Name = "B", Age = 22, GPA = 4.0 });
        double average = service.CalculateAverageGPA();

        Assert.That(average, Is.EqualTo(3.5).Within(0.0001));
    }

    [Test]
    public void CalculateAverageGPA_ShouldReturnZero_WhenNoStudents()
    {
        double average = service.CalculateAverageGPA();
        Assert.That(average, Is.EqualTo(0.0));
    }

    [Test]
    public void GetStudentById_ShouldReturnNull_WhenStudentNotFound()
    {
        var student = service.GetStudentById("nonexistent");
        Assert.That(student, Is.Null);
    }
}
