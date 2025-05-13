#  Rental System CLI Application
This is a simple command-line rental system built in PHP. It allows users to view a list of rentable objects and reserve them for a specified duration. It also prevents double-booking and displays the reservation history. It allows users to **rent items**, **schedule reservations**, **prevent booking conflicts**, and **view reservation history**.

---

##  Features

-  **Available Items List**  
  Displays a list of objects available for rent, each with an hourly price.

-  **Make a Reservation**  
  Users can input:
  - The item name
  - The desired reservation date and time
  - The duration (in hours)

-  **Conflict Prevention**  
  If a user tries to reserve an object during a time it's already booked, the reservation will be rejected with an appropriate message.

-  **Past Date Validation**  
  Reservations cannot be made for past dates.

-  **View Reservation History**  
  Typing `h` allows the user to view the complete rental history, including:
  - Object name
  - Date and time of reservation
  - Duration

-  **Cost Calculation**  
  Total cost is calculated as:  
  `price_per_hour × duration_in_hours`

---

## How to Run

### 1. Requirements
 - PHP 8.0 or later
 - Terminal access
### 2.  Build and Run

```bash
php reservation.php 