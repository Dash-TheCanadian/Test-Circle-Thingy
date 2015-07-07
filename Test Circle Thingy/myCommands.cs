using System;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Toolbox.AutoCAD;

// This line is not mandatory, but improves loading performances
[assembly: CommandClass(typeof(Test_Circle_Thingy.MyCommands))]

namespace Test_Circle_Thingy
{
    public class MyCommands
    {
        [CommandMethod("MyCommand")]
        public void MyCommand() // This method can have any name
        {
            Active.Editor.WriteMessage("\nThis will add a circle to the current space!");

            // Put your command code here
            PromptPointOptions ppo = new PromptPointOptions("Pick the centre of the circle");
            PromptPointResult ppr = Active.Editor.GetPoint(ppo);

            if (ppr.Status != PromptStatus.OK)
                return;

            Point3d pt = ppr.Value;

            PromptDistanceOptions pdo = new PromptDistanceOptions("Pick radius") {
                UseBasePoint = true,
                BasePoint = pt,
                AllowArbitraryInput = true
            };

            PromptDoubleResult pdr = Active.Editor.GetDistance(pdo);

            if (pdr.Status != PromptStatus.OK)
                return;

            double dist = pdr.Value;

            using (Transaction tr = Active.Database.TransactionManager.StartTransaction())
            {
                Circle circle = new Circle(pt, Vector3d.ZAxis, dist);

                BlockTableRecord btr = (BlockTableRecord) tr.GetObject(Active.Database.CurrentSpaceId, OpenMode.ForWrite);

                btr.AppendEntity(circle);
                tr.AddNewlyCreatedDBObject(circle, true);

                tr.Commit();
            }
        }
    }
}
