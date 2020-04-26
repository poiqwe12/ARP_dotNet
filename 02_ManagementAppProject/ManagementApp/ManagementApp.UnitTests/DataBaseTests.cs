using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagementApp.Model;


namespace ManagementApp.UnitTests
{

    [TestClass]
    public class DataBaseTests
    {
        [TestMethod]
        public void TaskCollectionWithCorectPropertis_Add_Get()
        {
            
            TaskCollection newTaskCollection = new TaskCollection("Name");
            newTaskCollection.Id = 9999;
            DataBase.AddCollection(newTaskCollection);

            //TaskCollection taskCollectionFromDataBase = DataBase.GetTaskCollection(9999);
            //DataBase.DeleteCollection(9999);

            //Assert.AreEqual(taskCollectionFromDataBase.Name, newTaskCollection.Name);
           // Assert.AreEqual(taskCollectionFromDataBase.Id, newTaskCollection.Id);

        }

        [TestMethod]
        public void TaskCollectionWithWalidPropertis_Add_Get()
        {

            DataBase.GetAllPointsList();
           //TaskCollection newTaskCollection = new TaskCollection("Name");
           // DataBase.AddCollection(newTaskCollection);
        }


    }
}
