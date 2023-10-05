import { Pizza } from "./Pizza";
import { Topping } from "./Topping";

export class OrderResponse {
  id: number;
  pizza: Pizza;
  price: number;
  pizzaSize: PizzaSize;
  orderToppings: Topping[];

  constructor(
    id: number,
    pizza: Pizza,
    price: number,
    pizzaSize: PizzaSize,
    toppings: Topping[]
  ) {
    this.id = id;
    this.pizza = pizza;
    this.price = price;
    this.pizzaSize = pizzaSize;
    this.orderToppings = toppings;
  }
}

export enum PizzaSize {
  Small = 1,
  Medium,
  Large,
}
