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
        DateTime dateTime = DateTime.Parse(_appointmentDate);
        TimeSpan timeUntilAppointment = dateTime - DateTime.Now;

        Notification notification = new Notification("Appointment: ", _name, (timeUntilAppointment/1000) + "");
        notification.Run();
    }
}