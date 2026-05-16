using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    public class BaseForm : Form
    {
        protected Panel borderPanel;
        protected Panel contentPanel;

        // Сохраняем обычные позиции для сброса
        private Dictionary<Control, Point> normalPositions = new Dictionary<Control, Point>();
        private Dictionary<Control, Size> normalSizes = new Dictionary<Control, Size>();

        public BaseForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += BaseForm_Resize;

            borderPanel = new Panel
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.None,
                Visible = false
            };

            contentPanel = new Panel
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.None
            };

            this.Controls.Add(borderPanel);
            this.Controls.Add(contentPanel);
            contentPanel.BringToFront();
        }

        // Сохраняем нормальные позиции элементов
        protected void SaveNormalPositions()
        {
            normalPositions.Clear();
            normalSizes.Clear();

            foreach (Control control in contentPanel.Controls)
            {
                normalPositions[control] = control.Location;
                normalSizes[control] = control.Size;
            }
        }

        private void BaseForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                ShowBorderFrame();
                CenterContent();
            }
            else
            {
                HideBorderFrame();
                ResetContentPosition();
            }
        }

        private void ShowBorderFrame()
        {
            borderPanel.Visible = true;

            // Рамка занимает 80% ширины и 90% высоты
            int frameWidth = (int)(this.ClientSize.Width * 0.8);
            int frameHeight = (int)(this.ClientSize.Height * 0.9);

            borderPanel.Size = new Size(frameWidth, frameHeight);
            borderPanel.Location = new Point(
                (this.ClientSize.Width - frameWidth) / 2,
                (this.ClientSize.Height - frameHeight) / 2
            );

            borderPanel.Paint -= BorderPanel_Paint;
            borderPanel.Paint += BorderPanel_Paint;
            borderPanel.Invalidate();
        }

        private void BorderPanel_Paint(object sender, PaintEventArgs e)
        {
            // Рисуем рамку
            using (Pen pen = new Pen(Color.FromArgb(100, 100, 150), 3))
            {
                e.Graphics.DrawRectangle(pen, 1, 1, borderPanel.Width - 3, borderPanel.Height - 3);
            }

            // Рисуем тень
            using (Pen shadowPen = new Pen(Color.FromArgb(50, 0, 0, 0), 2))
            {
                e.Graphics.DrawRectangle(shadowPen, 3, 3, borderPanel.Width - 7, borderPanel.Height - 7);
            }
        }

        private void HideBorderFrame()
        {
            borderPanel.Visible = false;
        }

        private void CenterContent()
        {
            // Контентная панель внутри рамки с отступами
            int contentWidth = borderPanel.Width - 60;
            int contentHeight = borderPanel.Height - 60;

            contentPanel.Size = new Size(contentWidth, contentHeight);
            contentPanel.Location = new Point(
                borderPanel.Left + 30,
                borderPanel.Top + 30
            );

            // Центрируем элементы внутри контентной панели
            CenterControlsInPanel();
        }

        private void ResetContentPosition()
        {
            // Возвращаем контентную панель на всю форму
            contentPanel.Size = this.ClientSize;
            contentPanel.Location = new Point(0, 0);

            // Сбрасываем позиции элементов
            ResetControlsPosition();
        }

        protected virtual void CenterControlsInPanel()
        {
            // Этот метод будут переопределять дочерние формы
            // Здесь можно реализовать базовое центрирование
            int centerX = contentPanel.Width / 2;
            int startY = 50;
            int yOffset = 40;
            int currentY = startY;

            foreach (Control control in contentPanel.Controls)
            {
                if (control is Label)
                {
                    // Лейблы выравниваем по правому краю от центра
                    control.Location = new Point(centerX - 150, currentY);
                }
                else if (control is TextBox || control is ComboBox)
                {
                    // Поля ввода по центру
                    control.Width = 250;
                    control.Location = new Point(centerX - 125, currentY);
                    currentY += yOffset;
                }
                else if (control is Button)
                {
                    // Кнопки парами
                    if (control.Name.Contains("vhod") || control.Name.Contains("Register"))
                    {
                        control.Width = 120;
                        control.Location = new Point(centerX - 130, currentY);
                    }
                    else if (control.Name.Contains("Back"))
                    {
                        control.Width = 120;
                        control.Location = new Point(centerX + 10, currentY);
                    }
                    else
                    {
                        control.Location = new Point(centerX - 60, currentY);
                    }
                    currentY += yOffset;
                }
            }
        }

        protected virtual void ResetControlsPosition()
        {
            // Этот метод будут переопределять дочерние формы
            // По умолчанию ничего не делаем
        }
    }
}