using System;

namespace WindowsFormsApp1
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        
        public override string ToString()
        {
            return $"Имя: {FirstName}\n" +
                   $"Фамилия: {LastName}\n" +
                   $"Email: {Email}\n" +
                   $"Телефон: {Phone}\n" +
                   $"Возраст: {Age}\n" +
                   $"Дата рождения: {BirthDate.ToShortDateString()}";
        }
    }
}


