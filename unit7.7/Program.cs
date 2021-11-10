using System;

namespace unit7._7_Final_task
{
    class Program
    {
        static void Main(string[] args)
        {
            MobilePhone mobilePhone = new MobilePhone();
            Console.WriteLine($"Характеристики телефона: {mobilePhone.NameProduct()}");

            var casePhone = new CasePhone();
            var caseShop = casePhone.mobilePhone.model;
            Console.WriteLine($"Наименование чехла: {casePhone.ChangeCase(caseShop)}");


        }
    }
    abstract class Delivery
    {
        public string Address;
    }

    abstract class Product
    {
        public string manufactur;
        public string model;
        public int productionYear;

        public virtual string NameProduct() // переопределенный метод
        {
            return "производитель:" + manufactur + "модель:" + model + "год выпуска:" + productionYear;
        }
        //public abstract void Display(); // абастрактный класс
    }

    class MobilePhone : Product
    {
        public int numberSim; // число сим карт
        protected string communicationStandards; // стандарт связи

        public MobilePhone() // конструктор
        {
            manufactur = "Samsung";
            model = "A50";
            productionYear = 2021;
            numberSim = 3;
            communicationStandards = "4G";
        }
        public int NumberSim // свойства
        {
            get
            {
                return numberSim;
            }
            set
            {
                if (value < 0 || value > 3)
                {
                    Console.WriteLine("Число сим карт д.б. 1 или 2");
                }
                else numberSim = value;
            }
        }

        public override string NameProduct() // переопределенный метод
        {
            return "производитель: " + manufactur + " модель: " + model + " год выпуска: "  + productionYear + " число сим карт: " + numberSim + " стандарт связи: " + communicationStandards;
        }
    }

    class CasePhone
    {
        public MobilePhone mobilePhone;
        public CasePhone() // композиция
        {
            mobilePhone = new MobilePhone();
        }
        public string ChangeCase(string model)
        {
            switch (mobilePhone.model)
            {
                case "A50":
                    return "caseModelA50";
                case "A51":
                    return "caseModelA51";
                case "A70":
                    return "caseModelA70";
            }
            return "CaseIndefined";
        }
    }

    class 

    class Order<TDelivery, TMobilePhone, TCasePhone> 
        where TDelivery : Delivery
        where TMobilePhone : MobilePhone
        where TCasePhone : CasePhone
    {
        public TDelivery Delivery;
        public TMobilePhone MobilePhone;
        public TCasePhone CasePhone;


        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine("Адрес доставки" + Delivery.Address);
        }

        public void DisplayProduct()
        {
            Console.WriteLine("Товар: " + MobilePhone.NameProduct());
        }
    }
}
