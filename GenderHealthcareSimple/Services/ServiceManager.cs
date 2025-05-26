using GenderHealthcareSimple.Models;

namespace GenderHealthcareSimple.Services;

public class ServiceManager
{
    public List<Service> Services { get; set; } = new();

    public void AddService(Service service) => Services.Add(service);

    public double GetTotalCost() => Services.Sum(s => s.Price);

    public Service GetMostExpensive() =>
        Services.OrderByDescending(s => s.Price).FirstOrDefault();
}
