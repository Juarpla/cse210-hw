using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Appointments : Tool
{
    private string _appointmentDate;

    public Appointments(string subject, string appointmentDate)
    {
        _name = subject;
        _appointmentDate = appointmentDate;
    }

    public override void Run()
    {
        DateTime dateTime;
        try
        {
            dateTime = DateTime.Parse(_appointmentDate);
        }
        catch (System.Exception e)
        {
            Console.WriteLine($"¡Error, date format: {e.Message}");
            return;
        }
        TimeSpan timeUntilAppointment = dateTime - DateTime.Now;

        Notification notification = new Notification("Appointment: ", _name, (timeUntilAppointment/1000) + "");
        notification.Run();
    }
}