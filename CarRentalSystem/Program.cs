using CarRentalSystem.Services;

class Program {
    static void Main() {
        RentalService service = new RentalService();
        service.LoadData();

        while (true) {
            Console.WriteLine("\n~ CAR RENTAL SYSTEM ~");
            Console.WriteLine("1 - Available Cars");
            Console.WriteLine("2 - Add Reservation");
            Console.WriteLine("3 - Cancel Reservation");
            Console.WriteLine("4 - Total Income");
            Console.WriteLine("5 - Customer Reservations");
            Console.WriteLine("6 - Most Rented Car");
            Console.WriteLine("7 - Car Types");
            Console.WriteLine("0 - Exit");

            string choice = Console.ReadLine();

            if (choice == "1") {
                Console.Write("Start date: ");
                DateTime s = DateTime.Parse(Console.ReadLine());

                Console.Write("End date: ");
                DateTime e = DateTime.Parse(Console.ReadLine());

                var list = service.GetAvailableCars(s, e);

                foreach (var c in list)
                    Console.WriteLine(c);
            }

            else if (choice == "2") {
                Console.Write("Customer: ");
                string customer = Console.ReadLine();

                Console.Write("Plate: ");
                string plate = Console.ReadLine();

                Console.Write("Start: ");
                DateTime s = DateTime.Parse(Console.ReadLine());

                Console.Write("End: ");
                DateTime e = DateTime.Parse(Console.ReadLine());

                service.AddReservation(customer, plate, s, e);
            }

            else if (choice == "3") {
                Console.Write("Plate: ");
                service.CancelReservation(Console.ReadLine());
            }

            else if (choice == "4") {
                Console.WriteLine("Total income: " + service.TotalIncome());
            }

            else if (choice == "5") {
                Console.Write("Customer: ");
                var list = service.GetCustomerReservations(Console.ReadLine());

                foreach (var r in list)
                    Console.WriteLine(r);
            }

            else if (choice == "6") {
                Console.WriteLine("Most rented: " + service.MostRentedCar());
            }

            else if (choice == "7") {
                Console.Write("Type: ");
                var list = service.GetCarsByType(Console.ReadLine());

                foreach (var c in list)
                    Console.WriteLine(c);
            }

            else if (choice == "0") {
                service.SaveData();
                break;
            }
        }
    }
}
