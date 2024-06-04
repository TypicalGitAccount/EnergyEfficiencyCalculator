import React from "react";
import { Route, Routes, useLocation } from "react-router-dom";
import Home from "./pages/Home";
import Login from "./pages/Login";
import Advices from "./pages/Advices";
import NoPage from "./pages/NoPage";
import Profile from "./pages/Profile";
import Register from "./pages/Register";

import { AnimatePresence } from "framer-motion";
import Efficiency from "./pages/Efficiency";

function AnimatedRoutes() {
  const location = useLocation();

  return (
    <AnimatePresence>
      <Routes location={location}>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/efficiency" element={<Efficiency />} />
        <Route path="/advices" element={<Advices />} />
        <Route path="/advices/:buildingFilterFromRoute" element={<Advices />} />
        <Route path="/profile" element={<Profile />} />
        <Route path="/*" element={<NoPage />} />
      </Routes>
    </AnimatePresence>
  );
}

export default AnimatedRoutes;
