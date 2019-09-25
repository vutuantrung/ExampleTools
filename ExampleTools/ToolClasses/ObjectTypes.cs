using System;
using System.Collections.Generic;
using System.Text;

namespace ToolClasses
{
    struct ObjectStruct
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

        public string NameStruct
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
    class ObjectClass
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
