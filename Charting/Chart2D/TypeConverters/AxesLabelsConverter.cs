using System;
using System.ComponentModel;

namespace JIC.Charting
{
    public class AxesLabelsConverter : TypeConverter
    {
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(AxesLabels));
        }
    }
}
