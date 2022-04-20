using System.ComponentModel.DataAnnotations;
namespace Mindbox_task
{

    public abstract class Figure
    {
        public delegate void Message_for_User(string message);
        /*Так как это библиотека, мы не знаем где она будет использоваться (консольное, WF, WPF и т.д.)
         * с помощью делегата мы отправляем ответ на вычисления
         */

        public abstract void square_Some_figure();
        public double S { get; set; }
        public abstract string NameFigure();
        public Message_for_User? mes;
        public void Message_for_all(Message_for_User message_For_User) //регистрируем делегат
        {
            mes = message_For_User;
        }


    }
    public class Circle : Figure
    {
        [Required] //проверяем чтобы радиус не был меньше нуля

      
        [Range(0, long.MaxValue)] //от нуля до максимального значения
        public double r { get; set; }
        

        public override void square_Some_figure()
        {
            S = Math.PI * Math.Pow(r, 2);

            mes.Invoke($"Фигура {NameFigure()}\n" +
                $"Ее площадь {S}\n");

        }
        public override string NameFigure()
        {
            return "Круг";
        }
        public Circle(double R)
        {
            this.r = R;
        }

    }
    public  class Triangle : Figure
    {
        [Required]
        [Range(0.001, long.MaxValue)]

        public double Aside { get; set; }
        [Range(0.001, long.MaxValue)]
        public double Bside { get; set; }
        [Range(0.001, long.MaxValue)]
        public double Cside { get; set; }
        //от нуля до максимального значения


        public override void square_Some_figure()
        {
             double P, k, m;
            P = (Aside + Bside + Cside) / 2;
            S = Math.Sqrt(P * ((P - Aside) * (P - Bside) * (P - Cside)));
            //это проверка является ли треугольник прямоугольным
            m = Math.Pow(Cside, 2);
            k = Math.Pow(Aside, 2) + Math.Pow(Bside, 2);
            if (m == k)
            {
                mes.Invoke($"Фигура {NameFigure()} он прямоугольный\n" +
                $"Ее площадь {S}\n");
            }
            else
            {
                mes.Invoke($"Фигура {NameFigure()}\n" +
                 $"Ее площадь {S}\n");
            }

            
        }
        public override string NameFigure()
        {
            return "Треугольник";
        }
        public Triangle(double a,double b, double c)
        {
            this.Aside=a;
            this.Bside=b;
            this.Cside=c;
            
        }
    }
}
