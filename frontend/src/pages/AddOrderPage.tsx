import React from "react";
import PizzaCard from "./orderListPage/PizzaCard";
import { useGetPizzasQuery } from "../data/redux/ApiSlice";

function AddOrderPage() {
  const { data } = useGetPizzasQuery(undefined);
  return (
    <section className="bg-clr-bg1 w-[500px] m-auto rounded-2xl my-10 py-5">
      <h1 className="font-bold px-5 pb-5 text-fs-h1">Pizzas</h1>
      {data?.map((x) => (
        <React.Fragment key={x.id}>
          <hr className="mx-5 border-t-[3px]" />
          <PizzaCard pizza={x} />
        </React.Fragment>
      ))}
    </section>
  );
}

export default AddOrderPage;
