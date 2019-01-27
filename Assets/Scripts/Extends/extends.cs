using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public static class extends
    {

        public static bool _Contains<T>(this IList<T> list, List<T> _list)
        {
            foreach(T type in list)
            {
                foreach(T type2 in _list)
                {
                    if (type.Equals(type2))
                        return true;
                }
            }
            return false;
        }

        public static bool ContainsPropName(this IList<PropertiesFoo> thisList, PropertiesName thePropName)
        {
            foreach (PropertiesFoo property in thisList)
            {
                if (property.propName == thePropName)
                    return true;
            }
            return false;
        }

        public static int returnPropValue(this IList<PropertiesFoo> thisList, PropertiesName thePropName)
        {
            foreach (PropertiesFoo property in thisList)
            {
                if (property.propName == thePropName)
                { 
                    return property.prop.mValue;
                }
            }
            return 0;
        }

        public static Property returnProperty(this IList<PropertiesFoo> thisList, PropertiesName thePropName)
        {
            foreach(PropertiesFoo property in thisList)
            {
                if (property.propName == thePropName)
                    return property.prop;
            }
            return null;
        }
    }
}
