using System;
using System.Text.RegularExpressions;

namespace StudentManagement.tools
{
    public static class InputTools
    {
        public static string InputStudentId()
        {
            while (true)
            {
                Console.Write("Nhập mã sinh viên (định dạng Sxxx, ví dụ: S001): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("❌ Mã sinh viên không được để trống.");
                else if (!Regex.IsMatch(input, @"^S\d{3}$"))
                    Console.WriteLine("❌ Mã sinh viên phải theo định dạng Sxxx (ví dụ: S001).");
                else
                    return input;
            }
        }

        public static string InputName()
        {
            while (true)
            {
                Console.Write("Nhập tên sinh viên: ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    return name.Trim();
                Console.WriteLine("❌ Tên không được để trống.");
            }
        }

        public static int InputAge()
        {
            while (true)
            {
                Console.Write("Nhập tuổi (0–120): ");
                if (int.TryParse(Console.ReadLine(), out int age) && age >= 0 && age <= 120)
                    return age;
                Console.WriteLine("❌ Tuổi không hợp lệ. Vui lòng nhập số nguyên từ 0 đến 120.");
            }
        }

        public static double InputGPA()
        {
            while (true)
            {
                Console.Write("Nhập GPA (0.0–4.0): ");
                if (double.TryParse(Console.ReadLine(), out double gpa) && gpa >= 0.0 && gpa <= 4.0)
                    return gpa;
                Console.WriteLine("❌ GPA không hợp lệ. Vui lòng nhập số thực từ 0.0 đến 4.0.");
            }
        }
    }
}
