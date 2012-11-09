using System;
using System.ComponentModel;

namespace JIC.Charting
{
    public class ChartAreaConverter : TypeConverter
    {
        // allows us to display the + symbol near the property name
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(ChartArea));
        }
    }
}
