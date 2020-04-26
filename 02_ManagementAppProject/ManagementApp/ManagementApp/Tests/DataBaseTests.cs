using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagementApp.Model;
using System.Threading.Tasks;

namespace ManagementApp.UnitTests
{
    [TestClass]
    public class DataBaseTests
    {


        [TestMethod]
        public void TaskCollectionWithCorrectPropertis()
        {
            int? taskCollectionID = null;

            TaskCollection newTaskCollection = new TaskCollection("Name");
            taskCollectionID = DataBase.AddCollection(newTaskCollection);
            Assert.IsNotNull(taskCollectionID);     /*TEST 1*/

            TaskCollection taskCollectionFromDataBase = DataBase.GetTaskCollection((int)taskCollectionID);
            Assert.AreEqual(taskCollectionFromDataBase.Name, newTaskCollection.Name);   /*TEST 2*/
            Assert.AreEqual(taskCollectionFromDataBase.Id, newTaskCollection.Id);   /*TEST 3*/

            DataBase.DeleteCollection((int)taskCollectionID);
        }

        [TestMethod]
        public void TaskWithCorrectPropertis()
        {
            int? taskID = null; 
            int? taskCollectionID = null;
            TaskCollection newTaskCollection = new TaskCollection("Name");
            taskCollectionID = DataBase.AddCollection(newTaskCollection); 

            Model.Task newTask = new Model.Task("Name",(int)taskCollectionID, DateTime.Now);
            taskID = DataBase.AddTask(newTask);
            Assert.IsNotNull(taskID);   /*TEST 1*/

            Model.Task taskFromDataBase = DataBase.GetTask((int)taskID);
            Assert.AreEqual(taskFromDataBase.Name, newTask.Name);   /*TEST 2*/
            Assert.AreEqual(taskFromDataBase.Id, newTask.Id); /*TEST 3*/

            DataBase.DeleteCollection((int)taskCollectionID);
        }


        [TestMethod]
        public void PointWithCorrectPropertis()
        {
            int? pointID = null;
            int? taskID = null;
            int? taskCollectionID = null;

            TaskCollection newTaskCollection = new TaskCollection("Name");
            taskCollectionID = DataBase.AddCollection(newTaskCollection);
            Model.Task newTask = new Model.Task("Name", (int)taskCollectionID, DateTime.Now);
            taskID = DataBase.AddTask(newTask);
            Model.Point newPoint = new Model.Point("Name", (int)taskID, DateTime.Now);
            pointID = DataBase.AddPoint(newPoint);

            Assert.IsNotNull(pointID); /*TEST 1*/

            Model.Point pointFromDataBase = DataBase.GetPoint((int)pointID);
            Assert.AreEqual(pointFromDataBase.Name,newPoint.Name );/*TEST 2*/
            Assert.AreEqual(pointFromDataBase.Id, newPoint.Id);/*TEST 3*/

            DataBase.DeleteCollection((int)taskCollectionID);
        }
    }
}
