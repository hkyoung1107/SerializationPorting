using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace java.serialize
{
    class ClassDetails
    {
        private readonly string _className;
        private int _refHandle;
        private byte _classDescFlags;
        private readonly ArrayList _fieldDescriptions;

        public ClassDetails(string className)
        {
            this._className = className;
            this._refHandle = -1;
            this._classDescFlags = 0;
            this._fieldDescriptions = new ArrayList();
        }

        public ClassDetails(ClassDetails cd)
        {
            this._className = string.Copy(cd.GetClassName());
            this._refHandle = cd.GetHandle();
            this._classDescFlags = cd._classDescFlags;
            
            this._fieldDescriptions = new ArrayList();
            foreach (ClassField cf in cd.GetFields())
            {
                this._fieldDescriptions.Add(new ClassField(cf));
            }
        }

        public string GetClassName()
        {
            return this._className;
        }

        public void SetHandle(int handle)
        {
            this._refHandle = handle;
        }

        public int GetHandle()
        {
            return this._refHandle;
        }

        public void SetClassDescFlags(byte classDescFlags)
        {
            this._classDescFlags = classDescFlags;
        }

        public bool IsSC_SERIALIZABLE()
        {
            return (this._classDescFlags & 0x2) == 2;
        }

        public bool IsSC_EXTERNALIZABLE()
        {
            return (this._classDescFlags & 0x4) == 4;
        }

        public bool IsSC_WRITE_METHOD()
        {
            return (this._classDescFlags & 0x1) == 1;
        }
        public bool IsSC_BLOCKDATA()
        {
            return (this._classDescFlags & 0x8) == 8;
        }

        public void AddField(ClassField cf)
        {
            this._fieldDescriptions.Add(cf);
        }

        public ArrayList GetFields()
        {
            return this._fieldDescriptions;
        }

        public void SetLastFieldName(string name)
        {
            ((ClassField)this._fieldDescriptions[this._fieldDescriptions.Count-1]).SetName(name);
        }

        public void SetLastFieldClassName1(string cn1)
        {
             ((ClassField)this._fieldDescriptions[this._fieldDescriptions.Count-1]).SetClassName1(cn1);
        }
    }

}
