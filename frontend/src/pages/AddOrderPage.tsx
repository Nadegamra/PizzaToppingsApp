import PizzaCard from "../components/cards/PizzaCard";
import Card from "../components/cards/Card";
import CardItem from "../components/cards/CardItem";
import { useGetPizzasQuery } from "../data/features/ApiSlicePizzas";
import CardHeader from "../components/cards/CardHeader";

function AddOrderPage() {
  const { data } = useGetPizzasQuery(undefined);
  return (
    <Card>
      <CardHeader>Pizzas</CardHeader>
      {data?.map((x) => (
        <CardItem id={x.id}>
          <PizzaCard pizza={x} />
        </CardItem>
      ))}
    </Card>
  );
}

export default AddOrderPage;
