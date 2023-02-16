using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Security.Policy;
using System.Web.Http;
using System.Windows.Forms;
using TestTask.Models;
using XAct;

namespace TestTask.Controllers
{
    public class TaskController : ApiController
    {
        DB dB = new DB("Task");

        public DataTable Execute(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand(query, dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(dataTable);
            return dataTable;
        }

        [HttpGet, Route("cities")]
        public IEnumerable<Cities> GetCities()
        {
            List<Cities> cities = new List<Cities>();
            string query = $"" +
                            $"SELECT Cities.id, Cities.name, COUNT(Streets.id) as street_count   " +
                            $"FROM Cities LEFT JOIN Streets   ON Cities.id = Streets.city_id  " +
                            $"GROUP BY Cities.id, Cities.name";

            var dataTable = Execute(query);

            foreach (DataRow row in dataTable.Rows)
            {
                var city = new Cities
                {
                    Id = (int)row["id"],
                    name = (string)row["name"],
                    count = (int)row["street_count"]
                };
                cities.Add(city);
            }
            return cities;
        }

        [HttpGet, Route("cities/{city_id}/streets")]
        public IEnumerable<Streets> GetStreets(int city_id)
        {
            List<Streets> streets = new List<Streets>();

            string query = $"" +
                $"SELECT Streets.id, Streets.name, COUNT(Houses.id) AS num_houses    " +
                $"FROM Streets  " +
                $"INNER JOIN Cities ON Streets.city_id = Cities.id  " +
                $"INNER JOIN Houses ON Streets.id = Houses.street_id    " +
                $"WHERE Cities.id = '{city_id}' " +
                $"GROUP BY Streets.id, Streets.name";

            var dataTable = Execute(query);

            foreach (DataRow row in dataTable.Rows)
            {
                var street = new Streets
                {
                    id = (int)row["id"],
                    name = (string)row["name"],
                    count = (int)row["num_houses"]
                };
                streets.Add(street);
            }
            return streets;
        }

        [HttpGet, Route("cities/{city_id}/houses")]
        public IEnumerable<Houses> GetHousesCities(int city_id) 
        {
            string q = $"" +
                $"SELECT Cities.name AS city_name, Streets.name AS street_name, Houses.number AS house_number, COUNT(Apartments.id) AS num_apartments     " +
                $"FROM Cities     " +
                $"JOIN Streets ON Cities.id = Streets.city_id    " +
                $"JOIN Houses ON Streets.id = Houses.street_id   " +
                $"JOIN Apartments ON Houses.id = Apartments.house_id    " +
                $"WHERE Cities.id = {city_id}    " +
                $"GROUP BY Cities.name, Streets.name, Houses.number;";
            return GetHouses(q);
        }

        [HttpGet, Route("streets/{street_id}/houses")]
        public IEnumerable<Houses> GetHousesStreets(int street_id)
        {
            string q = $"" +
                $"SELECT Cities.name AS city_name, Streets.name AS street_name, Houses.number AS house_number, COUNT(Apartments.id) AS num_apartments " +
                $"FROM Cities " +
                $"JOIN Streets ON Streets.city_id = Cities.id " +
                $"JOIN Houses ON Houses.street_id = Streets.id " +
                $"JOIN Apartments ON Apartments.house_id = Houses.id " +
                $"WHERE Streets.id = {street_id}" +
                $"GROUP BY Cities.name, Streets.name, Houses.number;";
            return GetHouses(q);
        }

        [HttpGet, Route("cities/{city_id}/streets/{street_id}/houses")]
        public IEnumerable<Houses> GetHousesFull(int city_id,int street_id) 
        {
            string q = $"" +
                $"SELECT c.name AS city_name, s.name AS street_name, h.number AS house_number, COUNT(*) AS num_apartments " +
                $"FROM Cities c " +
                $"JOIN Streets s ON c.id = s.city_id " +
                $"JOIN Houses h ON s.id = h.street_id " +
                $"JOIN Apartments a ON h.id = a.house_id " +
                $"WHERE c.id = {city_id} AND s.id = {street_id} " +
                $"GROUP BY c.name, s.name, h.number";

            return GetHouses(q);
        }

        private IEnumerable<Houses> GetHouses(string q) 
        {
            List<Houses> houses = new List<Houses>();

            var dataTable = Execute(q);

            foreach (DataRow row in dataTable.Rows)
            {
                var city = (string)row["city_name"];
                var street_name = (string)row["street_name"];
                var house = new Houses
                {
                    name = (string)row["house_number"],
                    address = $"г.{city},ул.{street_name}",
                    count = (int)row["num_apartments"]
                };
                houses.Add(house);
            }
            return houses;
        }
    }
}
