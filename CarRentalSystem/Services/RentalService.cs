using CarRentalSystem.Models;
using System.Text.Json;

namespace CarRentalSystem.Services
{
    public class RentalService
    {
        private List<Car> cars = new List<Car>();
        private List<Reservation> reservations = new List<Reservation>();

        public RentalService()
        {
            cars.Add(new Car { Plate = "06ABC123", BrandModel = "Toyota Corolla", Type = "Sedan", DailyPrice = 1500 });
            cars.Add(new Car { Plate = "34XYZ789", BrandModel = "Honda Civic", Type = "Sedan", DailyPrice = 1700 });
        }

        public List<string> GetAvailableCars(DateTime start, DateTime end)
        {
            List<string> result = new List<string>();

            foreach (var car in cars)
            {
                if (IsCarAvailable(car.Plate, start, end))
                    result.Add($"{car.Plate} - {car.BrandModel}");
            }

            return result;
        }

        public bool IsCarAvailable(string plate, DateTime start, DateTime end)
        {
            foreach (var r in reservations)
            {
                if (r.Plate == plate)
                {
                    if (start <= r.EndDate && end >= r.StartDate)
                        return false;
                }
            }
            return true;
        }

        public double GetDailyPrice(string plate)
        {
            foreach (var c in cars)
                if (c.Plate == plate)
                    return c.DailyPrice;

            return 0;
        }

        public List<string> GetCarsByType(string type)
        {
            List<string> list = new List<string>();

            foreach (var c in cars)
                if (c.Type.ToLower() == type.ToLower())
                    list.Add($"{c.Plate} - {c.BrandModel}");

            return list;
        }

        public void AddReservation(string customer, string plate, DateTime start, DateTime end)
        {
            if (!IsCarAvailable(plate, start, end))
            {
                Console.WriteLine("Car is NOT available!");
                return;
            }

            double price = CalculatePrice(plate, start, end);

            reservations.Add(new Reservation
            {
                CustomerName = customer,
                Plate = plate,
                StartDate = start,
                EndDate = end,
                TotalPrice = price
            });

            Console.WriteLine("Reservation created. Price: " + price);
        }

        public double CalculatePrice(string plate, DateTime start, DateTime end)
        {
            int days = (end - start).Days;
            return days * GetDailyPrice(plate);
        }

        public void CancelReservation(string plate)
        {
            reservations.RemoveAll(r => r.Plate == plate);
            Console.WriteLine("Reservation cancelled.");
        }

        public double TotalIncome()
        {
            double total = 0;

            foreach (var r in reservations)
                total += r.TotalPrice;

            return total;
        }

        public List<string> GetCustomerReservations(string customer)
        {
            List<string> list = new List<string>();

            foreach (var r in reservations)
            {
                if (r.CustomerName == customer)
                    list.Add($"{r.Plate} ({r.StartDate.ToShortDateString()} - {r.EndDate.ToShortDateString()})");
            }

            return list;
        }

        public string MostRentedCar()
        {
            Dictionary<string, int> count = new Dictionary<string, int>();

            foreach (var r in reservations)
            {
                if (count.ContainsKey(r.Plate))
                    count[r.Plate]++;
                else
                    count[r.Plate] = 1;
            }

            string best = "";
            int max = 0;

            foreach (var item in count)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                    best = item.Key;
                }
            }

            return best;
        }

        public void SaveData()
        {
            var data = new StorageModel
            {
                Cars = cars,
                Reservations = reservations
            };

            File.WriteAllText("data.json",
                JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void LoadData()
        {
            if (!File.Exists("data.json"))
                return;

            var data = JsonSerializer.Deserialize<StorageModel>(
                File.ReadAllText("data.json"));

            if (data != null)
            {
                cars = data.Cars ?? new List<Car>();
                reservations = data.Reservations ?? new List<Reservation>();
            }
        }
    }
}
