using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chastitcy6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // привязал изображение
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        }
    }
}
