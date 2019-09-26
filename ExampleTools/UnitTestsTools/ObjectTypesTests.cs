using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ToolClasses;

namespace UnitTestsTools
{
    [TestFixture]
    class ObjectTypesTests
    {
        [Test]
        public void can_create_objects()
        {
            ObjectStruct objStruct = new ObjectStruct("Struct0");
            Assert.That(objStruct.NameObject == "Struct0");
            Assert.That(objStruct.Type == "Value");

            ObjectClass objClass = new ObjectClass("Class0");
            Assert.That(objClass.NameObject == "Class0");
            Assert.That(objClass.Type == "Reference");
        }

        [Test]
        public void test_changing_properties()
        {
            ObjectStruct objStruct = new ObjectStruct("Struct0");
            ObjectStruct tmpVarStruct = objStruct;
            tmpVarStruct.NameObject = "ChangedName";
            tmpVarStruct.Type = "ChangedType";

            Assert.That(objStruct.NameObject == "Struct0");
            Assert.That(objStruct.Type == "Value");

            Assert.That(tmpVarStruct.NameObject == "ChangedName");
            Assert.That(tmpVarStruct.Type == "ChangedType");

            ObjectClass objClass = new ObjectClass("Class0");
            ObjectClass tmpVarClass = objClass;
            tmpVarClass.NameObject = "ChangedName";
            tmpVarClass.Type = "ChangedType";

            Assert.That(objClass.NameObject == "ChangedName");
            Assert.That(objClass.Type == "ChangedType");

            Assert.That(tmpVarClass.NameObject == "ChangedName");
            Assert.That(tmpVarClass.Type == "ChangedType");

            ChangingValueTest0(tmpVarStruct, tmpVarClass);
            Assert.That(tmpVarStruct.NameObject == "ChangedName");
            Assert.That(tmpVarStruct.Type == "ChangedType");
            Assert.That(tmpVarClass.NameObject == "ChangedTest0Name");
            Assert.That(objClass.NameObject == "ChangedTest0Name");
            Assert.That(objClass.Type == "Reference");

            ChangingValueTest1(ref tmpVarStruct, ref tmpVarClass);
            Assert.That(tmpVarStruct.NameObject == "ChangedTest1Name");
            Assert.That(tmpVarClass == null);
            Assert.That(objClass == null);
        }

        /* This is of particular interest when passing parameters to methods.
         * In C#, parameters are (by default) passed by value, meaning that they are implicitly copied when passed to the method.
         */
        void ChangingValueTest0(ObjectStruct objS, ObjectClass objC)
        {
            /* For value-type parameters, this means physically copying the instance (in the same way of a struct was copied),
             * while for reference-types it means copying a reference (in the same way of a reference was copied).
             */
            objS.NameObject = "ChangedTest0Name";
            objC.NameObject = "ChangedTest0Name";
            objC = null;
        }

        void ChangingValueTest1(ref ObjectStruct objS, ref ObjectClass objC)
        {
            objS.NameObject = "ChangedTest1Name";
            objC.NameObject = "ChangedTest1Name";
            objC = null;
        }
    }
}
