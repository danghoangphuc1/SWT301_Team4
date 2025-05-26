using System.Text;
using GenderHealthcareSimple.Models;
using GenderHealthcareSimple.Services;

Console.OutputEncoding = Encoding.UTF8;

var manager = new ServiceManager();
manager.AddService(new Service { Name = "Xét nghiệm máu", Price = 150 });
manager.AddService(new Service { Name = "HIV", Price = 200 });

Console.WriteLine($"Tổng chi phí: {manager.GetTotalCost()}");
Console.WriteLine($"Dịch vụ đắt nhất: {manager.GetMostExpensive()?.Name}");
