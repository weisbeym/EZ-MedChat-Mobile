using System;
using System.Collections.Generic;
using System.Text;

namespace EZMedChatMobile.Models
{
    public class Appointment
    {
        //TODO: get nodatime package
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; } 
        public Practitioner ChosenPractitioner { get; set; }
        //public string Location { get; set; }
        public string AppointmentReason { get; set; }
        public string PreVisitInstructions { get; set; }

        public string Topic
        { 
            get { return string.Format("Appointment with {1} {0}", ChosenPractitioner.Title, ChosenPractitioner.FullName); }
            set { }
        }

        public string Duration
        {
            get { return GetAppointmentDurationAsString(); }
            set { }
        }

        public string GetAppointmentDurationAsString()
        {
            TimeSpan startTime = AppointmentTime;
            DateTime convertedStartTime = DateTime.Today.Add(startTime);

            TimeSpan endTime = AppointmentTime + new TimeSpan(0, 30, 0);
            DateTime convertedEndTime = DateTime.Today.Add(endTime);

            return convertedStartTime.ToString("hh:mm tt") + " - " + convertedEndTime.ToString("hh:mm tt");
        }
    }
}
