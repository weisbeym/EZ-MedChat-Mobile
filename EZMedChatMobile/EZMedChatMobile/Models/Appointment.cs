using System;
using System.Collections.Generic;
using System.Text;

namespace EZMedChatMobile.Models
{
    public class Appointment
    {
        public DateTime AppointmentDate { get; set; }
        public TimeSpan StartTime { get; set; }
        //TODO: if we have time, allow the user to choose the duration (15 min, 30 min etc.) and add that in EndTime 
        public TimeSpan EndTime
        {
            get { return StartTime.Add(new TimeSpan(0, 30, 0));  }
            set { }
        }
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
            DateTime convertedStartTime = DateTime.Today.Add(StartTime);
            DateTime convertedEndTime = DateTime.Today.Add(EndTime);

            return convertedStartTime.ToString("hh:mm tt") + " - " + convertedEndTime.ToString("hh:mm tt");
        }
    }
}
