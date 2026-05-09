# Car Rental Reservation System (C# Console Application)

## Project Overview

This project is a **C# Console Application** that simulates a real-world car rental reservation system.

It allows users to manage cars, create reservations, check availability, and generate reports such as total income and most rented cars.

The project is designed for learning:
- Object-Oriented Programming (OOP)
- Function-based system design
- Date conflict handling
- File saving/loading (JSON)
- Console menu applications
in C# language.

---

## Features

### Car Management

- Store car information in the system
- Each car has:
  - Plate number
  - Brand/Model
  - Type (SUV, Sedan, etc.)
  - Daily rental price

### Reservation System

- Create new reservations
- Prevent overlapping date reservations
- Automatically calculate total rental price
- Cancel reservations

### Reporting System

- Calculate total income
- List customer reservations
- Show most rented car
- Filter cars by type
- Show available cars by date range

### Data Storage (Bonus Feature)

- Save data to `data.json`
- Load data automatically when program starts

---

##  Technologies Used

- C#
- .NET Console Application
- Object-Oriented Programming (OOP)
- System.Text.Json (JSON file handling)

---

## Project Structure

```text
CarRentalSystem
│
├── Program.cs
├── Models
│   ├── Car.cs
│   ├── Reservation.cs
│   └── StorageModel.cs
│
└── Services
    └── RentalService.cs
```
---

## How to Run

1. Open the project in IDE
2. Make sure .NET SDK is installed (6.0 or later recommended)
3. Build the project:
- Press Ctrl + Shift + B
4. Run the project:
- Press F5 or click Start

## How to Use

-After starting the program, a console menu will appear
-Choose options by entering numbers (1, 2, 3, etc.)
-Follow the instructions shown in the console
Example workflow:
1. View available cars
2. Create a reservation
3. View reports

## Business Logic Rules

- A car cannot be reserved if the date ranges overlap
- Price is calculated using:
Total Price = Number of Days × Daily Price
- All inputs are validated before processing

## Example Console Menu

```text
~ CAR RENTAL SYSTEM ~
1 - Available Cars
2 - Add Reservation
3 - Cancel Reservation
4 - Total Income
5 - Customer Reservations
6 - Most Rented Car
7 - Car Type
0 - Exit
```

## Possible Improvements

- SQL Server database integration
- User login system (Admin / Customer roles)
- Web version using ASP.NET Core MVC
- Payment simulation system
- Advanced search & filtering system

## Author

This project was created for learning purposes to strengthen skills in:
- C# programming
- Object-Oriented Design
- Business logic implementation
- Software architecture basics
Developed by [GitHub Profile](https://github.com/irembekdemir) 

## Notes

This project focuses on:
- Clean code structure
- Separation of concerns (Models / Services)
- Real-world business logic simulation
- Beginner to intermediate C# concepts
