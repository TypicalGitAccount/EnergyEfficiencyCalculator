import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import useAuthContext from "../common/hooks/useAuthContext";
import { User } from "../common/interfaces";
import { getUser } from "../common/api";
import UserDetail from "../common/ui/UserDetail";
import { motion } from "framer-motion";
import { Helmet } from "react-helmet";

const Profile = () => {
  const { user } = useAuthContext();
  const { jwtTokens } = useAuthContext();
  const [userInfo, setUserInfo] = useState<User | null>(null);
  const navigate = useNavigate();

  useEffect(() => {
    async function getResponse() {
      if (user) {
        const result = await getUser(jwtTokens!.accessToken, user!.id);
        if (result) setUserInfo(result as User);
        else {
          toast.error("Failed loading user information!");
          navigate("/login");
        }
      } else {
        toast.error("Invalid logged-in user!");
        navigate("/login");
      }
    }

    getResponse();
  }, [user, jwtTokens, navigate]);

  return (
    <motion.div
      initial={{ width: 0 }}
      animate={{ width: "100%" }}
      exit={{ x: window.innerWidth, transition: { duration: 0.01 } }}
    >
      <Helmet>
        <title>{"Профіль"}</title>
      </Helmet>

      {userInfo ? <UserDetail key={userInfo!.id} userObj={userInfo} /> : <></>}
    </motion.div>
  );
};

export default Profile;
