# 📝 Console To-Do List

A robust, color-coded console application for managing tasks, built with **C#** and **.NET**. This project focuses on clean architecture, safe user input handling, and file persistence.

## ✨ Features

* **Task Management:** Create, delete, and mark tasks as completed.
* **Persistent Storage:** Custom Save/Load system using a delimiter format (`Name$Difficulty$Status`), ensuring data survives application restarts.
* **Smart Input Validation:**
    * Prevents crashes on invalid inputs (non-integer IDs).
    * **"Trap-free" navigation:** Press `'q'` at any input prompt to return to the main menu safely.
* **Visual Feedback:** Color-coded messages (Green for success, Red for errors) and visual indicators for task status (✅ Completed / ❌ Pending).
* **Task Difficulty:** Assign difficulty levels (1-5) to tasks.

## 🏗️ Technical Highlights

The project follows **Clean Code** principles and demonstrates the transition from procedural logic to OOP:

* **`Program.cs`**: Entry point handling the main application loop.
* **`ToDoList.cs`**: Encapsulates business logic and data management.
* **`ToDoItem.cs`**: Data model representing a single task.
* **`ConsoleHelper.cs`**: A **static helper class** strictly for UI/UX, separating presentation from logic.
* **File I/O**: Implements custom serialization logic using `StreamReader`/`StreamWriter` equivalent methods.

## 🚀 How to Run

1.  Clone the repository or download the source code.
2.  Navigate to the project folder in your terminal.
3.  Run the application:
    ```bash
    dotnet run
    ```

## 🧠 What I Learned

This project was built to master C# fundamentals:
* **OOP Principles:** Encapsulation, Properties, and Methods.
* **File Handling:** Reading/Writing text files and string parsing (`Split`).
* **Static Classes:** Using utility classes to adhere to DRY (Don't Repeat Yourself).
* **Error Handling:** Using `TryParse` patterns for robust application stability.

---
*Built with ❤️ in C#*
