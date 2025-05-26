using System;
using StudentManagement.tools;

class Program
{
    static StudentService service = new StudentService();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\n==== QUẢN LÝ SINH VIÊN ====");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Sửa thông tin sinh viên");
            Console.WriteLine("3. Xóa sinh viên");
            Console.WriteLine("4. Tìm sinh viên theo mã hoặc tên");
            Console.WriteLine("5. Tính điểm trung bình toàn lớp");
            Console.WriteLine("6. Hiển thị tất cả sinh viên");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    UpdateStudent();
                    break;
                case "3":
                    DeleteStudent();
                    break;
                case "4":
                    SearchStudent();
                    break;
                case "5":
                    CalculateAverageGPA();
                    break;
                case "6":
                    ShowAllStudents();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("❌ Lựa chọn không hợp lệ.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        string id = InputTools.InputStudentId();
        string name = InputTools.InputName();
        int age = InputTools.InputAge();
        double gpa = InputTools.InputGPA();

        try
        {
            service.AddStudent(new Student { Id = id, Name = name, Age = age, GPA = gpa });
            Console.WriteLine("✅ Thêm sinh viên thành công.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Lỗi: {ex.Message}");
        }
    }

    static void UpdateStudent()
    {
        string id = InputTools.InputStudentId();
        var existing = service.GetStudentById(id);
        if (existing == null)
        {
            Console.WriteLine("❌ Không tìm thấy sinh viên.");
            return;
        }

        Console.WriteLine("👉 Nhập thông tin mới:");
        string name = InputTools.InputName();
        int age = InputTools.InputAge();
        double gpa = InputTools.InputGPA();

        try
        {
            service.UpdateStudent(new Student { Id = id, Name = name, Age = age, GPA = gpa });
            Console.WriteLine("✅ Cập nhật thành công.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Lỗi: {ex.Message}");
        }
    }

    static void DeleteStudent()
    {
        string id = InputTools.InputStudentId();
        bool result = service.RemoveStudent(id);
        if (result)
            Console.WriteLine("✅ Xóa thành công.");
        else
            Console.WriteLine("❌ Không tìm thấy sinh viên.");
    }

    static void SearchStudent()
    {
        Console.Write("Nhập mã hoặc tên cần tìm: ");
        string keyword = Console.ReadLine();
        var result = service.FindStudentsByName(keyword);
        if (result.Count == 0)
            Console.WriteLine("❌ Không tìm thấy sinh viên.");
        else
        {
            Console.WriteLine("📋 Kết quả tìm kiếm:");
            foreach (var s in result)
            {
                Console.WriteLine($"{s.Id} - {s.Name}, Tuổi: {s.Age}, GPA: {s.GPA}");
            }
        }
    }

    static void CalculateAverageGPA()
    {
        double avg = service.CalculateAverageGPA();
        Console.WriteLine($"📊 Điểm trung bình toàn lớp: {avg:F2}");
    }

    static void ShowAllStudents()
    {
        var list = service.FindStudentsByName(""); // trả về tất cả
        if (list.Count == 0)
        {
            Console.WriteLine("❗ Không có sinh viên nào.");
            return;
        }

        Console.WriteLine("📚 Danh sách sinh viên:");
        foreach (var s in list)
        {
            Console.WriteLine($"{s.Id} - {s.Name}, Tuổi: {s.Age}, GPA: {s.GPA}");
        }
    }
}
