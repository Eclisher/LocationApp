#  Rental System CLI Application

This is a simple command-line based rental system built with Rust. It allows users to **rent items**, **schedule reservations**, **prevent booking conflicts**, and **view reservation history**.

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

### 1.  Prerequisites
- Install Rust: https://www.rust-lang.org/tools/install

### 2.  Build and Run

```bash
cargo build
cargo run