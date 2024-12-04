using System;

namespace LiquidClass
{
    public class Liquid
    {
        private string _name;
        private double _density;
        private double _volume;

        // Свойства
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Density
        {
            get { return _density; }
            set { _density = value; }
        }

        public double Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }

        // Конструктор
        public Liquid()
        {
            _name = "Вода";
            _density = 1;
            _volume = 1;
        }

        // Перегруженные методы SetParams
        public void SetParams(string name, double density, double volume)
        {
            this.Name = name;
            this.Density = density;
            this.Volume = volume;
        }

        public void SetParams(string name)
        {
            switch (name.ToLower())
            {
                case "вода":
                    this.Name = "Вода";
                    this.Density = 1;
                    this.Volume = 1;
                    break;
                case "масло":
                    this.Name = "Масло";
                    this.Density = 0.9;
                    this.Volume = 1;
                    break;
                case "пиво":
                    this.Name = "Пиво";
                    this.Density = 2.0;
                    this.Volume = 1.5;
                    break;
                default:
                    this.Name = "Неизвестная жидкость";
                    this.Density = 0;
                    this.Volume = 0;
                    break;
            }
        }
        public bool
            EqualsByVolumeAndName(Liquid other)
        {
            if (other == null) return false; ;
            return this.Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase) && Math.Abs(this.Volume - other.Volume) < 0.001;
        }
        public static Liquid operator ++(Liquid liquid)
        {
            liquid.Volume++;
            return liquid;
        }
        public void DecreaseVolume()
        {
            if (this.Volume == 0) return;
            this.Volume--;
            {

                this.Volume++;

                {
                    this.Volume--;
                }
            }
        }
    }

}