import { PizzaSize } from "./OrderResponse";

export class AddOrderRequest {
  pizzaId: number;
  pizzaSize: PizzaSize;
  toppingIds: number[];

  constructor(pizzaId: number, pizzaSize: PizzaSize, toppingIds: number[]) {
    this.pizzaId = pizzaId;
    this.pizzaSize = pizzaSize;
    this.toppingIds = toppingIds;
  }
}
