# LocationApp
#  Rental Management Console App

Welcome to the **Rental Management Console Application**, a simple and interactive system to manage the rental of various objects (e.g. car, plate, bicycle). The application is designed for terminal use, where users can make reservations by selecting available items, specifying the start date/time, and rental duration.

---

##  Features

- Interactive welcome interface in the console.
-  List of available items to rent with hourly pricing:
  - **Car**: 10,000 Ar/hour
  - **Assiette**: 2,000 Ar/hour
  - **Bicycle**: 5,000 Ar/hour
  - **Tente**: 15,000 Ar/hour
  - **Ordinateur**: 20,000 Ar/hour
  - **Caméra**: 30,000 Ar/hour
  - **Projecteur**: 25,000 Ar/hour
-  Validates input dates to prevent reservations in the past.
-  Calculates total rental cost based on duration and item price.
-  Maintains a reservation history.
-  Users can view history anytime using a special command.
-  Error handling for unknown items and invalid inputs.


##  How to Compile and Run with Mono (mcs)

###  Prerequisites
- [Mono](https://www.mono-project.com/download/stable/) installed

###  Compilation
Suppose your source files are:

- `Program.cs`
- `Objet.cs`
- `Reservation.cs`
- `ServiceReservation.cs`

You can compile them all into a single executable like this:

```bash
mcs *.cs -out:LocationApp.exe 
```
### Execution
```bash
mono LocationApp.exe
```