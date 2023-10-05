import { ToastContainer } from "react-toastify";
import AppRoutes from "./components/routing/AppRoutes";

function App() {
  return (
    <div className="min-h-screen text-clr-text1 bg-gray-500 bg-mainBg bg-blend-multiply py-10">
      <ToastContainer
        position="top-center"
        autoClose={1500}
        closeOnClick
        pauseOnHover
        theme="light"
      />
      <AppRoutes />
    </div>
  );
}

export default App;
