using Chastitcy6;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Chastitcy6
{
    public partial class Form1 : Form
    {
        // список эмиттеров, чтобы можно было расширить систему
        List<Emitter> emitters = new List<Emitter>();

        // сам эмиттер, который будет генерировать частицы
        Emitter emitter;

        // единственный портал: красный вход → фиолетовый выход
        Teleport teleport;

        public Form1()
        {
            InitializeComponent();

            // создаём буфер для рисования на picturebox
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            //  настраиваем эмиттер
            emitter = new Emitter
            {
                // направление выстрела (–90° = вверх)
                Direction = -90,
                // разброс частиц в градусах
                Spreading = 45,
                // скорость частиц (min … max)
                SpeedMin = 8,
                SpeedMax = 14,
                // сколько частиц выпускается за тик
                ParticlesPerTick = 30,
                // цвет плавного перехода у частиц (от → к)
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                // начальные координаты эмиттера (центр экрана)
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };
            // добавляем эмиттер в список для удобства
            emitters.Add(emitter);

            // настраиваем портал
            teleport = new Teleport
            {
                // координаты красного входа (левый клик двигает сюда)
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
                // координаты фиолетового выхода (правый клик двигает сюда)
                ExitX = picDisplay.Width / 2 + 100,
                ExitY = picDisplay.Height / 2,
                // радиус действия портала
                Radius = 50,
                // цвета для отрисовки (вход, выход, линия)
                EntryPenColor = Color.Red,
                ExitPenColor = Color.MediumPurple,
                LinePenColor = Color.Green
            };
            // регистрируем портал как точку воздействия на частицы
            emitter.impactPoints.Add(teleport);

            //  подписываемся на событие клика мыши по picturebox
            picDisplay.MouseClick += picDisplay_MouseClick;

            //  настраиваем и запускаем таймер анимации
            timer1.Interval = 40;  // миллисекунды между кадрами
            timer1.Start();
        }

        // обработчик клика мыши: левой двигаем вход, правой — выход
        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // перемещаем точку входа портала
                teleport.X = e.X;
                teleport.Y = e.Y;
            }
            else if (e.Button == MouseButtons.Right)
            {
                // перемещаем точку выхода портала
                teleport.ExitX = e.X;
                teleport.ExitY = e.Y;
            }
        }

        // каждый тик таймера обновляем состояние частиц и перерисовываем
        private void timer1_Tick(object sender, EventArgs e)
        {
            // обновляем позиции, скорости и телепорт
            emitter.UpdateState();

            // рисуем всё на картинке
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                // очищаем фон в белый цвет
                g.Clear(Color.White);
                // отрисовываем все частицы и портал
                emitter.Render(g);
            }
            // просим picturebox обновить отображение
            picDisplay.Invalidate();
        }
    }
}
