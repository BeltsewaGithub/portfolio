using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calc
    {
        private double? a = null;
        private double memory = 0;
        private Operations operation = new Operations();
        private bool isError = false;

        public bool IsError { get => isError; set => isError = value; }

        public void Put_A(double? a)
        {
            if (this.isError == false) this.a = a;
            else { this.a = null; }
        }
        
        public double? Get_A()
        {
            return this.a;
        }
        public void Put_Operation(Operations operation) //установка значения выполняемой на данный момент операции
        {
            this.operation = operation;
        }

        public void Clear_A()
        {
            a = null;
            operation = new Operations();
        }

        public double calculate(double b)
        {
            switch (operation)
            {
                case Operations.MULTIPLY: return Multiplication(b);
                case Operations.DIVISION: return Division(b);
                case Operations.MINUS: return Subtraction(b);
                case Operations.PLUS: return Sum(b);
                case Operations.PERCENT: return Percent(b);
            }
            return 0;
        }

        //__________________________________________________MATH_OPERATIONS__________________________________________________
        
        private double A()
        {
            double a1 = 0;
            if (a != null)
            {
                a1 = Convert.ToDouble(a);
            }
            return a1;
        }
        private double Multiplication(double b)
        {
            double a1 = this.A();
            return a1 * b;
        }

        public double Division(double b)
        {
            if (b == 0) 
                throw new DivideByZeroException();
            else
            {
                double a1 = this.A();
                return a1 / b;
            }
        } 

        private double Sum(double b)
        {
            double a1 = this.A();
            return a1 + b;
        }

        private double Subtraction(double b)
        {
            double a1 = this.A();
            return a1 - b;
        }

        public double Percent(double b)
        {
            if (a != null)
            {
                double a1 = this.A();
                return a1 * b / 100;
            }
            else return b / 100;
        }
        
        public double Sqrt(double b)
        {
            return Math.Sqrt(b);
        }

        //__________________________________________________MEMORY__________________________________________________
        public void Memory_Save()
        {
            double a1 = this.A();
            memory = a1;
        }

        public double Memory_Read()
        {
            return memory;
        }

        public void Memory_Clear()
        {
            memory = 0.0;
        }

        public void M_Sum()
        {
            double a1 = this.A();
            memory += a1;
        }
    }
    public enum Operations
    {
        PLUS,
        MINUS,
        DIVISION,
        MULTIPLY,
        PERCENT
    }
}
