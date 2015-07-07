using System;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

// This line is not mandatory, but improves loading performances
[assembly: CommandClass(typeof(Test_Circle_Thingy.MyCommands))]

namespace Test_Circle_Thingy
{
    public class MyCommands
    {
        [CommandMethod("MyCommand")]
        public void MyCommand() // This method can have any name
        {
            // Put your command code here

        }
    }
}
