import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const apiSlice = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery(),
  tagTypes: ["ORDER"],
  refetchOnFocus: true,
  endpoints: () => ({}),
});

export default apiSlice;
