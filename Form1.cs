using CarGame.Models;
using Programming.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarGame
{
    public partial class Form1 : Form
    {
        private readonly Car _car;

        private readonly int Y;

        private bool _holdFlag = false;

        private int _xStep = 1;

        private int _xMinLimit = 65;

        private int _xMaxLimit = 415;

        private int _barrierStep = 1;

        private List<Barrier> _barriers;

        private List<PictureBox> _pictureBoxes;

        private Timer _timer;


        public Form1()
        {
            InitializeComponent();
            _car = new Car("BMW", carPicture.Location.X);
            Y = carPicture.Location.Y;
            _car.SetIncrement(5);
            _barriers = new List<Barrier>();
            _pictureBoxes = new List<PictureBox>();
            InitializeTimer();
            InitializeBarriers();
            DrawBarriers();
        }

        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Tick += MoveBarriers;
            _timer.Start();
        }

        private void MoveBarriers(object? o, EventArgs? e)
        {
            foreach (var picture in _pictureBoxes)
            {
                var oldLocation = picture.Location;
                picture.Location = new System.Drawing.Point(oldLocation.X, oldLocation.Y + _barrierStep);
            }
        }

        private void InitializeBarriers()
        {
            _barriers.Add(new Barrier(new System.Drawing.Point(_xMinLimit, 100), 0));
            _barriers.Add(new Barrier(new System.Drawing.Point(_xMinLimit + 200, 200), 1));
        }

        private void DrawBarriers()
        {
            foreach (var barrier in _barriers)
            {
                var pictureBox = new PictureBox()
                {
                    Name = barrier.Name,
                    Image = barrier.Image,
                    Location = new System.Drawing.Point(barrier.X, barrier.Y)
                };

                this.Controls.Add(pictureBox);
                _pictureBoxes.Add(pictureBox);
                pictureBox.BringToFront();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _xStep++;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (_holdFlag != false)
                    {
                        _xStep = 1;
                        _holdFlag = false;
                    }

                    if ((_car.GetPosition() - _xStep) < _xMinLimit)
                    {
                        _car.SetPosition(_xMinLimit);
                        _xStep = 0;
                    }
                    
                    _car.SetIncrement(_xStep);
                    _car.MoveLeft();
                    carPicture.Location = new System.Drawing.Point(_car.GetPosition(), Y);
                    break;
                case Keys.Right:
                    if (_holdFlag != true)
                    {
                        _xStep = 1;
                        _holdFlag = true;
                    }

                    if ((_car.GetPosition() + _xStep) > _xMaxLimit)
                    {
                        _car.SetPosition(_xMaxLimit);
                        _xStep = 0;
                    }

                    _car.SetIncrement(_xStep);
                    _car.MoveRight();
                    carPicture.Location = new System.Drawing.Point(_car.GetPosition(), Y);
                    break;
                    


            }
            if (carPicture.Location.X < _xMinLimit)
            {
                _car.SetPosition(_xMinLimit);
            }
            if (carPicture.Location.X > _xMaxLimit) 
            {
                _car.SetPosition(_xMaxLimit);
            }
        }
    }
}
