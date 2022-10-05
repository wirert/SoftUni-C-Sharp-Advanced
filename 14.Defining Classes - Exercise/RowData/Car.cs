﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RowData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = new Tire[4];
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires { get; set; }

        public override string ToString()
        {
            return this.Model;
        }
    }
}
