using EdgeSimulator.Core;
using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace EdgeReaderFunctionApp
{
    public class StorageService
    {
        SqlCommand sqlCommand = null;
        static string connString = "<ADD MS SQL DATABASE CONNECTION STRING HERE>";

        public StorageService()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                connection.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Save(DeviceData eventData)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(eventData);
                sqlCommand.CommandText = string.Format($"insert into tblBits(Id, DeviceId, DataKey, DataValue, Logged, Received) values('{eventData.Id}', '{eventData.DeviceId}', '{eventData.DataKey}', '{eventData.DataValue}', '{eventData.Logged}', '{DateTime.UtcNow}')");
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
