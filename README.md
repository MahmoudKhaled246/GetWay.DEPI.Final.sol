# GetWay - Online Courses Platform

Welcome to **GetWay**, an online courses platform built using **.NET**. This platform provides a seamless experience for students and instructors, enabling students to enroll in courses and instructors to add new courses. With a robust architecture and efficient design patterns, GetWay is the perfect solution for anyone looking to learn and teach online.

## Features
- **3-tier Architecture**: Separates the application into three main layers: Presentation, Business Logic, and Data Access, ensuring modularity, scalability, and ease of maintenance.
- **Generic Repository Pattern**: A flexible and reusable approach for managing data access, allowing easy integration with multiple data sources.
- **Unit of Work Pattern**: Manages database transactions efficiently, ensuring that operations across multiple repositories are handled in a single transaction.
- **Identity Package**: Provides user authentication and authorization for two main user roles (Instructor and Student), with secure login and registration processes.
- **MVC Architecture**: Implements Model-View-Controller to separate concerns and streamline user interface and business logic.
  
## Installation

Follow these steps to get **GetWay** running locally.

1. Clone this repository:
    ```bash
    git clone https://github.com/MahmoudKhaled246/GetWay.DEPI.Final.sol.git
    ```
2. Navigate to the project directory:
    ```bash
    cd GetWay
    ```
3. Open the solution file in Visual Studio:
    ```bash
    GetWay.sln
    ```
4. Install the required NuGet packages:
    - Microsoft.AspNetCore.Identity
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
5. Update the connection string in the `appsettings.json` file to match your local database configuration.
   
6. Run the application using Visual Studio or via the .NET CLI:
    ```bash
    dotnet run
    ```

## Architecture

### 3-tier Architecture
The platform is built with a 3-tier architecture consisting of:
- **Presentation Layer**: The user interface, where all user interactions happen. This layer handles views and controllers in the MVC pattern.
- **Business Logic Layer (BLL)**: Contains services that handle the business logic, such as course management and user roles.
- **Data Access Layer (DAL)**: Interacts directly with the database, using the repository pattern for data retrieval and storage.

### Design Patterns
- **Generic Repository Pattern**: A generic repository is used to provide a common data access interface. This pattern helps to avoid code duplication and allows the handling of multiple entities with the same operations.
- **Unit of Work Pattern**: This pattern is used to manage the interactions between multiple repositories in a single transaction, ensuring data integrity.

## Authentication & Authorization

The **Identity package** is used to handle user authentication and authorization. The platform supports two main roles:
- **Instructor**: Can create and manage courses.
- **Student**: Can browse, enroll in, and complete courses.

## Features for Users

- **Instructor**: Can create, manage, and update courses.
- **Student**: Can browse available courses, enroll in them, and complete the course content.

## Contributing

Feel free to fork this project and contribute. If you find any bugs or want to add a new feature, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-name`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-name`).
5. Create a new Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For any questions or issues, feel free to open an issue or contact me at:  
**Email**: mahmoudkhaled4812@gmail.com  
**GitHub**: [github.com/MahmoudKhaled246](https://github.com/MahmoudKhaled246)

---

Thank you for using **GetWay**. Happy Learning!
