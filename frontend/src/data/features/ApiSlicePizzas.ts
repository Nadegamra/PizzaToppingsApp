import apiSlice from "../ApiSlice";
import { Pizza } from "../dtos/Pizza";

const ApiSlicePizzas = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getPizzas: builder.query<Pizza[], undefined>({
      query: () => ({
        url: `/api/pizzas`,
        method: "GET",
      }),
    }),
  }),
});

export const { useGetPizzasQuery } = ApiSlicePizzas;
