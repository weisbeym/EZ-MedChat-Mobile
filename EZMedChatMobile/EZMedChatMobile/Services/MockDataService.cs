using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using EZMedChatMobile.Models;

namespace EZMedChatMobile.Services
{
    public class MockDataService : IMedChatDataService
    {
        readonly List<Practitioner> practitioners;
        readonly List<Appointment> appointments;


        public MockDataService()
        {
            practitioners = CreateMockPractitioners();
            appointments = CreatMockAppoinntments();
        }

        public List<Practitioner> GetPractitioners()
        {
            return practitioners;
        }

        public List<Appointment> GetAppointments()
        {
            return appointments;
        }

        public List<Practitioner> CreateMockPractitioners()
        {
            List<Practitioner> practitioners = new List<Practitioner>()
            {
                new Practitioner { Id = 1, FirstName = "John", LastName ="Doe", Title="MD", IsOnline=false},
                new Practitioner { Id = 2, FirstName = "Max", LastName ="Paine", Title="OD", IsOnline=true},
                new Practitioner { Id = 3, FirstName = "Jane", LastName ="Fonda", Title="DPM", IsOnline=false},
                new Practitioner { Id = 4, FirstName = "Chris", LastName ="Pratt", Title="MD", IsOnline=false},
                new Practitioner { Id = 5, FirstName = "Mary", LastName ="Jane", Title="RDN", IsOnline=false},
                new Practitioner { Id = 6, FirstName = "Gwen", LastName ="Stacy", Title="RN", IsOnline=false},
                new Practitioner { Id = 7, FirstName = "Allen", LastName ="Walker", Title="MD", IsOnline=true},
            };

            return practitioners;
        }

        public List<Appointment> CreatMockAppoinntments()
        {
            List<Appointment> appointments = new List<Appointment>()
            {
                new Appointment {AppointmentDate = new DateTime(2020, 1, 15, 9, 30, 0), AppointmentTime = new TimeSpan(11,0,0), 
                    ChosenPractitioner = practitioners[0], AppointmentReason="Annual visit."},
                new Appointment {AppointmentDate = new DateTime(2020, 3, 21, 13, 0, 0), AppointmentTime = new TimeSpan(9,0,0),
                    ChosenPractitioner = practitioners[2], AppointmentReason="Fell and couldn't walk on my right leg."},
                new Appointment {AppointmentDate = new DateTime(2020, 4, 3, 8, 30, 0), AppointmentTime = new TimeSpan(13,30,0),
                    ChosenPractitioner = practitioners[1], AppointmentReason="Annual eye exam."},
                new Appointment {AppointmentDate = new DateTime(2020, 4, 10, 9, 30, 0), AppointmentTime = new TimeSpan(10,15,0),
                    ChosenPractitioner = practitioners[2], AppointmentReason="Follow up."},
                new Appointment {AppointmentDate = new DateTime(2020, 5, 12, 11, 0, 0), AppointmentTime = new TimeSpan(8,0,0),
                    ChosenPractitioner = practitioners[0], AppointmentReason="Normal Visit"},
                new Appointment {AppointmentDate = new DateTime(2020, 12, 15, 9, 30, 0), AppointmentTime = new TimeSpan(9,30,0),
                    ChosenPractitioner = practitioners[0], AppointmentReason="Issues with stomach."},
            };

            return appointments;
        }

        public Task<bool> CheckExists(string key, string value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TestUsernameExists(string username)
        {
            throw new NotImplementedException();
        }
    }
}
