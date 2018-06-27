using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace java.serialize
{
    class ClassField
    {
        private readonly byte _typeCode;
        private string _name;
        private string _className1;
        private object _value;

        public ClassField(byte typeCode)
        {
            this._typeCode = typeCode;
            this._name = "";
            this._className1 = "";
            this._value = null;
        }

        public ClassField(ClassField cf)
        {
            this._typeCode = cf._typeCode;
            this._name = string.Copy(cf._name);
            this._className1 = string.Copy(cf._className1);
            this._value = null;
        }

        public byte GetTypeCode()
        {
            return this._typeCode;
        }

        public void SetName(string name)
        {
            this._name = name;
        }

        public string GetName()
        {
            return this._name;
        }

        public void SetValue(object value)
        {
            _value = value;
        }

        public void GetValue()
        {

        }

        public void SetClassName1(string cn1)
        {
            this._className1 = cn1;
        }
    }
}
