import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import AnimatedRoutes from "./AnimatedRoutes";
import { AuthProvider } from "./common/context/AuthProvider";
import { Container, CssBaseline } from "@mui/material";
import { Navbar } from "./common/ui/Navbar";

function App() {
  return (
    <>
      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={true}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
      />
      <AuthProvider>
        <Navbar />
        <CssBaseline />
        <Container className="mb-4">
          <AnimatedRoutes />
        </Container>
      </AuthProvider>
    </>
  );
}

export default App;
