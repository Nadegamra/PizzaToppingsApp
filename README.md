# Pizzas toppings selection app
## The task
### Task Description
This intership admission technical assignment for PresentConnection
Create a web application to calculate a pizza order’s total cost and review submitted orders.
### Functional requirements
- [x] The application should allow users to select the size and toppings for their pizza order.
- [x] The application should calculate the total cost of the order based on the size and toppings selected.
- [x] The application should display the total cost of the order to the user.
- [x] User should be able to save orders and view all saved orders in a list.
- [x] Order list should be on a separate page.

Calculation rules:\
• The cost of the pizza should be based on the size selected. Small pizzas cost €8, medium pizzas cost
€10, and large pizzas cost €12.\
• The cost of each topping should be added to the base cost of the pizza. The toppings cost $1 each.\
• If the user selects more than 3 toppings, a discount of 10% should be applied to the total cost.\
### Technical requirements
• The back end should be built using ASP.NET Core and should use an EF Core in-memory database to
store pizza size and topping data.\
• The front end should be built using React and can use a modern UI library such as Bootstrap or
Material UI.\
• All calculation logic must be implemented in the back end.\
### Nice to have (optional)
- [x] Unit tests in the backend.
- [x] Web app deployed and accessible via [here](https://nadegamrapizzaapp.azurewebsites.net/).
## Tech Stack
The app consists of:
- .NET 7.0 WebApi with EF Core in-memory database
- React.js + Typescript + Tailwind frontend
- Nginx proxy used for mapping requests for ports 80 and 443 to backend/frontend
## Launch instructions
### Development build
Execute `docker compose -f docker-compose.yml -f docker-compose.dev.yml up` from project root
### Production build
Execute `docker compose -f docker-compose.yml -f docker-compose.prod.yml up` from project root
## API reference
- [PizzasController](docs/PizzasController.md)
- [ToppingsController](docs/ToppingsController.md)
- [OrdersController](docs/OrdersController.md)