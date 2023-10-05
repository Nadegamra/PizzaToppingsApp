import { Route, Routes } from "react-router-dom";
import AddOrderPage from "../../pages/AddOrderPage";
import OrderListPage from "../../pages/OrderListPage";

function AppRoutes() {
  return (
    <Routes>
      <Route path="/" element={<AddOrderPage />} />
      <Route path="/orders" element={<OrderListPage />} />
    </Routes>
  );
}

export default AppRoutes;
