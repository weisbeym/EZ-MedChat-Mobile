namespace EZMedChatMobile.Models
{
    /// <summary>
    /// Represents a Medical Practitioner. i.e. Doctor, Nurse Dietitian etc.
    /// </summary>
    public class Practitioner
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get => FirstName + " " + LastName;
            set { }
        }

        public bool IsOnline { get; set; }
    }
}
