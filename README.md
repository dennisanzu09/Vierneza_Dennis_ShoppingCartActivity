🛒 SHOPPING CART SYSTEM (C#)

This program is a console-based shopping cart system developed in C#. It simulates a small store where users can choose products, manage their cart, and complete a purchase with proper validation and tracking.

The system applies object-oriented concepts such as classes and objects, and uses arrays to store products, cart items, and transaction history.


---

FEATURES

Displays product menu with price and stock
User selects product and quantity
Input validation using int.TryParse() and double.TryParse()
Prevents purchasing items beyond available stock
Adds items to cart and updates quantity if item already exists

Cart management system:

View cart items

Update item quantity

Remove specific item

Clear entire cart


Checkout system:

Calculates total amount

Applies 10% discount if total ≥ ₱5000

Validates payment input

Ensures payment is sufficient before proceeding

Calculates and displays change


Receipt system:

Generates receipt number

Displays date and time of purchase

Shows items purchased with subtotal

Displays total, discount, final amount, payment, and change


Stock monitoring:

Displays low stock alert for items with 5 or fewer remaining


Order history:

Stores completed transactions

Displays list of previous receipts and totals



---

HOW TO RUN

Open the program in Visual Studio or any C# IDE
Run the program
Follow the instructions shown in the console to select items, manage your cart, and checkout

---

SCREENSHOT 

<img width="1318" height="1022" alt="image" src="https://github.com/user-attachments/assets/a3fb60a8-52f5-45e0-94f4-9e20f16ee801" />

---

AI USAGE IN THIS PROJECT

AI was used as a guide to better understand how to implement specific parts of the system. The explanations helped in building the logic step-by-step rather than copying full solutions.

AI assisted in:

Understanding how to validate user input using TryParse()
Designing the logic for updating item quantities in the cart instead of duplicating entries
Structuring loops and menus for continuous user interaction
Implementing total, subtotal, and discount calculations
Creating a clear and organized receipt output
Handling different edge cases such as:

Invalid input values

Insufficient stock

Empty cart scenarios

Invalid payment input


The final code was adjusted and rewritten based on personal understanding to ensure clarity and correctness.


---

PROMPTS USED

"How to validate user input in C# using TryParse"

"How to prevent duplicate items in an array-based cart system"

"How to compute totals and apply discounts in C#"

"How to use loops in C# to repeatedly ask user input until exit?"

"How to calculate subtotal and total in C# shopping cart?"

"How to format receipt output in a console application?"

"What edge cases should be handled in a shopping cart system?"


---

SUMMARY OF CHANGES

The program was improved from a basic shopping cart into a more complete and interactive system. The following changes were implemented:

Added a cart management menu that allows users to view, update, remove, and clear items before checkout

Implemented payment validation, ensuring that input is numeric and sufficient before completing the transaction

Added a receipt system that includes receipt number, date and time, purchased items, totals, discount, payment, and change

Introduced low stock alerts to notify users when product stock reaches 5 or below after checkout

Implemented an order history feature to store and display completed transactions

Improved input validation across the program, including strict handling of numeric inputs and Y/N prompts

---

AUTHOR

Dennis Vierneza
