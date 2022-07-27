using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using patternPrediction.DataSet1TableAdapters;
using System.Data;

namespace patternPrediction
{
    public class Class1
    {
        //Business Logic Layer - class which contains class members n member functions
        tblAdminTableAdapter adminObj = new tblAdminTableAdapter();
        tblCitiesTableAdapter cityObj = new tblCitiesTableAdapter();
        tblInChargersTableAdapter inchargerObj = new tblInChargersTableAdapter();
        tblDataTableAdapter dataObj = new tblDataTableAdapter();

        tblTestingDataTableAdapter testObj = new tblTestingDataTableAdapter();
        tblActualDataTableAdapter actualObj = new tblActualDataTableAdapter();

        //function to check the admin Login
        public bool CheckAdminLogin(string adminId, string password)
        {
            int cnt = int.Parse(adminObj.CheckAdminLogin(adminId, password).ToString());

            if (cnt == 1)

                return true;

            else

                return false;
        }

        //function to check IC login
        public bool CheckICLogin(string ICId, string password)
        {
            int cnt = int.Parse(inchargerObj.CheckICLogin(ICId, password).ToString());

            if (cnt == 1)

                return true;

            else

                return false;
        }

        //function to get admin by id
        public DataTable GetAdminById(string adminId)
        {
            return adminObj.GetAdminById(adminId);
        }

        //function to update the admin password
        public void UpdateAdminPassword(string newpassword, string adminId)
        {
            adminObj.UpdateAdminPassword(newpassword, adminId);
        }

        //Manage Cities

        //function to get all cities
        public DataTable GetCities()
        {
            return cityObj.GetData();
        }

        //function to get city by id
        public DataTable GetCityById(int cityId)
        {
            return cityObj.GetCityById(cityId);
        }

        //function to insert city
        public void InsertCity(string city)
        {
            cityObj.InsertCity(city);
        }

        //function to delete city
        public void DeleteCity(int cityId)
        {
            cityObj.DeleteCity(cityId);
        }

        //function to check the city name
        public bool CheckCity(string city)
        {
            int cnt = int.Parse(cityObj.CheckCity(city).ToString());

            if (cnt == 1)

                return false;

            else

                return true;
        }

        //Manage Hospital Inchargers

        //function to reterive all ICs
        public DataTable GetICs()
        {
            return inchargerObj.GetData();
        }

        //function to get IC by Id
        public DataTable GetICById(string ICId)
        {
            return inchargerObj.GetInchargerById(ICId);
        }

        //function to insert new IC
        public void InsertIC(string ICId, string password, string name, string address, int cityId, string contactNo, string emailId)
        {
            inchargerObj.InsertIncharger(ICId, password, name, address, contactNo, emailId, cityId);
        }

        //function to update IC
        public void UpdateIC(string ICId, string password, string name, string address, int cityId, string contactNo, string emailId, string IAId1)
        {
            inchargerObj.UpdateIncharger(ICId, password, name, address, contactNo, emailId, cityId, IAId1);
        }

        //function to delete IC
        public void DeleteIA(string ICId)
        {
            inchargerObj.DeleteIncharger(ICId);
        }

        //function to check the ICId
        public bool CheckICId(string ICId)
        {
            int cnt = int.Parse(inchargerObj.CheckInchargerId(ICId).ToString());

            if (cnt == 1)

                return false;

            else

                return true;
        }

        //function to update the IC Password
        public void UpdateICPassword(string newPassword, string icId)
        {
            inchargerObj.UpdateICPassword(newPassword, icId);
        }

        //Data Module

        //function to insert data
        public void InsertData(string inchargeId, DateTime date, int P1, int P2, int P3, int P4, int P5, int P6, int P7, int P8,
            int result)
        {
            dataObj.InsertData(inchargeId, date, P1, P2, P3, P4, P5, P6, P7, P8, result);
        }

        //function to update data
        public void UpdateData(string inchargeId, DateTime date, int P1, int P2, int P3, int P4, int P5, int P6, int P7, int P8,
            int result, int dataId)
        {
            dataObj.UpdateData(inchargeId, date, P1, P2, P3, P4, P5, P6, P7, P8, result, dataId);
        }

        //function to delete data
        public void DeleteData(int dataId)
        {
            dataObj.DeleteData(dataId);
        }

        //function to get data by id
        public DataTable GetDataById(int dataId)
        {
            return dataObj.GetDataById(dataId);
        }

        //function to get data by branch
        public DataTable GetDataByBranch(string branch)
        {
            return dataObj.GetDataByBranch(branch);
        }

        //function to get testing data
        public DataTable GetTestingData()
        {
            return testObj.GetData();
        }

        //function to get actual data
        public DataTable GetActualData()
        {
            return actualObj.GetData();
        }
    }
}