using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace java.serialize
{
    class ClassDataDesc
    {
        private readonly ArrayList _classDetails;

        public ClassDataDesc()
        {
            this._classDetails = new ArrayList();
        }

        public ClassDataDesc(ClassDataDesc cdd)
        {
            this._classDetails = new ArrayList();

            foreach(ClassDetails cd in cdd._classDetails)
            {
                this._classDetails.Add(new ClassDetails(cd));
            }
        }

        private ClassDataDesc(ArrayList cd)
        {
            this._classDetails = cd;
        }

        public ClassDataDesc buildClassDataDescFromIndex(int index)
        {
            var cd = new ArrayList();
            for (int i = index; i < this._classDetails.Count; i++)
                cd.Add(this._classDetails[i]);
            return new ClassDataDesc(cd);
        }

        public void AddSuperClassDesc(ClassDataDesc scdd)
        {
            if (scdd != null)
            {
                for (int i = 0; i < scdd.GetClassCount(); i++)
                {
                    this._classDetails.Add(scdd.GetClassDetails(i));
                }
            }
        }

        public void AddClass(String className)
        {
            this._classDetails.Add(new ClassDetails(className));
        }

        public void SetLastClassHandle(int handle)
        {
            ((ClassDetails)this._classDetails[this._classDetails.Count - 1]).SetHandle(handle);
        }

        public void SetLastClassDescFlags(byte classDescFlags)
        {
            ((ClassDetails)this._classDetails[this._classDetails.Count - 1]).SetClassDescFlags(classDescFlags);
        }

        public void AddFieldToLastClass(byte typeCode)
        {
            ((ClassDetails)this._classDetails[this._classDetails.Count - 1]).AddField(new ClassField(typeCode));
        }

        public void SetLastFieldName(String name)
        {
            ((ClassDetails)this._classDetails[this._classDetails.Count - 1]).SetLastFieldName(name);
        }

        public void SetLastFieldClassName1(String cn1)
        {
            ((ClassDetails)this._classDetails[this._classDetails.Count - 1]).SetLastFieldClassName1(cn1);
        }

        public ClassDetails GetClassDetails(int index)
        {
            return (ClassDetails)this._classDetails[index];
        }

        public int GetClassCount()
        {
            return this._classDetails.Count;
        }
    }
}
