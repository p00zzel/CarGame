using Programming.Models;
using System.Collections;
using System.Numerics;
using System.Windows.Forms;

namespace CarGame
{
    public partial class Form1 : Form
    {
        private readonly Car _car;

        private readonly int Y;

        private bool _holdFlag = false;

        private int _holdCount = 1;

        public Form1()
        {
            InitializeComponent();
            _car = new Car("BMW", carPicture.Location.X);
            Y = carPicture.Location.Y;
            _car.SetIncrement(5);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _holdCount++;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (_holdFlag != false)
                    {
                        _holdCount = 1;
                        _holdFlag = false;
                    }
                    _car.SetIncrement(_holdCount);
                    if (carPicture.Location.X < 58)
                        {
                        _holdCount = 0;
                    }
 
                    _car.MoveLeft();
                    carPicture.Location = new System.Drawing.Point(_car.GetPosition(), Y);
                    break;
                case Keys.Right:
                    if (_holdFlag != true)
                    {
                        _holdCount = 1;
                        _holdFlag = true;
                    }
                    _car.SetIncrement(_holdCount);
                    if (carPicture.Location.X > 425)
                    {
                        _holdCount = 0;
                    }

                    _car.MoveRight();
                    carPicture.Location = new System.Drawing.Point(_car.GetPosition(), Y);
                    break;
                    


            }
            if (carPicture.Location.X < 58)
            {
                _car.SetPosition(58);
            }
            if (carPicture.Location.X > 425) 
            {
                _car.SetPosition(425);
            }





        }
    }
}
