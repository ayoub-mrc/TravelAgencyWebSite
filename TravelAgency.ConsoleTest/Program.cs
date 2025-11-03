using System;
using System.Linq;
using TravelAgency.Data;

class Program
{
    static void Main()
    {
        // إنشاء DbContext باستخدام Factory
        using var context = new TravelAgencyContextFactory().CreateDbContext(Array.Empty<string>());

        // اختبار جدول العملاء
        try
        {
            var customersCount = context.Customers.Count();
            Console.WriteLine($"عدد العملاء في القاعدة: {customersCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("حدث خطأ أثناء الاتصال بقاعدة البيانات:");
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("انتهت التجربة. اضغط أي مفتاح للخروج.");
        Console.ReadKey();
    }
}
