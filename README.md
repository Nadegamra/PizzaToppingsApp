# Present Connection Internship Technical assignment
## Launch instructions
Execute `docker compose up` from project root
## The task
### Task Description
Create a web application to calculate a pizza order’s total cost and review submitted orders.
### Technical requirements
- [x] The application should allow users to select the size and toppings for their pizza order.
- [x] The application should calculate the total cost of the order based on the size and toppings selected.
- [x] The application should display the total cost of the order to the user.
- [x] User should be able to save orders and view all saved orders in a list.
- [x] Order list should be on a separate page.

Calculation rules:
- [x] The cost of the pizza should be based on the size selected. Small pizzas cost €8, medium pizzas cost
€10, and large pizzas cost €12.
- [x] The cost of each topping should be added to the base cost of the pizza. The toppings cost $1 each.
- [x] If the user selects more than 3 toppings, a discount of 10% should be applied to the total cost.
### Technical requirements
- [x] The back end should be built using ASP.NET Core and should use an EF Core in-memory database to
store pizza size and topping data.
- [x] The front end should be built using React and can use a modern UI library such as Bootstrap or
Material UI.
- [x] All calculation logic must be implemented in the back end.
### Nice to have (optional)
- [x] Unit tests in the backend.
- [ ] Web app deployed and accessible via a public URL.
