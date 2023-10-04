import { useParams } from "react-router-dom";

function OrderPage() {
  const { id } = useParams();
  return (
    <section>
      <div>Order #{id}</div>
    </section>
  );
}

export default OrderPage;
