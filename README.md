# RentalApp - Console-Based Rental Management System in Rust

## 📖 Overview

**RentalApp** is a simple command-line application written in Rust that simulates a basic rental service system. It allows users to view a list of rentable fr, check availability, make reservations by selecting a date and duration, and see their booking history. Each item has an hourly rental rate, and the application ensures proper validation, such as disallowing past reservations.

---

## 🧰 Features

- 📋 Display available items with hourly prices
- 📅 Reserve an item by providing a valid future date and time
- ⏱️ Specify rental duration in hours
- 💸 Automatically calculate the total cost based on item rate and duration
- ❌ Handle errors such as unknown items, past dates, and invalid formats
- 📜 View booking history at any time with a simple command

---

## 🧾 Available Items for Rent

| Item         | Price/Hour (Ar) |
|--------------|-----------------|
| 🚗 Voiture    | 10,000          |
| 🍽️ Assiette   | 2,000           |
| 🚲 Vélo       | 5,000           |
| 📱 Téléphone  | 15,000          |
| 💻 Ordinateur | 20,000          |
| 🏠 Maison     | 50,000          |

---

## 🚀 Getting Started

### 1. 📦 Install Go

If you don’t have Go installed:

```bash
sudo snap install go --classic
# OR
sudo apt update && sudo apt install golang-go
