# CRUD-Produto.ADO-NET.UnidadeTerra

## Introduction

## Make sure to change the connection string in the `DbSet.cs` file located inside the `proxy` folder to match your database configuration.

Hello fellow user,

I'd like to explain the idea of this project. This project started as a challenge from UnidadeTerra. The initial goal was to create a CRUD (Create, Read, Update, Delete) application using ADO.NET. After completing the CRUD functionality, I thought it would be interesting to try and replicate the `DbSet<T>` functionality from Entity Framework Core (EF.Core).

## Project Overview

This project features a basic version of `DbSet<T>` with the main methods required to communicate with a database:

- **Create**: Add new entries to the database.
- **List**: Retrieve entries from the database.
- **Update**: Modify existing entries in the database.
- **Delete**: Remove entries from the database.

Currently, it does not support many-to-many (N-to-N) relationships natively, but you can achieve similar functionality using LINQ.

## Usage

The project does not include a menu because the idea was to simulate how EF.Core works. You can try the CRUD operations just as you would with EF.Core:

1. **Create or use a DbContext**: This will manage the database connections and operations.
2. **Create repositories, services, or any other architecture**: Utilize these to perform CRUD operations on your entities.

## Feedback

If you have any feedback, feel free to create an issue on the main repository. Your suggestions are greatly appreciated.

Thanks for reading!
