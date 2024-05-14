import { LockOutlined } from "@mui/icons-material";
import {
  Container,
  CssBaseline,
  Box,
  Avatar,
  Typography,
  TextField,
  Button,
  Grid,
} from "@mui/material";
import useAuthContext from "../common/hooks/useAuthContext";
import { Link, useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { motion } from "framer-motion";
import { Helmet } from "react-helmet";

const Login = () => {
  const { user, jwtTokens, loginUser } = useAuthContext();
  const navigate = useNavigate();
  useEffect(() => {
    if (user && jwtTokens) {
      navigate("/");
    }
  }, [user, jwtTokens]);

  return (
    <motion.div
      initial={{ width: 0 }}
      animate={{ width: "100%" }}
      exit={{ x: window.innerWidth, transition: { duration: 0.01 } }}
    >
      <Helmet>
        <title>{"Вхід"}</title>
      </Helmet>

      <Container maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            mt: 20,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "primary.light" }}>
            <LockOutlined />
          </Avatar>
          <Typography variant="h5">Вхід</Typography>
          <form onSubmit={loginUser}>
            <Box sx={{ mt: 1 }}>
              <TextField
                margin="normal"
                required
                fullWidth
                id="email"
                label="Електронна адреса"
                name="email"
                autoFocus
              />

              <TextField
                margin="normal"
                required
                fullWidth
                id="password"
                name="password"
                label="Пароль"
                type="password"
              />

              <Button
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
                type="submit"
              >
                Вхід
              </Button>

              <Grid container justifyContent="flex-end">
                <Grid item>
                  <Link to="/register">Ще не маєте акаунта? Реєстрація</Link>
                </Grid>
              </Grid>
            </Box>
          </form>
        </Box>
      </Container>
    </motion.div>
  );
};

export default Login;
