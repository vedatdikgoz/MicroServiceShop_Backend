# MicroServiceShopAPI

This project is a .NET 8 microservices API solution designed for an e-commerce platform, consisting of multiple independent services that communicate via RabbitMQ and are containerized using Docker. The project utilizes several modern technologies to ensure scalability, maintainability, and high performance.

## Project Structure

The microservices architecture is organized into several key components:

- **Core Services**
  - Contains the core logic and shared functionality across services.
  
- **API Gateway**
  - Manages and routes external requests to the appropriate microservices using **Ocelot**.

- **Identity Server4**
  - Identity management and authentication system built with **.NET Core 3.1** and **SQL Server**, using **JWT tokens** for secure communication.
 
- **Identity Server6**
  - Identity management and authentication system built with **.NET 8** and **SQL Server**, using **JWT tokens** for secure communication.

- **Microservices**
  - **Basket Service**: Manages user shopping baskets, backed by **Redis** for caching and session management.
  - **Catalog Service**: Handles product listings and categories, using **MongoDB** for data storage.
  - **Discount Service**: Provides discount and coupon management, utilizing **PostgreSQL** for data storage.
  - **Comment Service**: Allows users to leave reviews and comments.
  - **Message Service**: Handles messaging and notifications, stored in **PostgreSQL**.
  - **Cargo Service**: Manages delivery and shipment information.
  - **Order Service**: Processes and manages orders, using **PostgreSQL**. **MediatR** is used for handling command-query responsibilities.
  - **Invoice Service**: Manages invoice creation, storage, and management, using **MongoDB**
  - **Photo Service**: Manages photo uploads and storage via **Cloudinary**.

## Key Technologies and Tools

- **RabbitMQ**: For message brokering between microservices, implemented using the **MassTransit** library.
- **Serilog**: Logging framework integrated with **Elasticsearch** for centralized log management.
- **Cloudinary**: For cloud-based image storage and management.
- **Redis**: Used in the Basket service for fast, in-memory caching.
- **MongoDB**: NoSQL database for managing product catalog data.
- **PostgreSQL**: Relational database used in Discount, Message, and Order services.
- **SQL Server**: Relational database for Identity server management.
- **MediatR**: Used in the Order service for the Command and Query Responsibility Segregation (CQRS) pattern.
- **SignalR**: Used for real-time communication, enabling server-side code to push content to connected clients instantly.
- **AutoMapper**: For object-to-object mapping across different services.
- **JWT Authentication**: Used to secure microservices and ensure authorized access.
- **Ocelot**: API Gateway used for routing requests to the appropriate microservice.
- **Docker**: All services are containerized using Docker for easy deployment and scaling.

## Prerequisites

Before running the project, make sure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started)
- [RabbitMQ](https://www.rabbitmq.com/) (can be set up as a Docker container)
- [PostgreSQL](https://www.postgresql.org/download/)
- [MongoDB](https://www.mongodb.com/try/download/community)
- [Redis](https://redis.io/download)
- [Elasticsearch](https://www.elastic.co/downloads/elasticsearch)
- [Cloudinary](https://cloudinary.com/) account for image storage

## Logging and Monitoring
Serilog is configured to send logs to Elasticsearch. You can monitor logs by accessing your Elasticsearch instance.

## Endpoints and API Documentation
Each microservice exposes its own set of endpoints. For more detailed API documentation, refer to the Swagger documentation available at each service endpoint (e.g., /swagger).

## Contributions
Contributions are welcome! Feel free to open issues or submit pull requests to improve the project.
