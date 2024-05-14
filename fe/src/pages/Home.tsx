import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import useAuthContext from "../common/hooks/useAuthContext";
import Features from "../common/ui/Features";
import { motion } from "framer-motion";
import { Helmet } from "react-helmet";

export default function Home() {
  const { user, jwtTokens } = useAuthContext();
  const navigate = useNavigate();
  useEffect(() => {
    if (!user || !jwtTokens) {
      navigate("/login");
    }
  }, [user, jwtTokens, navigate]);

  return (
    <motion.div
      initial={{ width: 0 }}
      animate={{ width: "100%" }}
      exit={{ x: window.innerWidth, transition: { duration: 0.01 } }}
    >
      <Helmet>
        <title>{"Головна"}</title>
      </Helmet>

      <Features />
    </motion.div>
  );
}
