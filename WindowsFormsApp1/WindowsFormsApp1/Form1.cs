using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private User currentUser;
        
        public Form1()
        {
            InitializeComponent();
            currentUser = null;
            
            // Подписываемся на событие успешной валидации
            validationFormControl1.OnValidationSuccess += ValidationFormControl_OnValidationSuccess;
            
            // Подписываемся на кнопку очистки
            btnClearInfo.Click += BtnClearInfo_Click;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // Инициализация при загрузке формы
        }
        
        private void ValidationFormControl_OnValidationSuccess(User user)
        {
            // Сохраняем пользователя
            currentUser = user;
            
            // Выводим информацию в TextBox
            txtUserInfo.Text = user.ToString();
            
            // Показываем сообщение об успехе
            MessageBox.Show("Данные успешно сохранены!", "Успех", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void BtnClearInfo_Click(object sender, EventArgs e)
        {
            // Очищаем информацию
            txtUserInfo.Clear();
            currentUser = null;
            
            // Сбрасываем форму ввода
            validationFormControl1.ResetForm();
            
            MessageBox.Show("Информация очищена. Форма сброшена.", "Очистка",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        
        // Дополнительно: можно добавить сохранение при закрытии формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentUser != null)
            {
                var result = MessageBox.Show("Сохранить данные пользователя перед выходом?", "Выход",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    // Здесь можно добавить сохранение в файл/БД
                    SaveUserData(currentUser);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
        
        private void SaveUserData(User user)
        {
            // Пример сохранения в текстовый файл
            try
            {
                string data = $"{DateTime.Now}: {user.FirstName} {user.LastName}, {user.Email}";
                System.IO.File.AppendAllText("users_log.txt", data + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
