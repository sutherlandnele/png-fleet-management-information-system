```diff
╭━━━┳━╮╱╭┳━━━╮╭━━━┳╮╱╱╱╱╱╱╭╮╱╭━╮╭━╮╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╭╮╱╭━━╮╱╱╭━╮╱╱╱╱╱╱╱╱╱╱╭╮╱╱╱╱╱╱╱╱╭━━━╮╱╱╱╱╱╱╭╮
┃╭━╮┃┃╰╮┃┃╭━╮┃┃╭━━┫┃╱╱╱╱╱╭╯╰╮┃┃╰╯┃┃╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╭╯╰╮╰┫┣╯╱╱┃╭╯╱╱╱╱╱╱╱╱╱╭╯╰╮╱╱╱╱╱╱╱┃╭━╮┃╱╱╱╱╱╭╯╰╮
┃╰━╯┃╭╮╰╯┃┃╱╰╯┃╰━━┫┃╭━━┳━┻╮╭╯┃╭╮╭╮┣━━┳━╮╭━━┳━━┳━━┳╮╭┳━━┳━╋╮╭╯╱┃┃╭━┳╯╰┳━━┳━┳╮╭┳━┻╮╭╋┳━━┳━╮╱┃╰━━┳╮╱╭┳━┻╮╭╋━━┳╮╭╮
┃╭━━┫┃╰╮┃┃┃╭━╮┃╭━━┫┃┃┃━┫┃━┫┃╱┃┃┃┃┃┃╭╮┃╭╮┫╭╮┃╭╮┃┃━┫╰╯┃┃━┫╭╮┫┃╱╱┃┃┃╭╋╮╭┫╭╮┃╭┫╰╯┃╭╮┃┃┣┫╭╮┃╭╮╮╰━━╮┃┃╱┃┃━━┫┃┃┃━┫╰╯┃
┃┃╱╱┃┃╱┃┃┃╰┻━┃┃┃╱╱┃╰┫┃━┫┃━┫╰╮┃┃┃┃┃┃╭╮┃┃┃┃╭╮┃╰╯┃┃━┫┃┃┃┃━┫┃┃┃╰╮╭┫┣┫┃┃┃┃┃╰╯┃┃┃┃┃┃╭╮┃╰┫┃╰╯┃┃┃┃┃╰━╯┃╰━╯┣━━┃╰┫┃━┫┃┃┃
╰╯╱╱╰╯╱╰━┻━━━╯╰╯╱╱╰━┻━━┻━━┻━╯╰╯╰╯╰┻╯╰┻╯╰┻╯╰┻━╮┣━━┻┻┻┻━━┻╯╰┻━╯╰━━┻╯╰┻╯╰━━┻╯╰┻┻┻╯╰┻━┻┻━━┻╯╰╯╰━━━┻━╮╭┻━━┻━┻━━┻┻┻╯
╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╭━╯┃╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╭━╯┃
╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╰━━╯╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╱╰━━╯
```

---

<iframe src="https://www.cloudcode.com.pg" style="width:100%; height:600px;"></iframe>

Welcome to the repository for the PNG Fleet Management Information System, a comprehensive management information system built on the .NET Framework 4.6 using ASP.NET MVC architecture. This system is designed to manage various aspects of a vehicle fleet, enhancing operational efficiency and oversight.

This system is currently used by PNG Power Limited.

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
```bash
git clone https://github.com/sutherlandnele/png-fleet-management-information-system.git
```
2. **Set up your development environment:**
- Ensure that Visual Studio 2017/2019/2022 Pro/Ent/Ultimate Edition is installed with Licensed Telerik/Kendo UI 2029 UI Toolset
- Open the solution file in Visual Studio and restore all Nugget packages.
- Install MS SQL Server 2014 Developer Edition or above and restore the database backup file.
- Update the `web.config` file to point to the correct database and configure IIS.
- Ensure IIS Web Server is running to deploy the web application.

## Contribution

If you clone, pull, or use the ideas and source code from this repository, consider giving it a star on GitHub to show your support.

## License

This project is licensed under the GNU General Public License v3.0 - see the [LICENSE.md](LICENSE.md) file for details.

<div align="center">

### 𝚂𝚑𝚘𝚠 𝚜𝚘𝚖𝚎 ❤️ 𝚋𝚢 𝚜𝚝𝚊𝚛𝚛𝚒𝚗𝚐 this repository!

</div>
