import { OrderResponse, PizzaSize } from "../../data/dtos/OrderResponse";

interface Props {
  order: OrderResponse;
}

function OrderCard({
  order: { pizza, pizzaSize, price, orderToppings: toppings },
}: Props) {
  return (
    <>
      <div className="flex flex-row items-center p-7 bg-clr-bg1">
        <div className="mr-5 flex-1">
          <h2 className="font-bold text-fs-h2">{pizza.name}</h2>
          <h3 className="italic font-bold mt-2">Size:</h3>
          <div className="italic">{PizzaSize[pizzaSize]}</div>
          <h3 className="italic font-bold mt-2">Toppings:</h3>
          {toppings.map((t) => (
            <span className="italic">{t.name}, </span>
          ))}
          <h3 className="italic font-bold mt-2">
            Price: <span className="font-normal">{price} €</span>
          </h3>
        </div>
        <img
          src="/pizza.png"
          className="rounded-2xl aspect-auto h-[200px] py-5"
        />
      </div>
    </>
  );
}

export default OrderCard;
