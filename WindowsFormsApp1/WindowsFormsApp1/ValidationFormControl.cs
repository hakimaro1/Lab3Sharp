using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ValidationFormControl : UserControl
    {
        // Событие для передачи валидных данных
        public event Action<User> OnValidationSuccess;
        
        public ValidationFormControl()
        {
            InitializeComponent();
            errorLabel.Text = "";
            errorLabel.Visible = false;
            
            // Инициализация даты рождения
            dtpBirthDate.Value = DateTime.Now.AddYears(-18);
            
            // Подписка на события кнопок
            btnSubmit.Click += BtnSubmit_Click;
            btnClear.Click += BtnClear_Click;
        }
        
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                User user = new User
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Age = (int)numAge.Value,
                    BirthDate = dtpBirthDate.Value
                };
                
                // Очищаем ошибки
                errorLabel.Text = "";
                errorLabel.Visible = false;
                
                // Вызываем событие с валидными данными
                OnValidationSuccess?.Invoke(user);
            }
        }
        
        private bool ValidateInputs()
        {
            string errors = "";
            
            // Проверка имени
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                errors += "• Имя обязательно для заполнения\n";
            else if (txtFirstName.Text.Trim().Length < 2)
                errors += "• Имя должно содержать минимум 2 символа\n";
            
            // Проверка фамилии
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
                errors += "• Фамилия обязательна для заполнения\n";
            else if (txtLastName.Text.Trim().Length < 2)
                errors += "• Фамилия должна содержать минимум 2 символа\n";
            
            // Проверка email
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
                errors += "• Email обязателен для заполнения\n";
            else if (!IsValidEmail(email))
                errors += "• Неверный формат email\n";
            
            // Проверка телефона
            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
                errors += "• Телефон обязателен для заполнения\n";
            else if (!IsValidPhone(phone))
                errors += "• Неверный формат телефона (пример: +7(999)123-45-67)\n";
            
            // Проверка возраста
            if (numAge.Value < 0 || numAge.Value > 150)
                errors += "• Возраст должен быть от 0 до 150 лет\n";
            
            // Проверка даты рождения
            if (dtpBirthDate.Value > DateTime.Now)
                errors += "• Дата рождения не может быть в будущем\n";
            
            // Если есть ошибки - показываем их
            if (!string.IsNullOrEmpty(errors))
            {
                errorLabel.Text = "Обнаружены ошибки:\n" + errors;
                errorLabel.Visible = true;
                return false;
            }
            
            return true;
        }
        
        private bool IsValidEmail(string email)
        {
            try
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }
        
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;
                
            // Валидация российских телефонов
            // Поддерживает форматы: +7(999)123-4567, +79991234567, 8(999)123-4567, 89991234567 и т.д.
            // Убираем все пробелы, дефисы и скобки для проверки
            string cleanPhone = phone.Replace(" ", "")
                                     .Replace("-", "")
                                     .Replace("(", "")
                                     .Replace(")", "");
            
            // Проверяем, что после очистки осталось 10-11 цифр (с учетом +7 или 8)
            if (cleanPhone.StartsWith("+7"))
            {
                cleanPhone = cleanPhone.Substring(2);
            }
            else if (cleanPhone.StartsWith("8"))
            {
                cleanPhone = cleanPhone.Substring(1);
            }
            else if (cleanPhone.StartsWith("7"))
            {
                cleanPhone = cleanPhone.Substring(1);
            }
            
            // Должно быть 10 цифр
            if (cleanPhone.Length != 10)
                return false;
            
            // Проверяем, что все символы - цифры
            return Regex.IsMatch(cleanPhone, @"^\d{10}$");
        }
        
        private void BtnClear_Click(object sender, EventArgs e)
        {
            // Очищаем все поля
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            numAge.Value = 18;
            dtpBirthDate.Value = DateTime.Now.AddYears(-18);
            errorLabel.Text = "";
            errorLabel.Visible = false;
        }
        
        // Публичный метод для сброса формы
        public void ResetForm()
        {
            BtnClear_Click(null, EventArgs.Empty);
        }
    }
}

