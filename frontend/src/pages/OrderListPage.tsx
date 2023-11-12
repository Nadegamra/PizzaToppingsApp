import OrderCard from "../components/cards/OrderCard";
import Card from "../components/cards/Card";
import CardItem from "../components/cards/CardItem";
import { useGetOrdersQuery } from "../data/features/ApiSliceOrders";
import CardHeader from "../components/cards/CardHeader";

function OrderListPage() {
  const { data } = useGetOrdersQuery(undefined);
  return (
    <Card>
      <CardHeader>Orders</CardHeader>
      {data?.map((x) => (
        <CardItem id={x.id}>
          <OrderCard order={x} />
        </CardItem>
      ))}
    </Card>
  );
}

export default OrderListPage;
