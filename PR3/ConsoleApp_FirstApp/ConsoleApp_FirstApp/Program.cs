﻿using System;
using System.Collections.Generic;

namespace ConsoleApp_FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Galaxy News!");
            IterateThroughList();
            Console.ReadKey();
        }

        private static void IterateThroughList()
        {
            var theGalaxies = new List<Galaxy>
        {
            new Galaxy() { Name="Tadpole", MegaLightYears=400, GalaxyType=new GType('S')},
            new Galaxy() { Name="Pinwheel", MegaLightYears=25, GalaxyType=new GType('S')},
            new Galaxy() { Name="Cartwheel", MegaLightYears=500, GalaxyType=new GType('L')},
            new Galaxy() { Name="Small Magellanic Cloud", MegaLightYears=.2, GalaxyType=new GType('I')},
            new Galaxy() { Name="Andromeda", MegaLightYears=3, GalaxyType=new GType('S')},
            new Galaxy() { Name="Maffei 1", MegaLightYears=11, GalaxyType=new GType('E')}
        };

            foreach (Galaxy theGalaxy in theGalaxies)
            {
                Console.WriteLine(theGalaxy.Name + "  " + theGalaxy.MegaLightYears + ",  " + theGalaxy.GalaxyType);
            }

            // Expected Output:
            //  Tadpole  400,  Spiral
            //  Pinwheel  25,  Spiral
            //  Cartwheel, 500,  Lenticular
            //  Small Magellanic Cloud .2,  Irregular
            //  Andromeda  3,  Spiral
            //  Maffei 1,  11,  Elliptical
        }
    }

    public class Galaxy
    {
        public string Name { get; set; }

        public double MegaLightYears { get; set; }
        public object GalaxyType { get; set; }

    }

    public class GType
    {
        public GType(char type)
        {
            switch (type)
            {
                case 'S':
                    MyGType = Type.Spiral;
                    break;
                case 'E':
                    MyGType = Type.Elliptical;
                    break;
                case 'I':
                    MyGType = Type.Irregular;
                    break;
                case 'L':
                    MyGType = Type.Lenticular;
                    break;
                default:
                    break;
            }
        }
        public object MyGType { get; set; }
        private enum Type { Spiral, Elliptical, Irregular, Lenticular }

        public override string ToString()
        {
            switch (MyGType)
            {
                case Type.Spiral:
                    return "Spiral";
                case Type.Elliptical:
                    return "Elliptical";
                case Type.Irregular:
                    return "Irregular";
                case Type.Lenticular:
                    return "Lenticular";
                default:
                    return string.Empty;
            }
        }
    }
}