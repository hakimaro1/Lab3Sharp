using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTimer2
{
    public partial class UserControlTimer2 : UserControl
    {
        public UserControlTimer2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe); // Важно: всегда вызывайте метод базового класса

            // Получаем объект Graphics для рисования
            Graphics g = pe.Graphics;

            // Рисуем зеленый прямоугольник на всей площади элемента управления
            g.FillRectangle(Brushes.Green, 0, 0, this.Width, this.Height);

            // Рисуем текущее время в верхнем левом углу
            pe.Graphics.DrawString(
                DateTime.Now.ToLongTimeString(), // Текущее время в длинном строковом формате
                this.Font,                        // Используем шрифт, заданный для элемента управления
                new SolidBrush(this.ForeColor),   // Используем цвет текста (ForeColor) элемента управления
                0,                                // Координата X (левый край)
                0                                 // Координата Y (верхний край)
            );
        }
    }
}
