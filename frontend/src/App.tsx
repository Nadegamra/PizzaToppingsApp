import { ToastContainer } from "react-toastify";
import AppRoutes from "./components/routing/AppRoutes";
import Header from "./components/layout/Header";

function App() {
  return (
    <div className="min-h-screen flex flex-col text-clr-text1 bg-gray-500 bg-mainBg bg-blend-multiply ">
      <Header />
      <main className="flex-1" id="main-content">
        <ToastContainer
          position="top-center"
          autoClose={1500}
          closeOnClick
          pauseOnHover
          theme="light"
        />
        <AppRoutes />
      </main>
    </div>
  );
}

export default App;
