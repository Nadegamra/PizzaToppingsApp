import React from "react";
import { useGetOrdersQuery } from "../data/redux/ApiSlice";
import OrderCard from "./orderListPage/OrderCard";

function OrderListPage() {
  const { data } = useGetOrdersQuery(undefined);
  return (
    <section className="bg-clr-bg1 w-[500px] mx-auto rounded-2xl my-10 py-5">
      <h1 className="font-bold px-5 pb-5 text-fs-h1">Orders</h1>
      {data?.map((x) => (
        <React.Fragment key={x.id}>
          <hr className="mx-5 border-t-[3px]" />
          <OrderCard order={x} />
        </React.Fragment>
      ))}
    </section>
  );
}

export default OrderListPage;
