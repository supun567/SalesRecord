# Software Engineer Interview Coding Challange - Cox Automotive
## Supun Kandaudahewa / 2021-06-16

## Introduction
This application was developed as to provide a solution to below user story in fullfiling a coding challange for Cox Automotive, Mississauga.

- As a user, I want to be able to upload a CSV file containing vehicle sales data and visualize the data in a web browser. In addition, I would like to display the vehicle that was sold the most often.

In this application the user will upload a CSV file which contains sales records for past years. Each record will consist of following fields

- DealNumber (integer)
- CustomerName (string)
- DealershipName (string)
- Vehicle (string)
- Price (currency)
- Date

## Languages and Technologies Used
- Dot Net Core (3.1)
- C#
- Javascript
- Bootstrap
- HTML

## Main Objectives
- Ability to read the CSV file properly.
- Visualize data.
- Display details abouts the most often sold vehicle.
- Creating Unit Tests

## Getting Started

- First the repo should be cloned using the following link
```sh
https://github.com/supun567/SalesRecord.git
```

- Then build the project. No third part party libraries were used in the devlopment, so it should build properly.
- This application will consist of two solutions, main application and the unit test project. (build both)
- The sample CSV file is located in the /CoxAutomotive/Assests folder.
- The name of the sample file is; 
```sh
Dealertrack-CSV-Example.csv
```
- When the application is executed, use the File Browser to search for the CSV file.
- After selecting the CSV file, press the Upload CSV File button.
- Clicking it should redirect you to the view which has all the details displayed.

## File Structure

- All the services are in /CoxAutomotive/Services
- Utilities file (CSVParser) is in /CoxAutomotive/Utils
- Controllers are in /CoxAutomotive/Controllers
- Models are in /CoxAutomotive/Models

## Help

Please contact me at skandaudahewa@gmail.com. I will get back to you shortly. 

