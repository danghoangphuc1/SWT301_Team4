using NUnit.Framework;
using GenderHealthcareSimple.Models;
using GenderHealthcareSimple.Services;

namespace GenderHealthcareTests;

public class Tests
{
    [Test]
    public void TestTotalCost()
    {
        var manager = new ServiceManager();
        manager.AddService(new Service { Name = "A", Price = 100 });
        manager.AddService(new Service { Name = "B", Price = 200 });

        Assert.That((int)manager.GetTotalCost(), Is.EqualTo(300));
    }

    [Test]
    public void TestMostExpensive()
    {
        var manager = new ServiceManager();
        manager.AddService(new Service { Name = "X", Price = 50 });
        manager.AddService(new Service { Name = "Y", Price = 150 });

        Assert.That(manager.GetMostExpensive().Name, Is.EqualTo("Y"));
    }
}
