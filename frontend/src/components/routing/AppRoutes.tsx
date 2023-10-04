import { Route, Routes } from "react-router-dom";
import AddOrderPage from "../../pages/AddOrderPage";
import OrderListPage from "../../pages/OrderListPage";
import OrderPage from "../../pages/OrderPage";

function AppRoutes() {
  return (
    <Routes>
      <Route path="/" element={<AddOrderPage />} />
      <Route path="/orders" element={<OrderListPage />} />
      <Route path="/orders/:id" element={<OrderPage />} />
    </Routes>
  );
}

export default AppRoutes;
