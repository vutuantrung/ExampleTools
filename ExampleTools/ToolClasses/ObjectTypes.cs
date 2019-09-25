using System;
using System.Collections.Generic;
using System.Text;

namespace ToolClasses
{

    /* When a value-type instance is created, a single space in memory is allocated to store the value.
     * Primitive types such as int, float, bool and char are also value types, and work in the same way.
     * When the runtime deals with a value type, it's dealing directly with its underlying data and this can be very efficient, particularly with primitive types.
     * 
     * When a variable is set to another one, it is a COPY of the original variable.
     * It means there are 2 locations in the memory and they are independents.
     * When you change one of these variables, there is not effect to the other one.
     */
    public struct ObjectStruct
    {
        private string _name;
        private string _type;

        public ObjectStruct(string name)
            : this(name, "Value")
        {
        }

        public ObjectStruct(string name, string type)
        {
            _name = name;
            _type = type;
        }

        public string NameObject
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }


    /* With reference types, however, an object is created in memory, and then handled through a separate reference—rather like a pointer.
     * 
     * When a variable is set to a reference, it will copy the original's reference to another.
     * The result is they all point to the same object.
     * 
     */
    public class ObjectClass
    {
        private string _name;
        private string _type;

        public ObjectClass(string name)
            : this(name, "Reference")
        {

        }

        public ObjectClass(string name, string type)
        {
            _name = name;
            _type = type;
        }

        public string NameObject
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
