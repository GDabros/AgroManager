# AgroManager

This program is a console application designed to manage various aspects of a farm. 
It allows users to create and update farm details such as the farm's name, location, fields, crops, harvests, soil treatments, and stock items.

The application is structured with a clear separation of responsibilities:

Service Classes manage business logic and data operations, such as creating, saving, and updating farm entities like crops or harvest records.
Manager Classes handle user interactions, collecting inputs via the console and passing them to the service classes for processing.
Through this setup, users can perform tasks such as adding new fields, recording harvests, scheduling treatments, managing soil tests, and tracking stock items. 
The program is modular and can be extended to include additional farm management functionalities.
