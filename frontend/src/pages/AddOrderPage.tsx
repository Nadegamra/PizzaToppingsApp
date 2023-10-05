import PizzaCard from "../components/PizzaCard";
import { useGetPizzasQuery } from "../data/redux/ApiSlice";

function AddOrderPage() {
  const { data } = useGetPizzasQuery(undefined);
  return (
    <section className="bg-clr-bg1 w-[500px] m-auto rounded-2xl">
      <div>
        <h1 className="font-bold p-5 text-fs-h1">Pizzas</h1>
        {data?.map((x) => (
          <>
            <hr className="mx-5" />
            <PizzaCard pizza={x} />
          </>
        ))}
      </div>
    </section>
  );
}

export default AddOrderPage;
