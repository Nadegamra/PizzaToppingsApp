import apiSlice from "../ApiSlice";
import { Topping } from "../dtos/Topping";

const ApiSliceToppings = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getToppings: builder.query<Topping[], undefined>({
      query: () => ({
        url: `/api/toppings`,
        method: "GET",
      }),
    }),
  }),
});

export const { useGetToppingsQuery } = ApiSliceToppings;
