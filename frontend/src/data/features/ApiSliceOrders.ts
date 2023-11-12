import apiSlice from "../ApiSlice";
import { AddOrderRequest } from "../dtos/AddOrderRequest";
import { OrderResponse } from "../dtos/OrderResponse";

const ApiSliceOrders = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getOrders: builder.query<OrderResponse[], undefined>({
      query: () => ({
        url: `/api/orders`,
        method: "GET",
      }),
      providesTags: ["ORDER"],
    }),
    getOrder: builder.query<OrderResponse, number>({
      query: (id) => ({
        url: `/api/orders/${id}`,
        method: "GET",
      }),
      providesTags: ["ORDER"],
    }),
    getPrice: builder.mutation<number, AddOrderRequest>({
      query: (request) => ({
        url: `/api/orders/price`,
        method: "POST",
        body: JSON.stringify(request),
        headers: {
          "Content-Type": "application/json",
        },
      }),
    }),
    addOrder: builder.mutation<boolean, AddOrderRequest>({
      query: (request) => ({
        url: `/api/orders`,
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

export const {
  useGetOrdersQuery,
  useGetPriceMutation,
  useGetOrderQuery,
  useAddOrderMutation,
} = ApiSliceOrders;
