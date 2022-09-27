using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_lab001
{
    public delegate void MyDelegate();
    public abstract class GeoFigure
    {
        protected string name;
        public GeoFigure()
        {
            name = "Фигура";
        }
        private bool Scalable;

        public bool scalable
        {
            get { return Scalable; }
            set { Scalable = value; }
        }

        public void PrintName()
        {
            Console.WriteLine(this.name);
        }
        public abstract float Square();
        public virtual float Square(float _metric)
        {
            return _metric;
        }
        public virtual float Square(float sideA, float sideB)
        {
            return sideA * sideB;
        }

        public abstract float Perimeter();

        public virtual float Perimeter(float _metric)
        {
            return _metric;
        }
        public virtual float Perimeter(float sideA, float sideB)
        {
            return sideA + sideB;
        }



    }
    public class Circle : GeoFigure
    {

        public new string name = "Круг", _path = "output.txt";

        public event MyDelegate _notify
        {
            add => _notify += value;
            remove => _notify -= value;
        }

        public float _radius;

        public MyDelegate PrintCircleSquare { get; internal set; }
        public MyDelegate PrintCirclePerimeter { get; internal set; }
        public MyDelegate WriteCircleSquare { get; internal set; }
        public MyDelegate WriteCirclePerimeter { get; internal set; }

        public override float Square()
        {
            //_notify = InformerConsole;

            float _result = _radius * _radius * 3.14f;
            float _limit = 100f;
            if (_result > _limit)
            {

                _notify += InformerConsole;
                //_notify -= InformerConsole;
            }
            return _result;
        }

        public override float Perimeter()
        {
            float _result = _radius * _radius * 3.14f;

            return _result;
        }

        public override float Square(float _metric)
        {
            return _radius * _radius * 3.14f;
        }
        public float Square(float _metric, bool IsBase)
        {
            if (IsBase)
            {
                return base.Square(_metric);
            }
            else
            {
                return Square(_metric);
            }

        }
        public void PrintSquare()
        {
            Console.WriteLine("Площадь = {0}", this.Square(this._radius));
        }
        public void PrintSquare(bool IsBase)
        {
            Console.WriteLine("Площадь = {0}", this.Square(this._radius, IsBase));
        }
        public void WriteSquare()
        {
            string full_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var sw = new StreamWriter(full_path + "\\" + _path, true);
            sw.WriteLine("Площадь = {0}", this.Square(this._radius));
            sw.Close();
        }
        public void InformerConsole()
        {
            Console.WriteLine("Площадь окружности больше 100");
        }


    }

    // Task1

    public class Rectangle : GeoFigure
    {
        public new string name = "Прямоугольник", _path = "output.txt";

        public float _sideA, _sideB;

        public MyDelegate PrintRectanglePerimeter { get; private set; }

        public event MyDelegate _notify
        {
            add => _notify += value;
            remove => _notify -= value;
        }
        public override float Square()
        {
            float _result = _sideA * _sideB;
            float _limit = 100f;
            if (_result > _limit)
            {
                _notify += InformerConsole;
            }
            return _result;
        }

        public float Square(float sideA, float sideB, bool isBase)
        {
            if (isBase)
            {
                return base.Square(sideA, sideB);
            }
            {
                return Square(sideA, sideB);
            }
        }
        // Task 2
        public override float Perimeter()
        {
            float _result = _sideA * _sideB * 2.0f;

            return _result;
        }

        public override float Perimeter(float sideA, float sideB)
        {
            sideA = _sideA;
            sideB = _sideB;
            return sideA * sideB * 2.0f;
        }

        public float Perimeter(float sideA, float sideB, bool isBase)
        {
            if (isBase)
            {
                return base.Perimeter(sideA, sideB);
            }
            {
                return Perimeter(sideA, sideB);
            }
        }
        public void InformerConsole()
        {
            Console.WriteLine("Площадь треугольника больше 100");
        }

        // Task 3

        public void PrintRectangleSquare()
        {
            Console.WriteLine($"Площадь = {this.Square()}");
        }
        public void PrintRectangleSquare(bool isBase)
        {
            Console.WriteLine($"Площадь = {this.Square(_sideA, _sideB, isBase)}");
        }

        public void WriteRectangleSquare()
        {
            string _MyDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var StreamWriter = new StreamWriter(_MyDocsPath + "//" + _path, true);
            StreamWriter.WriteLine(name);
            StreamWriter.WriteLine("Площадь = {0}", this.Square(this._sideA, this._sideB));
            StreamWriter.Close();
        }

        public void WriteRectanglePerimeter()
        {
            string _MyDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var StreamWriter = new StreamWriter(_MyDocsPath + "//" + _path, true);
            StreamWriter.WriteLine(name);
            StreamWriter.WriteLine("Периметр = {0}", this.Perimeter(this._sideA, this._sideB));
            StreamWriter.Close();
        }






    }

    public class Rhombus : GeoFigure
    {
        public new string name = "Ромб", _path = "output.txt";

        public float _sideAB, _sideBC;
        internal MyDelegate PrintRhombusSquare;
        internal MyDelegate PrintRhombusPerimeter;

        public MyDelegate WriteRhombusSquare { get; internal set; }
        public MyDelegate WriteRhombusPerimeter { get; internal set; }

        public event MyDelegate _notify
        {
            add => _notify += value;
            remove => _notify -= value;
        }
        public override float Square()
        {
            float _result = _sideAB * _sideBC * 0.5f;
            float _limit = 100f;
            if (_result > _limit)
            {
                _notify += InformerConsole;
            }
            return _result;
        }

        // Task 2
        public override float Perimeter()
        {
            float _result = _sideAB + _sideBC * 2.0f;

            return _result;
        }

        public void InformerConsole()
        {
            Console.WriteLine("Площадь ромба больше 100");
        }

    




    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 3, 4

            var myCircrle = new Circle();
            var myRectangle = new Rectangle();
            var myRhombus = new Rhombus();

            int myNumber = 0;
            Console.WriteLine("Выберите фигуру: \n" +
                "[1] Окружность\n" +
                "[2] Прямоугольник\n" +
                "[3] Ромб\n");

            myNumber = Convert.ToInt32(Console.ReadLine());
            switch (myNumber)
            {
                case 1:
                    Console.WriteLine("Введите радиус окружности: ");
                    myCircrle._radius = Convert.ToSingle(Console.ReadLine());
                    MyDelegate _delegateCircle = myCircrle.PrintName;
                    myCircrle.name = "Окружность";
                    _delegateCircle += myCircrle.PrintCircleSquare;
                    _delegateCircle += myCircrle.PrintCirclePerimeter;
                    _delegateCircle?.Invoke();
                    Console.WriteLine("Сохранить данные об окружности? [1] - Да, [2] - Нет");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        _delegateCircle += myCircrle.WriteCircleSquare;
                        _delegateCircle += myCircrle.WriteCirclePerimeter;
                        _delegateCircle += myCircrle.PrintCircleSquare;
                        _delegateCircle += myCircrle.PrintCirclePerimeter;
                        Console.WriteLine("Сохранено..");
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите сторону А прямоугольника: ");
                    myRectangle._sideA = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Введите сторону B прямоугольника: ");
                    myRectangle._sideB = Convert.ToSingle(Console.ReadLine());
                    MyDelegate _delegateRectangle = myRectangle.PrintName;
                    myRectangle.name = "Прямоугольник";
                    _delegateRectangle += myRectangle.PrintRectangleSquare;
                    _delegateRectangle += myRectangle.PrintRectanglePerimeter;
                    _delegateRectangle?.Invoke();
                    Console.WriteLine("Сохранить данные о прямоугольнике? [1] - Да, [2] - Нет");
                    int choice2 = Convert.ToInt32(Console.ReadLine());
                    if (choice2 == 1)
                    {
                        _delegateRectangle += myRectangle.WriteRectangleSquare;
                        _delegateRectangle += myRectangle.WriteRectanglePerimeter;
                        _delegateRectangle += myRectangle.PrintRectangleSquare;
                        _delegateRectangle += myRectangle.PrintRectanglePerimeter;
                        _delegateRectangle?.Invoke();
                        Console.WriteLine("Сохранено..");
                    }
                    break;
                case 3:
                    Console.WriteLine("Введите длину стороны ромба AB: ");
                    myRhombus._sideAB = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Введите длину стороны ромба BC: ");
                    myRhombus._sideBC = Convert.ToSingle(Console.ReadLine());
                    MyDelegate _delegateRhombus = myRhombus.PrintName;
                    myRhombus.name = "Ромб";
                    _delegateRhombus += myRhombus.PrintRhombusSquare;
                    _delegateRhombus += myRhombus.PrintRhombusPerimeter;
                    _delegateRhombus?.Invoke();
                    Console.WriteLine("Сохранить данные о ромбе? [1] - Да, [2] - Нет");
                    int choice3 = Convert.ToInt32(Console.ReadLine());
                    if (choice3 == 1)
                    {
                        _delegateRhombus += myRhombus.WriteRhombusSquare;
                        _delegateRhombus += myRhombus.WriteRhombusPerimeter;
                        _delegateRhombus += myRhombus.PrintRhombusSquare;
                        _delegateRhombus += myRhombus.PrintRhombusPerimeter;
                        _delegateRhombus?.Invoke();
                        Console.WriteLine("Сохранено..");
                    }
                        break;
            }
            //MyDelegate _delegate = myCircrle.PrintSquare;
            //myCircrle._radius = 3f;
            //myCircrle.name = "Круг";
            //myCircrle.PrintName();
            ////myCircrle.PrintSquare();
            ////myCircrle.PrintSquare(true);
            //_delegate?.Invoke();
            //_delegate += myCircrle.WriteSquare;
            //_delegate?.Invoke();
            //_delegate -= myCircrle.WriteSquare;
            //_delegate?.Invoke();
            //_delegate -= myCircrle.PrintSquare;
            //_delegate?.Invoke();

        }
    }
}
