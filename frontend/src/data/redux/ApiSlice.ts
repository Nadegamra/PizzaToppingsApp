import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { Pizza } from "../dtos/Pizza";
import { Topping } from "../dtos/Topping";
import { OrderResponse } from "../dtos/OrderResponse";
import { AddOrderRequest } from "../dtos/AddOrderRequest";

const apiSlice = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery(),
  tagTypes: ["ORDER"],
  refetchOnFocus: true,
  endpoints: (builder) => ({
    getPizzas: builder.query<Pizza[], undefined>({
      query: () => ({
        url: "http://localhost:44444/api/pizzas/all",
        method: "GET",
      }),
    }),
    getToppings: builder.query<Topping[], undefined>({
      query: () => ({
        url: "http://localhost:44444/api/toppings/all",
        method: "GET",
      }),
    }),
    getOrders: builder.query<OrderResponse[], undefined>({
      query: () => ({
        url: "http://localhost:44444/api/orders/all",
        method: "GET",
      }),
      providesTags: ["ORDER"],
    }),
    getOrder: builder.query<OrderResponse, number>({
      query: (id) => ({
        url: `http://localhost:44444/api/orders?id=${id}`,
        method: "GET",
      }),
      providesTags: ["ORDER"],
    }),
    addOrder: builder.mutation<boolean, AddOrderRequest>({
      query: (request) => ({
        url: "http://localhost:44444/api/orders",
        method: "POST",
        body: JSON.stringify(request),
        headers: {
          "Content-Type": "application/json",
        },
      }),
      invalidatesTags: ["ORDER"],
    }),
  }),
});

export default apiSlice;

export const {
  useGetPizzasQuery,
  useGetToppingsQuery,
  useGetOrdersQuery,
  useGetOrderQuery,
  useAddOrderMutation,
} = apiSlice;
