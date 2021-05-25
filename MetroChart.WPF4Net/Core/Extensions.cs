using System;
using System.Net;
using System.Windows;
using System.Reflection;
using System.Linq;

namespace De.TorstenMandelkow.MetroChart
{
    public static class Extensions
    {
        public static PropertyInfo[] GetAllProperties(this Type type)
        {
            return type.GetProperties();
        }
    }
}
