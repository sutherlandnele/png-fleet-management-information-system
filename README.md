# PNG Fleet Management Information System

Welcome to the repository for the PNG Fleet Management Information System, a comprehensive management information system built on the .NET Framework 4.6 using ASP.NET MVC architecture. This system is designed to manage various aspects of a vehicle fleet, enhancing operational efficiency and oversight.

## Features

This application provides a wide range of features including:

- **Vehicle Information Management**: Centralize all vehicle data for easy access and management.
- **Vehicle Fuel, Voucher & Depo Management**: Track and manage fuel usage, vouchers, and depo details.
- **Vehicle Service, Workshop, Parts Inventory & Mechanics Management**: Maintain detailed records of services, manage workshops, inventory of parts, and mechanics.
- **Vehicle Allocation Management**: Handle the allocation of vehicles to different departments or individuals.
- **Vehicle Compliance Management**: Ensure all vehicles are compliant with registration and safety regulations.
- **Vehicle Incident Management**: Record and manage incidents involving fleet vehicles.
- **Management Information System Reporting**: Generate comprehensive reports for informed decision-making.
- **System Administration**: Manage system settings and configurations.

## Technical Architecture

The application is structured into several layers:

- **Database**: MS SQL Server 2014.
- **FMS.Data**: ORM layer with Entity Framework for database first mapping.
- **FMS.Model**: Handles mapping of database objects to the ViewModel using AutoMapper.
- **FMS.Report**: Provides reporting functionalities using Telerik Reporting UI controls.
- **FMS.Service**: Contains business logic.
- **FMS.Web**: Manages the presentation layer with Telerik UI controls and Razor Markup.
- **FMS.Common**: Includes common methods needed across the application.

## Getting Started

To set up and run the project locally, follow these steps:

1. **Clone the repository:**
